Shader "Unlit/unlit"
{
	Properties
	{
		_MainTex("Texture", 2D) = "blue" {}
	  _CompressLengthInY("Compress Length",Range(0,0.5)) = 0
	  
		
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"
		float _CompressLengthInY;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 pos : SV_POSITION;
				UNITY_FOG_COORDS(1)
				//float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				//根据抛物线公式(x + 0.5)^2 =2py而来，其中x为顶点y坐标，y为需要压缩的最大长度
				v.vertex.y -= pow(v.vertex.y + 0.5, 2) * _CompressLengthInY;

				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
