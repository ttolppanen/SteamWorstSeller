Shader "Unlit/Curvy"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_AmountOfCurving("Kuinka paljon kiemuroita", Float) = 1
	}
	SubShader
	{
		Tags
	{
		"RenderType" = "Transparent"
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
	}
		Cull Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _AmountOfCurving;
			
			v2f vert (appdata v)
			{
				v2f o;
				float2 vectorFromMiddle = v.uv - float2(0.5, 0.5);
				float angle = atan2(vectorFromMiddle.y, vectorFromMiddle.x);
				float vectorLength = length(vectorFromMiddle);
				float2 whereToReadPixel = vectorLength * float2(cos(angle + pow(vectorLength, 2) * _AmountOfCurving), sin(angle + pow(vectorLength, 2) * _AmountOfCurving)) + float2(0.5, 0.5);
				o.vertex = UnityObjectToClipPos(float4(whereToReadPixel.x, whereToReadPixel.y, 0 ,0));
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
			
				fixed4 col = tex2D(_MainTex, i.uv);
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
