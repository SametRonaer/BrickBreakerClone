
	Shader "TranparentShader" {
		Properties{

				_myDiffuse("Colour", Color) = (1,1,1,1)
				_myRange("Emission" , Range(0,1)) = 1
				_myRangeTransparency("Opacity" , Range(0,1)) = 1
		}
			SubShader{
				Tags{
					"Queue" = "Transparent"
				}


				CGPROGRAM
				#pragma surface surf Lambert alpha:fade

				fixed4 _myDiffuse;
				half _myRange;
				half _myRangeTransparency;

			struct Input {
				float2 uv_MainTex;
			};

			void surf(Input IN, inout SurfaceOutput o) {

				o.Albedo = _myDiffuse.rgb;
				o.Alpha = _myRangeTransparency;
				o.Emission = _myDiffuse.rgb * _myRange;
			}
			ENDCG
		}
			FallBack "Diffuse"

	}
