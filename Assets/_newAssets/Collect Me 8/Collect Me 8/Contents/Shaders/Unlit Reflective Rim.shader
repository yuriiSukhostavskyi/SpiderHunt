// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Collect 8/Unlit Reflective Rim"
{
	Properties
	{
        _Color ("Color", Color) = (0.5,0.5,0.5,1.0)
        _HColor ("Highlight Color", Color) = (0.6,0.6,0.6,1.0)
        _SColor ("Shadow Color", Color) = (0.3,0.3,0.3,1.0)

        _Ramp ("Ramp (RGB)", 2D) = "gray" {}

        _RimColor ("Rim Color", Color) = (0.8,0.8,0.8,0.6)
        _RimMin ("Rim Min", Range(0,1)) = 0.5
        _RimMax ("Rim Max", Range(0,1)) = 1.0

        _Reflections ("ReflectionMap", CUBE) = "" {}
        _Reflectivity ("Reflectivity", Range(0,1)) = 1.0
        _ReflectivityOffset ("Reflectivity Offset", Range(0,1)) = 0.3
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
            #pragma multi_compile _ UNITY_COLORSPACE_GAMMA
            #pragma target 3.0
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
                float3 normal : NORMAL;
			};

			struct v2f
			{
                float4 pos : SV_POSITION;
                half3 worldNormal : TEXCOORD0;
                float3 worldRefl : TEXCOORD1;
                float3 worldViewDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
			};

            // Uniform section

            fixed4 _Color;

            fixed4 _RimColor;
            fixed _RimMin;
            fixed _RimMax;
            float4 _RimDir;

            fixed4 _HColor;
            fixed4 _SColor;
            sampler2D _Ramp;
            samplerCUBE _Reflections;
            fixed _Reflectivity;
            fixed _ReflectivityOffset;

            #define GAMMA 2.2
            #define SRGB_TO_GAMMA 1/GAMMA

            // Vertex shader
            v2f vert (appdata v)
			{
                v2f o;
                UNITY_INITIALIZE_OUTPUT(v2f, o);
                o.pos = UnityObjectToClipPos (v.vertex);
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                fixed3 worldNormal = UnityObjectToWorldNormal(v.normal);
                o.worldNormal = worldNormal;
                float3 worldViewDir = UnityWorldSpaceViewDir(worldPos);
                o.worldViewDir = worldViewDir;
                o.worldRefl = reflect(-worldViewDir, worldNormal);
                UNITY_TRANSFER_FOG(o, o.pos);
				return o;
			}

            // Fragment shader
			fixed4 frag (v2f IN) : SV_Target
			{
                fixed4 pixel = fixed4 (0, 0, 0, 1);

                // Start of Rim section

                float3 viewDir = normalize (IN.worldViewDir);
                half rim = 1.0f - saturate (dot (viewDir, IN.worldNormal));
                rim = smoothstep (_RimMin, _RimMax, rim);
                fixed3 cube = texCUBE (_Reflections, IN.worldRefl).rgb;
            #ifndef UNITY_COLORSPACE_GAMMA
                cube = pow (cube, SRGB_TO_GAMMA);
                _RimColor = pow (_RimColor, SRGB_TO_GAMMA);
                //_Color = pow (_Color, SRGB_TO_GAMMA);
            #endif
                cube = cube * _Reflectivity - _ReflectivityOffset;

                pixel.rgb = _Color;
                fixed3 rimPixel = (_RimColor.rgb * rim + cube) * _RimColor.a;

                // End of Rim section

                fixed ndl = max(0, dot (IN.worldNormal, viewDir) * 0.5 + 0.5);

            #ifdef UNITY_COLORSPACE_GAMMA
                fixed3 ramp = tex2D (_Ramp, fixed2 (ndl, ndl));
            #else
                fixed3 ramp = pow(tex2D (_Ramp, fixed2 (ndl, ndl)), SRGB_TO_GAMMA);
                _HColor = pow (_HColor, SRGB_TO_GAMMA);
                _SColor = pow (_SColor, SRGB_TO_GAMMA);
            #endif

                _SColor = lerp (_HColor, _SColor, _SColor.a);
                ramp = lerp (_SColor.rgb, _HColor.rgb, ramp);

            #ifndef UNITY_COLORSPACE_GAMMA
                pixel.rgb = pixel.rgb * ramp + rimPixel;
                pixel = pow (pixel, GAMMA);
            #else
                pixel.rgb = pixel.rgb * ramp + rimPixel;
            #endif

                UNITY_APPLY_FOG (IN.fogCoord, pixel);
				return pixel;
			}
			ENDCG
		}
	}
}
