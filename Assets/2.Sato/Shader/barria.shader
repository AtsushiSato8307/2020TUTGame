Shader "Unlit/barria"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_DistTex("DistTex", 2D) = "grey"{}
		_Color("Color", Color) = (1, 1, 1, 1)
		_Smoothness("Smoothness", Range(0, 1)) = 1
		_Fresnel("Fresnel", Range(0.0, 1.0)) = 0.02
		_EdgeWhitePow("EdgeWhite", Range(0.0, 50)) = 10
		_Speed("Speed ",Range(0, 100)) = 1
		_Power("Poewr", Range(0, 1)) = 0.5
	}
    SubShader
    {
        Tags {
		"Queue" = "Transparent"
		"RenderType"="Transparent" }
			Blend DstColor Zero
			LOD 200
			cull Back
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag alpha:blend
            // make fog work
            #pragma multi_compile_fog


            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				half3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
				half vdotn : TEXCOORD1;
            };
			float wave(float2 uv, float2 emitter, float speed, float phase) {
				float dst = distance(uv, emitter);
				return pow((0.5 + 0.5 * sin(dst * phase - _Time.y * speed)), 2.0);
			}
            sampler2D _MainTex;
			sampler2D _DistTex;
            float4 _MainTex_ST;
			half3 _Color;
			half _Alpha;
			float _Fresnel;
			float _EdgeWhitePow;
			float _Speed;
			float _Power;

            v2f vert (appdata v)
            {

                v2f o;
				// 時間によって波が移動するように
				float time = _Time * _Speed;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				half3 viewDir = normalize(ObjSpaceViewDir(v.vertex));
				o.vdotn = dot(viewDir, v.normal.xyz);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

			fixed4 frag(v2f i) : SV_Target
			{
				//
				float2 distuv = i.uv;
				float2 position = i.uv;

				float w = wave(position, float2(0, 0.5), _Speed, 180.0);
				w += wave(position, float2(0, 1), _Speed, 180.0);
				//w += wave(position, float2(0.9, 0.6), _Speed, 90.0);
				//w += wave(position, float2(0.1, 0.84), _Speed, 150.0);
				//w += wave(position, float2(0.32, 0.81), _Speed, 150.0);
				//w += wave(position, float2(0.16, 0.211), _Speed, 150.0);
				//w += wave(position, float2(0.39, 0.46), _Speed, 150.0);
				//w += wave(position, float2(0.51, 0.484), _Speed, 150.0);
				//w += wave(position, float2(0.732, 0.91), _Speed, 150.0);

				w *= 0.116 * _Power;
				//i.uv += w;
				distuv += w;
				//
                // sample the texture
				half fresnel = _Fresnel + (1.0h - _Fresnel) * pow(1.0h - i.vdotn, 5);
				fixed3 distcol = tex2D(_DistTex, distuv);
				i.uv.y += _Time * 5;
                fixed3 maincol = tex2D(_MainTex, i.uv);
				maincol = (maincol + distcol) * _Color;
				fixed4 col = fixed4(lerp(maincol, _EdgeWhitePow ,fresnel), 1);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
