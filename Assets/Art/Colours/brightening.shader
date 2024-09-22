Shader "Custom/AdditiveBlendWithContrast"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}  // Texture to be applied
        _Color ("Tint Color", Color) = (1,1,1,1)  // Tint color (includes alpha)
        _Opacity ("Opacity", Range(0, 1)) = 1.0   // Opacity control
        _Contrast ("Contrast", Range(0.5, 2.0)) = 1.0 // Contrast adjustment
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        LOD 200

        Pass
        {
            ZWrite Off
            Blend SrcAlpha One  // Additive blending for RGB, uses alpha for opacity

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;    // Texture to blend
            float4 _Color;         // Tint color
            float _Opacity;        // Opacity control
            float _Contrast;       // Contrast control

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                // Fetch the texture color
                half4 texColor = tex2D(_MainTex, i.uv);

                // Apply the tint color
                texColor *= _Color;

                // Apply opacity
                texColor.a *= _Opacity;

                // Contrast adjustment: increase contrast by pushing values away from 0.5
                half3 color = texColor.rgb;
                color = (color - 0.5) * _Contrast + 0.5;

                // Return the adjusted color with additive blending
                return half4(color, texColor.a);
            }
            ENDCG
        }
    }
    FallBack "Transparent/Diffuse"
}