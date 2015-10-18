﻿using UnityEngine;
using System.Collections;

public class UIFilter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int ManualWidth = 960;
		int ManualHeight = 640;
		int manualHeight;
		if (System.Convert.ToSingle(Screen.height) / Screen.width > System.Convert.ToSingle(ManualHeight) / ManualWidth)
			manualHeight = Mathf.RoundToInt(System.Convert.ToSingle(ManualWidth) / Screen.width * Screen.height);
		else
			manualHeight = ManualHeight;
		Camera camera = GetComponent<Camera>();
		float scale =System.Convert.ToSingle(manualHeight / 640f);
		camera.fieldOfView*= scale;
	}

	void OnGUI()
	{
		GUILayout.Label("screen  Wid = "+ Screen.width +"  Height= "+ Screen.height);
	}

}