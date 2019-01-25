using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plot_button_scr : MonoBehaviour {
	Public GameObject playerObj;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPress() {
		var playerScr = playerObj.GetComponent<Player_data_scr>();
		if(playerScr.holding_state == playerScr.State.SEED) {
			// TODO: Implement planting
		}
		else if(playerScr.holding_state == playerScr.State.FERTILIZER) {
			// TODO: Implement fertilizition
		}
		else {
			// TODO: Implement harvesting
		}
	}

}
