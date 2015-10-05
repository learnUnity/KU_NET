Shader "Kubility/PsLV_shader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		//Add the Input Levels Values
		_inBlack ("Input Black", Range(0, 255)) = 0
		_inGamma ("Input Gamma", Range(0, 2)) = 1.61
		_inWhite ("Input White", Range(0, 255)) = 255
		
		//Add the Output Levels
		_outWhite ("Output White", Range(0, 255)) = 255
		_outBlack ("Output Black", Range(0, 255)) = 0
	}
SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		
		//Add these variables
		//to the CGPROGRAM
		float _inBlack;
		float _inGamma;
		float _inWhite;
		float _outWhite;
		float _outBlack;

		struct Input {
			float2 uv_MainTex;
		};

		float GetPixelLevel(float pixelColor)
		{
			float pixelResult;
			pixelResult = (pixelColor * 255.0);
			pixelResult = max(0, pixelResult - _inBlack);
			pixelResult = saturate(pow(pixelResult / (_inWhite - _inBlack), _inGamma));
			pixelResult = (pixelResult * (_outWhite - _outBlack) + _outBlack)/255.0;	
			return pixelResult;
			
		}
		
		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			
			//Create a variable to store 	
			//a pixel channel from our _MainTex texture
			float outRPixel  = GetPixelLevel(c.r);
			
			float outGPixel = GetPixelLevel(c.g);
			
			float outBPixel = GetPixelLevel(c.b);
			
			o.Albedo = float3(outRPixel,outGPixel,outBPixel);
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
