using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_data_scr : MonoBehaviour {
	public enum State {SEED, NOTHING, FERTILIZER};
	public State holding_state;
	public int seed_type; // Plants 1,2,3 and 0 means no plant
	public int fertilizer; // 0 for no fertilizer, 1 for natural, 2 for artificial
	// Use this for initialization
	void Start () {
		holding_state = State.NOTHING;
		seed_type = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	public void Harvested(int code) {
		Debug.Log(code);
		switch(code) {
			case 10:
			case 20:
			case 30:
			//Get plant's worth of money
				break;
			case 1:
			case 2:
			case 3:
			//Get seed of type plant
				break;
			default:
				break;
		}
	}
}
