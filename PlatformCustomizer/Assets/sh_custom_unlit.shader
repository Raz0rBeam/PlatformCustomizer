// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "BeatSaber/Unlit Glow"
{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		[MaterialToggle] _CustomColors("Custom Colors", Float) = 0
		_MainTex ("Texture", 2D) = "white" {}
		_Glow ("Glow", Range (0, 1)) = 0
		[Toggle(_CUSTOMCOLORS_ON)] _CustomColors("Custom Colors", Float) = 0
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
			#pragma shader_feature _CUSTOMCOLORS_ON
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 uv : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				half4 color : COLOR;
			};

			float4 _Color;
			float _Glow;

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.color = v.color;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = _Color * tex2D(_MainTex, TRANSFORM_TEX(i.uv, _MainTex));

				return col * float4(1.0,1.0,1.0,_Glow) * i.color;
			}
			ENDCG
		}
	}
}
