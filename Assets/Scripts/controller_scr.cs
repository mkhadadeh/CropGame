﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_scr : MonoBehaviour {
	public GameObject PlotController;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void NextDay() {
		Debug.Log("Next!");
		for(int i = 0; i < PlotController.transform.childCount; i++) {
			PlotController.transform.GetChild(i).GetComponent<plot_scr>().Grow();
		}
	}
}