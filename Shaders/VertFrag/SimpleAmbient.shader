
Shader "SimpleAmbient" {
	Properties{
		_AmbientLightColor("Ambient Light Color", Color) = (1,1,1,1)
	}


	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma target 2.0
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			fixed4 _AmbientLightColor;
			float _AmbientLighIntensity;
			int _SomeLightValue;
		
		
			struct v2f {
				float2 uv: TEXCOORD0;
			};

			v2f vert(
				float4 vertex : POSITION, // vertex position input
				float2 uv : TEXCOORD0, // texture coordinate input
				out float4 outpos : SV_POSITION // clip space position output
			)
			{
				v2f o;
				o.uv = uv;
				outpos = UnityObjectToClipPos(vertex);
				return o;
			}

			fixed4 frag(v2f i, UNITY_VPOS_TYPE screenPos : VPOS) : SV_Target
			{
				// screenPos.xy will contain pixel integer coordinates.
				// use them to implement a checkerboard pattern that skips rendering
				// 4x4 blocks of pixels

				// checker value will be negative for 4x4 blocks of pixels
				// in a checkerboard pattern
				screenPos.xy = floor(screenPos.xy * 0.25) * 0.5;
				float checker = -frac(screenPos.r + screenPos.g);
				clip(checker);

				return _AmbientLightColor;
			}


			ENDCG
		}
	}
}
