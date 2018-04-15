// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//Water Metaball Shader effect by Rodrigo Fernandez Diaz-2013
//Visit http://codeartist.info/ for more!!
Shader "Custom/NormalMapFromHeightMap" {
Properties { 
 	_MyColor ("Some Color", Color) = (1,1,1,1)  
    _MainTex ("Texture", 2D) = "white" { } 
    _constant ("Strength constant", Range(0,100)) = 1 
	_HeightmapDimX ("Heightmap Width", Float) = 2048
	_HeightmapDimY ("Heightmap Height", Float) = 2048

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
	float _constant, _HeightmapDimX, _HeightmapDimY;


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
				
		float me = tex2D(_MainTex, i.uv).z * _constant;
		float n = tex2D(_MainTex, float2(i.uv.x, i.uv.y+1.0/_HeightmapDimY)).a * _constant;
		float s = tex2D(_MainTex, float2(i.uv.x, i.uv.y-1.0/_HeightmapDimY)).a * _constant;
		float e = tex2D(_MainTex, float2(i.uv.x-1.0/_HeightmapDimX, i.uv.y)).a * _constant;
		float w = tex2D(_MainTex, float2(i.uv.x+1.0/_HeightmapDimX, i.uv.y)).a * _constant;

		//float xDelta = ((w-me) + (me-e))/2.0 + 0.5;			//((e - w) + 1.0) * 0.5;
        //float yDelta = ((s-me) + (me-n))/2.0 + 0.5;			//((s - n) + 1.0) * 0.5;

		
		float xDelta = (w-me) - (e-me) + 0.5;			//((e - w) + 1.0) * 0.5;
        float yDelta = (s-me) - (n-me) + 0.5;			//((s - n) + 1.0) * 0.5;


        finalColor = float4(yDelta, xDelta, 1.0, yDelta);
				
	    return finalColor;
	}
	ENDCG

    }
}
Fallback "VertexLit"
}