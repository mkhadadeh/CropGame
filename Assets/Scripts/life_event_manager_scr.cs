using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_event_manager_scr : MonoBehaviour {
	public enum RobotEvents {ROTATION_DEMAND, RIVER_MALFUNCTION, SHOP_SALE, A_FERT_PRICE_UP, TAX};
	public enum TaxType {ALL_CROPS_LESS, ALL_SEEDS_MORE};

	public RobotEvents current_event;
	public TaxType tax;
	public int plant_demand;

	public Transform LifeEventUI;
	public Transform wrist_ui;
	public player_inventory_values player_vals;

	public int river_button_pressed;
	public bool river_problem_solved;
	public int cost_for_m3sg = 300;

    string[] plantNames;

	public controller_scr GameController;

	// Use this for initialization
	void Start () {
		river_button_pressed = 0;
		river_problem_solved = true;
        plantNames = new string[3];
        plantNames[0] = "Gloob Vine";
        plantNames[1] = "Kwoz Fruit Tree";
        plantNames[2] = "Potato";
    }

	// Update is called once per frame
	void Update () {

	}

	public void ShowEvent() {
		wrist_ui.GetChild(0).GetChild(0).gameObject.SetActive(false);
		for(int i = 1; i < 6; i++) {
			if(i == (int)current_event + 1) {
				if(!LifeEventUI.GetChild(i).gameObject.activeSelf || current_event == RobotEvents.RIVER_MALFUNCTION){
					if(i == 1) {
						LifeEventUI.GetChild(i).GetChild(2).GetComponent<UnityEngine.UI.Text>().text = "Plant in demand: " + plantNames[plant_demand-1].ToString();
					}
					if(i == 2) {
						LifeEventUI.GetChild(i).gameObject.SetActive(true);
						for(int j = 0; j < 3; j++) {
							if(j == river_button_pressed) {
								LifeEventUI.GetChild(i).GetChild(j).gameObject.SetActive(true);
							}
							else {
								LifeEventUI.GetChild(i).GetChild(j).gameObject.SetActive(false);
							}
						}
					}
					if(i == 5) {
						LifeEventUI.GetChild(i).GetChild(2).GetComponent<UnityEngine.UI.Text>().text = "The tax is on: " + (tax == TaxType.ALL_CROPS_LESS ? "Harvest sales":"Crop prices");
					}
					LifeEventUI.GetChild(i).gameObject.SetActive(true);
				}
			}	else {
				if(LifeEventUI.GetChild(i).gameObject.activeSelf) {
					LifeEventUI.GetChild(i).gameObject.SetActive(false);
				}
			 }
		}
	}
	public void SelectEvent() {
		if(GameController.artificial_fertilizer_uses < 3) {
			current_event = (RobotEvents)Random.Range(0,4);
			if(current_event == RobotEvents.A_FERT_PRICE_UP) {
				current_event = (RobotEvents) ((int)current_event + 1);
			}
		}
		else {
			current_event = (RobotEvents)Random.Range(0,5);
		}
		if(current_event == RobotEvents.TAX) {
			tax = (TaxType)Random.Range(0,2);
		}
		if(current_event == RobotEvents.RIVER_MALFUNCTION) {
			river_button_pressed = 0;
			river_problem_solved = false;
		}
		if(current_event == RobotEvents.ROTATION_DEMAND) {
			plant_demand = Random.Range(1,4);
		}
	}
	public void ButtonPress(int i) {
		Debug.Log(i);
		if(i == 2 && player_vals.MoneyReserve >= cost_for_m3sg) {
			player_vals.MoneyReserve -= cost_for_m3sg;
			river_button_pressed = i;
			river_problem_solved = true;
		}
		else {
			river_button_pressed = i;
			river_problem_solved = false;
		}
	}
}
