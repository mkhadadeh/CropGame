using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_scr : MonoBehaviour {
	public GameObject PlotController;
	public enum RobotEvents {ROTATION_DEMAND, RIVER_MALFUNCTION, SHOP_SALE, A_FERT_PRICE_UP, TAX};
	int plant_demand;
	public enum TaxType {ALL_CROPS_LESS, ALL_SEEDS_MORE, ALL_FERTILIZERS_MORE};
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void NextDay() {
		for(int i = 0; i < PlotController.transform.childCount; i++) {
			PlotController.transform.GetChild(i).GetComponent<plot_scr>().Grow();
		}
	}
}
