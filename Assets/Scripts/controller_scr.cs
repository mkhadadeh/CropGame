using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_scr : MonoBehaviour {
	public GameObject PlotController;
	public enum RobotEvents {ROTATION_DEMAND, RIVER_MALFUNCTION, SHOP_SALE, A_FERT_PRICE_UP, TAX};
	int plant_demand;
	public enum TaxType {ALL_CROPS_LESS, ALL_SEEDS_MORE, ALL_FERTILIZERS_MORE};
	public Transform LifeEventUI;
	RobotEvents current_event;
	public Transform wrist_ui;

	bool wrist_ui_open;
	public bool life_events_open;
	// Use this for initialization
	void Start () {
		life_events_open = false;
		wrist_ui_open = false;
		current_event = (RobotEvents)Random.Range(0,5);
	}

	// Update is called once per frame
	void Update () {
		wrist_ui_open = wrist_ui.gameObject.activeSelf;
		if(wrist_ui_open && life_events_open) {
			wrist_ui.GetChild(0).GetChild(0).gameObject.SetActive(false);
			for(int i = 1; i < 6; i++) {
				if(i == (int)current_event + 1) {
					if(!LifeEventUI.GetChild(i).gameObject.activeSelf)
					LifeEventUI.GetChild(i).gameObject.SetActive(true);
				}	else {
					if(LifeEventUI.GetChild(i).gameObject.activeSelf) {
						LifeEventUI.GetChild(i).gameObject.SetActive(false);
					}
				 }
			}
		}
		if(wrist_ui_open && !life_events_open) {
			wrist_ui.GetChild(0).GetChild(0).gameObject.SetActive(true);
		}
	}

	public void NextDay() {
		for(int i = 0; i < PlotController.transform.childCount; i++) {
			PlotController.transform.GetChild(i).GetComponent<plot_scr>().Grow();
		}
		current_event = (RobotEvents)Random.Range(0,5);
	}
	public void LE_Open_Button() {
		life_events_open = true;
	}
	public void LE_Close_Button() {
		life_events_open = false;
	}
}
