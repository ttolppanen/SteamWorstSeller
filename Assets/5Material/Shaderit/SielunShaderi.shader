Shader "Unlit/SielunShaderi"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_SielunSisin ("Sielun sisä osa", 2D) = "white" {}
		_VareilyNopeus("Vareily nopeus", Float) = 1
		_AaltojenMaara("Aaltojen maara", Float) = 1
		_RiippuvuusKorkeudesta("_Riippuvuus korkeudesta", Float) = 1
		_Kerroin("Kerroin", Float) = 1
		_VihreaVaiheEro("Vihrea vaihe-ero", Float) = 1
		_SininenVaiheEro("Sininen vaihe-ero", Float) = 1
		_VarinMuutosKerroin("Varin muutos kerroin", Float) = 1
	}
	SubShader
	{
		Tags{
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
			sampler2D _SielunSisin;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			float _VareilyNopeus;
			float _AaltojenMaara;
			float _RiippuvuusKorkeudesta;
			float _Kerroin;
			float _VihreaVaiheEro;
			float _SininenVaiheEro;
			float _VarinMuutosKerroin;

			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 sielunCol = tex2D(_SielunSisin, i.uv + float2(sin(_Time.y * _VareilyNopeus + _AaltojenMaara * i.uv.y), 0) * pow(i.uv.y, _RiippuvuusKorkeudesta) * _Kerroin);
				if (sielunCol.a != 0) 
				{
					col = float4(col.r + sielunCol.r, col.g + sielunCol.g, col.b + sielunCol.b, sielunCol.a) / 2;
					col.a = sielunCol.a;
				}
				col.r *= 1 + (sin(_Time.y) + 1) / _VarinMuutosKerroin;
				col.g *= 1 + (sin(_Time.y + _VihreaVaiheEro) + 1) / _VarinMuutosKerroin;
				col.b *= 1 + (sin(_Time.y + _SininenVaiheEro) + 1) / _VarinMuutosKerroin;
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
