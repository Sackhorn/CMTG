Shader "Custom/S_Timming"
{
	Properties{
		_Color1("Color 1", Color) = (0,1,0)
		_Color2("Color 2", Color) = (0.4,0.4,0)
		_ScreenWidth("Screen Width", Float) = 1280
		_ScreenHeight("Screen Height", Float) = 720
		_pos("Position", Range(0, 1)) = 1
	}
	SubShader{
			Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" }
			LOD 200
			Lighting Off
			Cull Back

			Pass
			{
				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				float _ScreenWidth;
				float _ScreenHeight;

				float _pos;

				fixed3 _Color1;
				fixed3 _Color2;

				struct v2f
				{
					float4 pos:SV_POSITION;
					float2 uv:TEXCOORD0;
					float2 screenPos:TEXCOORD2;
				};

				v2f vert(appdata_full v)
				{
					v2f o;
					o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
					o.screenPos = ComputeScreenPos(o.pos);
					return o;
				}

				float lerp1(float x, float y, float s)
				{
					return x + s * (y - x);
				}
				
				half3 lerp1(half3 x, half3 y, float s)
				{
					return x + s * (y - x);
				}

				half4 frag(v2f inns) : COLOR
				{
					half2 uv = inns.screenPos.xy;

					half2 pixelPos = half2(_ScreenWidth, _ScreenHeight) * uv;
					//uv = floor(uv);

					/*half color = floor(fmod(pixelPos.x, 2)) * floor(fmod(pixelPos.y, 2));
					color = floor(color);

					//half color = frac(pixelPos.x * 0.01) * frac(pixelPos.y * 0.01);
					//color = ceil(color);
					//half color = floor(pixelPos.x) * floor(pixelPos.y);

					color = tex2D(_Pixelozowe, pixelPos);

					float4 texel = tex2D(_MainTex, uv);
					float2 colorIndex = float2(texel[0], max(_pos, 0.06f));
					float4 outColor = tex2D(_ColorRamp, colorIndex);
					//o.Albedo.xyz = half3(outColor.rgb * float3(1,0,0));
					//o.Alpha = outColor.r;
					color *= ceil(outColor.r);*/

					half color = _pos;



					return half4(lerp1(_Color1, _Color2, _pos), 1);
				}

					ENDCG
			}
		}
		FallBack "Diffuse"
}