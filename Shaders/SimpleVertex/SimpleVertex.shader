//http://answers.unity3d.com/questions/797565/simple-vertex-color-light-shader.html
Shader "Vertex Color Lit" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
	}
		SubShader{
		Pass{
		Lighting On
		ColorMaterial AmbientAndDiffuse
		SetTexture[_MainTex]{
		combine texture * primary DOUBLE
	}
	}
	}
}