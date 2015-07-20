// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:3,spmd:1,trmd:1,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:True,qofs:10,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:True;n:type:ShaderForge.SFN_Final,id:3138,x:32803,y:32723,varname:node_3138,prsc:2|emission-3992-OUT,alpha-4591-OUT;n:type:ShaderForge.SFN_Dot,id:5222,x:32007,y:33319,varname:node_5222,prsc:2,dt:1|A-5558-OUT,B-3862-OUT;n:type:ShaderForge.SFN_NormalVector,id:3862,x:31761,y:33414,prsc:2,pt:False;n:type:ShaderForge.SFN_ViewVector,id:5558,x:31918,y:33160,varname:node_5558,prsc:2;n:type:ShaderForge.SFN_Posterize,id:4000,x:32553,y:33278,varname:node_4000,prsc:2|IN-627-OUT,STPS-2323-OUT;n:type:ShaderForge.SFN_Power,id:627,x:32350,y:33446,varname:node_627,prsc:2|VAL-5222-OUT,EXP-1911-OUT;n:type:ShaderForge.SFN_Vector1,id:2323,x:32290,y:33258,varname:node_2323,prsc:2,v1:2;n:type:ShaderForge.SFN_OneMinus,id:3992,x:32760,y:33413,varname:node_3992,prsc:2|IN-4000-OUT;n:type:ShaderForge.SFN_Vector1,id:1911,x:32087,y:33660,varname:node_1911,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:4591,x:32623,y:32981,varname:node_4591,prsc:2,v1:0;pass:END;sub:END;*/

Shader "MOIEN/GlassOutlineV4" {
    Properties {
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent+10"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float node_2323 = 2.0;
                float node_4000 = floor(pow(max(0,dot(viewDirection,i.normalDir)),0.5) * node_2323) / (node_2323 - 1);
                float node_3992 = (1.0 - node_4000);
                float3 emissive = float3(node_3992,node_3992,node_3992);
                float3 finalColor = emissive;
                return fixed4(finalColor,0.0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
