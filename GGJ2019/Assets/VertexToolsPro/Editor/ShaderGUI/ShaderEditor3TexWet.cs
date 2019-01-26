﻿using UnityEngine;
using System;
using UnityEditor;

public class ShaderEditor3TexWet : ShaderGUI
{
	[SerializeField]
	MaterialProperty[] matProperties;
	[SerializeField]
	private MaterialEditor matEditor;
	[SerializeField]
	private Material targetMat;

	private GUIStyle headerBoxStyle;
	private GUIStyle bodyH1Style;
	private GUIStyle bodyH2Style;
	private GUIStyle neutralGUIStyle;
	private GUIStyle redChannelGUIStyle;
	private GUIStyle greenChannelGUIStyle;
	private GUIStyle blueChannelGUIStyle;

	[SerializeField]
	private bool showGeneralSettings = false;
	[SerializeField]
	private bool useHeightbasedBlending = false;

	[SerializeField]
	private bool showParallaxSetting = false;
	[SerializeField]
	private bool useParallax = true;
	[SerializeField]
	private int parallaxInterpolation = 20;

	[SerializeField]
	private bool useDepthBias = false;
	[SerializeField]
	private float depthBiasDistance = 50f;
	[SerializeField]
	private float depthBiasPower = 2f;
	[SerializeField]
	private float depthBiasThreshold = 0f;

	[SerializeField]
	private bool showRedChannel = false;
	[SerializeField]
	private bool showWetnessRed = true;



	[SerializeField]
	private bool showGreenChannel = false;
	[SerializeField]
	private bool showParallaxGreen = true;
	[SerializeField]
	private bool useParallaxOfR2 = false;
	[SerializeField]
	private bool showHeightBasedGreen = true;
	[SerializeField]
	private bool showWetnessGreen = true;





	[SerializeField]
	private bool showBlueChannel = false;
	[SerializeField]
	private bool showParallaxBlue = true;
	[SerializeField]
	private bool useParallaxOfR3 = false;
	[SerializeField]
	private bool showHeightBasedBlue = true;
	[SerializeField]
	private bool showWetnessBlue = true;




	public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
	{

		matProperties = properties;
		matEditor = materialEditor;

		//base.OnGUI(matEditor, properties);
		targetMat = matEditor.target as Material;
	

		generateStyles ();

		GUILayout.BeginVertical (neutralGUIStyle);
		guiForGeneral ();
		GUILayout.EndVertical ();

		GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));

		GUILayout.BeginVertical (neutralGUIStyle);
		guiForParallax ();
		GUILayout.EndVertical ();

		GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));

		GUILayout.BeginVertical (redChannelGUIStyle);
		guiForRedChannel ();
		GUILayout.EndVertical ();

		GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));

		GUILayout.BeginVertical (greenChannelGUIStyle);
		guiForGreenChannel ();
		GUILayout.EndVertical ();

		GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));

		GUILayout.BeginVertical (blueChannelGUIStyle);
		guiForBlueChannel ();
		GUILayout.EndVertical ();

		GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));


		// render the default gui
		//base.OnGUI(materialEditor, properties);

		/*Material targetMat = materialEditor.target as Material;

		// see if redify is set, and show a checkbox
		bool redify = Array.IndexOf(targetMat.shaderKeywords, "REDIFY_ON") != -1;
		EditorGUI.BeginChangeCheck();
		redify = EditorGUILayout.Toggle("Redify material", redify);
		if (EditorGUI.EndChangeCheck())
		{
			// enable or disable the keyword based on checkbox
			if (redify)
				targetMat.EnableKeyword("REDIFY_ON");
			else
				targetMat.DisableKeyword("REDIFY_ON");
		}

		*/

	}

	MaterialProperty getProperty( string propertyName ) {

		foreach (MaterialProperty matProp in matProperties) {

			if (matProp.name == propertyName)
				return matProp;

		}

		return null;

	}


	void guiForRedChannel() {


		showRedChannel = targetMat.GetFloat("_showRed") == 1;

		showRedChannel = EditorGUILayout.Foldout(showRedChannel, "Red Channel Settings");

		targetMat.SetFloat ("_showRed", showRedChannel ? 1f : 0f );

		if (!showRedChannel)
			return;

		matEditor.TextureProperty (getProperty ("_MainTex"), "Albedo Map");
		//getProperty ("_MainTex").textureScaleAndOffset;
		matEditor.RangeProperty (getProperty ("_Metallic"), "Metallic Strength");

		matEditor.TextureProperty (getProperty ("_BumpMap"), "Bump Map");
		matEditor.TextureProperty (getProperty ("_CombinedMap"), "Combined Map");

		matEditor.RangeProperty (getProperty ("_Smoothness"), "Smoothness Strength");
		matEditor.RangeProperty (getProperty ("_Occlusion"), "Occlusion Strength Strength");

		matEditor.RangeProperty ( getProperty ("_Emission"), "Emission Strength");

		matEditor.ColorProperty ( getProperty ("_EmissionColor"), "Emission Color");

		if (useParallax) {

			matEditor.RangeProperty (getProperty ("_Parallax"), "Parallax Strength");

		}


		showWetnessRed = EditorGUILayout.Foldout (showWetnessRed, "Wetness Settings");

		if (showWetnessRed) {

			matEditor.ColorProperty (getProperty ("_wetnessAlbedoModifier"), "Albedo Modifier");
			matEditor.RangeProperty (getProperty ("_wetnessSmoothnessModifier"), "Smoothness Modifier");
			matEditor.RangeProperty (getProperty ("_wetnessNormalModifier"), "Normal Modifier");


		}





	}

	void guiForGreenChannel() {

		showGreenChannel = targetMat.GetFloat("_showGreen") == 1;
		showGreenChannel = EditorGUILayout.Foldout(showGreenChannel, "Green Channel Settings");
		targetMat.SetFloat ("_showGreen", showGreenChannel ? 1f : 0f );

		if (!showGreenChannel)
			return;

		matEditor.TextureProperty (getProperty ("_MainTex2"), "Albedo Map");
		//getProperty ("_MainTex").textureScaleAndOffset;
		matEditor.RangeProperty (getProperty ("_Metallic2"), "Metallic Strength");

		matEditor.TextureProperty (getProperty ("_BumpMap2"), "Bump Map");
		matEditor.TextureProperty (getProperty ("_CombinedMap2"), "Combined Map");

		matEditor.RangeProperty (getProperty ("_Smoothness2"), "Smoothness Strength");
		matEditor.RangeProperty (getProperty ("_Occlusion2"), "Occlusion Strength Strength");


		matEditor.RangeProperty ( getProperty ("_Emission2"), "Emission Strength");
		matEditor.ColorProperty ( getProperty ("_EmissionColor2"), "Emission Color");

		if (useParallax) {
			
			showParallaxGreen = EditorGUILayout.Foldout (showParallaxGreen, "Parallax Settings");

			if (showParallaxGreen) {

				matEditor.RangeProperty (getProperty ("_Parallax2"), "Parallax Strength");

				useParallaxOfR2 = targetMat.GetFloat("_useP1_2") == 1;
				useParallaxOfR2 = EditorGUILayout.Toggle ("Use Base Heightmap", useParallaxOfR2);
				targetMat.SetFloat ("_useP1_2", useParallaxOfR2 ? 1f : 0f );

			}

		}



		if (useHeightbasedBlending) {

			showHeightBasedGreen = EditorGUILayout.Foldout (showHeightBasedGreen, "Heightbased Blending Settings");

			if (showHeightBasedGreen) {
				
				matEditor.RangeProperty (getProperty ("_BaseHeight2"), "Base Height of Layer");
				matEditor.RangeProperty (getProperty ("_HeightmapFactor2"), "HeightMap Multiplier");
				matEditor.RangeProperty (getProperty ("_BlendSmooth2"), "Edge Blend Strength");
				matEditor.RangeProperty (getProperty ("_HeightBasedTransparency2"), "Height-Based Transparency");


			}

		}

		showWetnessGreen = EditorGUILayout.Foldout (showWetnessGreen, "Wetness Settings");

		if (showWetnessGreen) {

			matEditor.ColorProperty (getProperty ("_wetnessAlbedoModifier2"), "Albedo Modifier");
			matEditor.RangeProperty (getProperty ("_wetnessSmoothnessModifier2"), "Smoothness Modifier");
			matEditor.RangeProperty (getProperty ("_wetnessNormalModifier2"), "Normal Modifier");


		}




	}

	void guiForBlueChannel() {

		showBlueChannel = targetMat.GetFloat("_showBlue") == 1;
		showBlueChannel = EditorGUILayout.Foldout(showBlueChannel, "Blue Channel Settings");
		targetMat.SetFloat ("_showBlue", showBlueChannel ? 1f : 0f );

		if (!showBlueChannel)
			return;

		matEditor.TextureProperty (getProperty ("_MainTex3"), "Albedo Map");
		//getProperty ("_MainTex").textureScaleAndOffset;
		matEditor.RangeProperty (getProperty ("_Metallic3"), "Metallic Strength");

		matEditor.TextureProperty (getProperty ("_BumpMap3"), "Bump Map");
		matEditor.TextureProperty (getProperty ("_CombinedMap3"), "Combined Map");

		matEditor.RangeProperty (getProperty ("_Smoothness3"), "Smoothness Strength");
		matEditor.RangeProperty (getProperty ("_Occlusion3"), "Occlusion Strength Strength");


		matEditor.RangeProperty ( getProperty ("_Emission3"), "Emission Strength");
		matEditor.ColorProperty ( getProperty ("_EmissionColor3"), "Emission Color");

		if (useParallax) {

			showParallaxBlue = EditorGUILayout.Foldout (showParallaxBlue, "Parallax Settings");

			if (showParallaxBlue) {

				matEditor.RangeProperty (getProperty ("_Parallax3"), "Parallax Strength");

				useParallaxOfR3 = targetMat.GetFloat("_useP1_3") == 1;
				useParallaxOfR3 = EditorGUILayout.Toggle ("Use Base Heightmap", useParallaxOfR3);
				targetMat.SetFloat ("_useP1_3", useParallaxOfR3 ? 1f : 0f );

			}

		}



		if (useHeightbasedBlending) {

			showHeightBasedBlue = EditorGUILayout.Foldout (showHeightBasedBlue, "Heightbased Blending Settings");

			if (showHeightBasedBlue) {

				matEditor.RangeProperty (getProperty ("_BaseHeight3"), "Base Height of Layer");
				matEditor.RangeProperty (getProperty ("_HeightmapFactor3"), "HeightMap Multiplier");
				matEditor.RangeProperty (getProperty ("_BlendSmooth3"), "Edge Blend Strength");
				matEditor.RangeProperty (getProperty ("_HeightBasedTransparency3"), "Height-Based Transparency");


			}

		}

		showWetnessBlue = EditorGUILayout.Foldout (showWetnessBlue, "Wetness Settings");

		if (showWetnessBlue) {

			matEditor.ColorProperty (getProperty ("_wetnessAlbedoModifier3"), "Albedo Modifier");
			matEditor.RangeProperty (getProperty ("_wetnessSmoothnessModifier3"), "Smoothness Modifier");
			matEditor.RangeProperty (getProperty ("_wetnessNormalModifier3"), "Normal Modifier");


		}

	

	}



	void guiForGeneral() {

		showGeneralSettings = targetMat.GetFloat("_showGeneral") == 1;
		showGeneralSettings = EditorGUILayout.Foldout(showGeneralSettings, "General Settings");
		targetMat.SetFloat ("_showGeneral", showGeneralSettings ? 1f : 0f );

		useHeightbasedBlending = targetMat.GetFloat("_useHeightBasedBlending") == 1;

		if (!showGeneralSettings)
			return;

		useHeightbasedBlending = EditorGUILayout.Toggle ("Heightbased Blending", useHeightbasedBlending);
		targetMat.SetFloat ("_useHeightBasedBlending", useHeightbasedBlending ? 1f : 0f );

		matEditor.RangeProperty (getProperty ("_wetnessEdgeBlend"), "Wetness Edge Blend");




	}

	void guiForParallax() {

	
		showParallaxSetting = targetMat.GetFloat("_showParallax") == 1;
		showParallaxSetting = EditorGUILayout.Foldout(showParallaxSetting, "Parallax Settings");
		targetMat.SetFloat ("_showParallax", showParallaxSetting ? 1f : 0f );

		useParallax = targetMat.GetFloat("_useParallax") == 1;

		if (!showParallaxSetting)
			return;

		useParallax = EditorGUILayout.Toggle ("Use Parallax", useParallax);
		targetMat.SetFloat ("_useParallax", useParallax ? 1f : 0f );


		if (!useParallax)
			return;

		EditorGUILayout.BeginHorizontal ();
		{
			parallaxInterpolation = targetMat.GetInt ("_ParallaxInterpolation");
			EditorGUILayout.LabelField ("Parallax interpolations", GUILayout.Width (150));
			parallaxInterpolation = EditorGUILayout.IntSlider (parallaxInterpolation, 5, 100);
			targetMat.SetInt ("_ParallaxInterpolation", parallaxInterpolation);
		}
		EditorGUILayout.EndHorizontal ();

		useDepthBias = targetMat.GetFloat("_useDepthBias") == 1;
		useDepthBias = EditorGUILayout.Toggle ("Use depth bias", useDepthBias);
		targetMat.SetFloat ("_useDepthBias", useDepthBias ? 1f : 0f );

		if (!useDepthBias)
			return;


		depthBiasDistance = targetMat.GetFloat ("_DepthBias");
		depthBiasDistance = EditorGUILayout.FloatField ("Depth-Bias Distance", depthBiasDistance);
		targetMat.SetFloat ("_DepthBias", depthBiasDistance);


		depthBiasPower = targetMat.GetFloat ("_DepthBiasPower");
		depthBiasPower = EditorGUILayout.FloatField ("Depth-Bias Power", depthBiasPower);
		targetMat.SetFloat ("_DepthBiasPower", depthBiasPower);

		depthBiasThreshold = targetMat.GetFloat ("_DepthBiasThreshold");
		depthBiasThreshold = EditorGUILayout.FloatField ("Depth-Bias Threshold", depthBiasThreshold);
		targetMat.SetFloat ("_DepthBiasThreshold", depthBiasThreshold);


	}


	void generateStyles() {

		bool hasPro = UnityEditorInternal.InternalEditorUtility.HasPro ();

		redChannelGUIStyle = new GUIStyle ();
		if( !hasPro )
			redChannelGUIStyle.normal.background = (Texture2D)Resources.Load ("Textures/redChannelBG");
		else
			redChannelGUIStyle.normal.background = (Texture2D)Resources.Load ("Textures/redChannelBGPro");
		//redChannelGUIStyle.margin = new RectOffset (0, 0, 0, 0);
		redChannelGUIStyle.padding = new RectOffset (12, 0, 0, 0);


		greenChannelGUIStyle = new GUIStyle ();
		if( !hasPro )
			greenChannelGUIStyle.normal.background = (Texture2D)Resources.Load ("Textures/greenChannelBG");
		else
			greenChannelGUIStyle.normal.background = (Texture2D)Resources.Load ("Textures/greenChannelBGPro");
		//greenChannelGUIStyle.margin = new RectOffset (0, 0, 0, 0);
		greenChannelGUIStyle.padding = new RectOffset (12, 0, 0, 0);

		blueChannelGUIStyle = new GUIStyle ();
		if( !hasPro )
			blueChannelGUIStyle.normal.background = (Texture2D)Resources.Load ("Textures/blueChannelBG");
		else
			blueChannelGUIStyle.normal.background = (Texture2D)Resources.Load ("Textures/blueChannelBGPro");
		//blueChannelGUIStyle.margin = new RectOffset (0, 0, 0, 0);
		blueChannelGUIStyle.padding = new RectOffset (12, 0, 0, 0);


		neutralGUIStyle = new GUIStyle ();
		if( !hasPro )
			neutralGUIStyle.normal.background = (Texture2D)Resources.Load ("Textures/neutralBG");
		else 
			neutralGUIStyle.normal.background = (Texture2D)Resources.Load ("Textures/neutralBGPro");
		//neutralGUIStyle.margin = new RectOffset (0, 0, 0, 0);
		neutralGUIStyle.padding = new RectOffset (12, 0, 0, 0);

		headerBoxStyle = new GUIStyle ();
		headerBoxStyle.normal.background = (Texture2D)Resources.Load ("Textures/box_bg");
		headerBoxStyle.normal.textColor = Color.black;
		headerBoxStyle.fontSize = 20;
		headerBoxStyle.alignment = TextAnchor.MiddleCenter;
		headerBoxStyle.border = new RectOffset (3, 3, 3, 3);
		headerBoxStyle.margin = new RectOffset (0, 0, 0, 0);

		bodyH1Style = new GUIStyle ();
		bodyH1Style.normal.background = (Texture2D)Resources.Load ("Textures/box_bg");
		bodyH1Style.normal.textColor = Color.black;
		bodyH1Style.fontSize = 14;
		bodyH1Style.alignment = TextAnchor.MiddleCenter;
		bodyH1Style.border = new RectOffset (3, 3, 3, 3);
		bodyH1Style.margin = new RectOffset (60, 3, 3, 3);

		bodyH2Style = new GUIStyle ();
		bodyH2Style.normal.background = (Texture2D)Resources.Load ("Textures/box_bg");
		bodyH2Style.normal.textColor = Color.black;
		bodyH2Style.fontSize = 13;
		bodyH2Style.alignment = TextAnchor.MiddleCenter;
		bodyH2Style.border = new RectOffset (5, 5, 5, 5);
		bodyH2Style.margin = new RectOffset (5, 5, 5, 5);

	}

}
