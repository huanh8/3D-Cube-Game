Shader "Unlit/ToonShader"
{
    Properties
    {
        _Albedo ("Albedo", Color) = (1,1,1,1)
        _Shades ("Shades", Range(1, 20)) = 5

        _InkColor ("InkColor", Color) = (0,0,0,0)
        _InkSize("InkSize", float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        
        // Outline shader
        Pass
        {
            Cull Front

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            float4 _InkColor;
            float _InkSize;

            v2f vert (appdata v)
            {
                v2f o;
                // Increase the size of the model (the weight of outline)
                o.vertex = UnityObjectToClipPos(v.vertex + v.normal * 0.01 * _InkSize);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _InkColor;
            }
            ENDCG
        }



        // Material Main shader
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
            };

            float4 _Albedo;
            float _Shades;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Calculate the COSINE of the angle between the light direction and the normal vector
                // World space light stored in _WorldSpaceLightPos0
                // World space normal stored in i.worldNormal
                float cosAngle = dot(normalize(i.worldNormal), normalize(_WorldSpaceLightPos0.xyz));

                // Set minimum as 0 since result could be negative
                cosAngle = max(cosAngle, 0.0);

                cosAngle = floor(cosAngle * _Shades) / _Shades;

                return _Albedo * cosAngle;
            }
            ENDCG
        }
    }

    // Fallback for shadows
    Fallback "VertexLit"
}
