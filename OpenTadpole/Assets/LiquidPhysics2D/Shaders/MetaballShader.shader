// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Metaballs" 
{
Properties 
{ 
    _MainTex ("Texture", 2D) = "white" { } 
         
    _botmcut ("Cutoff", Range(0,0.5)) = 0.1   

    _constant ("Multiplier", Range(0,6)) = 1  
}
SubShader 
{
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
	float _botmcut,_topcut,_constant;

	struct v2f {
	    float4  pos : SV_POSITION;
	    float2  uv : TEXCOORD0;
	};	
	float4 _MainTex_ST;	
	
	v2f vert (appdata_base v)
	{
	    v2f o;
	    o.pos = UnityObjectToClipPos (v.vertex);
	    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
	    return o;
	}	
	
	half4 frag (v2f i) : COLOR
	{		
		half4 texcol,finalColor;
	    finalColor = tex2D (_MainTex, i.uv); 		

		if(finalColor.a < _botmcut)
		{
			finalColor.a = 0;  
		}
		else
		{
			finalColor.a *= _constant;  
		}
								
	    return finalColor;
	}
	ENDCG

    }
}
Fallback "VertexLit"
} 