Shader "Custom/S_PixelFade"
{
Properties{
		_ScreenWidth("Screen Width", Float) = 1280
		_ScreenHeight("Screen Height", Float) = 720
		_Pixelozowe("Pixelozowe", 2D) = "black" {}
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
		_ColorRamp("Cutout (A)", 2D) = "white" {}
		_Cutoff("Alpha cutoff", Range(0, 1)) = 0.5
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
			sampler _Pixelozowe;
			sampler2D _MainTex;
			sampler2D _ColorRamp;
			float _Cutoff;

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

			half4 frag(v2f i) : COLOR
			{
				half2 uv = i.screenPos.xy;

				half2 pixelPos = half2(_ScreenWidth, _ScreenHeight) * uv;
				//uv = floor(uv);

				half color = floor(fmod(pixelPos.x, 2)) * floor(fmod(pixelPos.y, 2));
				color = floor(color);

				//half color = frac(pixelPos.x * 0.01) * frac(pixelPos.y * 0.01);
				//color = ceil(color);
				//half color = floor(pixelPos.x) * floor(pixelPos.y);

				color = tex2D(_Pixelozowe, pixelPos);

				float4 texel = tex2D(_MainTex, uv);
				float2 colorIndex = float2(texel[0], max(_Cutoff, 0.06f));
				float4 outColor = tex2D(_ColorRamp, colorIndex);
				//o.Albedo.xyz = half3(outColor.rgb * float3(1,0,0));
				//o.Alpha = outColor.r;
				color = outColor.r;



				return half4(color, color, color, 1);
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}