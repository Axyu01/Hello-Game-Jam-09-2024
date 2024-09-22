Shader "Custom/MultiplyBlendWithOpacityCorrected"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}  // Texture to be applied
        _Color ("Tint Color", Color) = (1,1,1,1)  // Tint color
        _Opacity ("Opacity", Range(0, 1)) = 1.0   // Opacity control
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        LOD 200

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha  // Standard alpha blending

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

                // Apply opacity to the color
                texColor.rgb *= _Opacity; // This controls how bright the texture appears
                texColor.a *= _Opacity;   // Control the transparency

                // Multiply blend with the background color (assumed to be white for simplicity)
                half3 blendedColor = texColor.rgb * (1.0 - texColor.rgb);

                // Return the final color
                return half4(blendedColor, texColor.a);
            }
            ENDCG
        }
    }
    FallBack "Transparent/Diffuse"
}