using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_data_scr : MonoBehaviour {
	public enum State {SEED, NOTHING, FERTILIZER};
	public State holding_state;
	public int seed_type; // Plants 1,2,3 and 0 means no plant
	public int fertilizer; // 0 for no fertilizer, 1 for natural, 2 for artificial
	public player_inventory_values vals;
	public life_event_manager_scr LE_Control;

	float tax = 0.6f;
	float demand = 1.6f;
	// Use this for initialization
	void Start () {
		holding_state = State.NOTHING;
		seed_type = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	public void Harvested(int code) {
		switch(code) {
			case 10:
			case 20:
			case 30:
			vals.MoneyReserve += (2 + (code >= 20 ? 1 : 0)) * 100 * ((LE_Control.current_event == life_event_manager_scr.RobotEvents.TAX) && (LE_Control.tax == life_event_manager_scr.TaxType.ALL_CROPS_LESS) ? tax : 1) * ((LE_Control.current_event == life_event_manager_scr.RobotEvents.ROTATION_DEMAND) && (LE_Control.plant_demand == code/10) ? demand : 1);
			//Get plant's worth of money
				break;
			case 1:
			case 2:
			case 3:
			vals.AmountOfItems[code - 1]++;
			//Get seed of type plant
				break;
			default:
				break;
		}
	}
}
