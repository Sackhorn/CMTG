Shader "Custom/S_CameraFade" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "" {}

		_pos("_pos", Range(0, 1)) = 0
	}

	// Shader code pasted into all further CGPROGRAM blocks
	CGINCLUDE

#include "UnityCG.cginc"

		struct v2f {
			float4 pos : SV_POSITION;
			half2 uv : TEXCOORD0;
		};

		sampler2D _MainTex;

		float _pos;

		float lerp1(float x, float y, float s)
		{
			return x + s * (y - x);
		}

		half3 lerp1(half3 x, half3 y, float s)
		{
			return x + s * (y - x);
		}

		v2f vert(appdata_img v)
		{
			v2f o;
			o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
			o.uv = v.texcoord.xy;
			return o;
		}

		fixed4 frag(v2f i) : SV_Target
		{
			fixed4 baseCol = tex2D(_MainTex, i.uv);
			fixed4 color = baseCol;
			
			color.rgb = lerp1(baseCol.rgb, fixed3(0, 0, 0), _pos);

			return color;
		}

			ENDCG

			Subshader{
			Pass{
				ZTest Always Cull Off ZWrite Off

				CGPROGRAM
#pragma vertex vert
#pragma fragment frag
				ENDCG
			}
		}

		Fallback off

}
