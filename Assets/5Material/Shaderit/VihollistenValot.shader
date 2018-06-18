Shader "Unlit/VihollistenValot"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_ValoKerroin("Float", Float) = 1
	}
	SubShader
	{
		Tags { 
		"RenderType"="Transparent"
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
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			float _EtaisyysValoon;
			float _ValoKerroin;

			fixed4 frag (v2f i) : SV_Target
			{
				
				fixed4 col = tex2D(_MainTex, i.uv);
				float oikeaValo = _EtaisyysValoon * _ValoKerroin + 1;
				col.r *= 1 / oikeaValo;
				col.g *= 1 / oikeaValo;
				col.b *= 1 / oikeaValo;

				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
