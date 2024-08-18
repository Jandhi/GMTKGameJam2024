Shader "Unlit/SwirlShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _SwirlStrength ("SwirlStrength", float) = 1
        _AnimateXY("Animate X Y", Vector) = (0,0,0,0)
    }
    SubShader
    {
        Cull Off
        Blend One OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vertexFunc
            #pragma fragment fragmentFunc
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _AnimateXY;

            struct v2f {
                float4 pos : SV_POSITION;
                half2 uv : TEXCOORD0;
            };

            v2f vertexFunc(appdata_base v) {
                v2f o;
                
                
                
                o.pos = UnityObjectToClipPos(v.vertex)+0.5f;
                
                
                o.uv = v.texcoord ;
                
                return o;
            }

            fixed4 _Color;
            float4 _MainTex_TexelSize;

            fixed4 fragmentFunc(v2f i) : COLOR{
                float2 uvs = i.uv;

                uvs.x /= (1-frac(float2(_Time.y,0)));
                uvs.y /= (1-frac(float2(_Time.y,0)));
                //float2x2 rotMatrix = {cos(_Time.y*2*3.14), sin(_Time.y*2*3.14)
                //                    , -sin(_Time.y*2*3.14), cos(_Time.y*2*3.14)};

                //uvs = mul(rotMatrix , uvs);
                //uvs *= 2;
                //uvs.y += frac(float2(_Time.y,0)) +uvs.x;
                //uvs += _AnimateXY.xy * frac(float2(_Time.y,0));
                //return fixed4(uvs,0,1);

                //uvs.x = uvs.x*frac(float(_SinTime.a));
                //uvs.y = uvs.y*frac(float(_SinTime.a));

                //uvs.x +=frac(float(_SinTime.a));
                //uvs.y += frac(float(_SinTime.a));

                half4 c = tex2D(_MainTex, uvs);
                c.rgb *= c.a;

                return c;
            }


            ENDCG
        }
    }
}
