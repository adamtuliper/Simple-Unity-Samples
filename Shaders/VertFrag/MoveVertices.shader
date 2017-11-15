Shader "MoveVertices" {
		Properties{
			_AmbientLightColor("Ambient Light Color", Color) = (1,1,1,1)
			_AmbientLighIntensity("Ambient Light Intensity", Range(0.0, 1.0)) = 1.0
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
					float4 pos : POSITION;
					float2 uv: TEXCOORD0;
				};

				v2f vert(appdata_full v) {
					v2f o;

					float angle = _Time * 50;

					v.vertex.y += sin(v.vertex.y + angle);
					v.vertex.x += cos(v.vertex.x / 2 + angle);
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = v.texcoord;
					return o;
				}

				fixed4 frag() : SV_Target
				{
					return _AmbientLightColor *_AmbientLighIntensity;
				}


				ENDCG
			}
		}
	}
