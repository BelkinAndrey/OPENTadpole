// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//Water Metaball Shader effect by Rodrigo Fernandez Diaz-2013
//Visit http://codeartist.info/ for more!!
Shader "Custom/RefractionShader" {
Properties { 
 	_MyColor ("Some Color", Color) = (1,1,1,1)  
    _MainTex ("Texture", 2D) = "white" { } 
	_BumpMap ("Normalmap", 2D) = "bump" {}
	_BackTex ("Background", 2D) = "white" {}
    _constant ("Strength constant", Range(0,100)) = 1 
		
	_Thickness ("Thickness", Range (0.01, 10)) = 1
	_Threshold ("Threshold", Range (0.001, 1)) = 0.1
	_FinalAlphaMultiplier ("FinalAlphaMultiplier", Range (0.001, 10)) = 1
}
SubShader {
	Tags {"Queue" = "Transparent" }
    Pass {
    Blend SrcAlpha OneMinusSrcAlpha     
	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag	
	#include "UnityCG.cginc"	
	float4 _MyColor;
	float4 _Color;
	sampler2D _MainTex;	
	sampler2D _BumpMap;
	sampler2D _BackTex;
	half _FinalAlphaMultiplier;
	half _Threshold;
	half _Thickness;

	struct v2f {
	    float4  pos : SV_POSITION;
	    float2  uv : TEXCOORD0;
	};	
	float4 _MainTex_ST;	
	
	v2f vert (appdata_base v){
	    v2f o;
	    o.pos = UnityObjectToClipPos (v.vertex);
	    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
	    return o;
	}	
	
	half4 frag (v2f i) : COLOR{		
		half4 finalColor;
		
		fixed4 tex = tex2D(_MainTex, i.uv);
		tex.a *= _FinalAlphaMultiplier;

		if(tex.a > _Threshold)
		{
			fixed3 normal = UnpackNormal(tex2D(_BumpMap, i.uv));
			fixed4 backTex = tex2D(_BackTex, i.uv + normal.xy * _Thickness);
			tex.a = length(tex.xyz);
			finalColor = tex*tex.a + backTex*(1.0-tex.a);
		}
		else
		{
			finalColor = tex2D(_BackTex, i.uv);
		}
				
	    return finalColor;
	}
	ENDCG

    }
}
Fallback "VertexLit"
}