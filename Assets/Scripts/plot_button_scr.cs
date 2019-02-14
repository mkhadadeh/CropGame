using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plot_button_scr : MonoBehaviour {
	public GameObject playerObj;
	plot_scr plot;
	// Use this for initialization
	void Start () {
		//playerObj = GameObject.FindGameObjectWithTag("Player");
		plot = GetComponent<plot_scr>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPress() {
		var playerScr = playerObj.GetComponent<player_data_scr>();

		if(playerScr.holding_state == player_data_scr.State.SEED) {
			if(plot.Plant(playerScr.seed_type)) {
				playerScr.seed_type = 0;
				playerScr.holding_state = player_data_scr.State.NOTHING;
			}
		}
		else if(playerScr.holding_state == player_data_scr.State.FERTILIZER) {
			if(playerScr.fertilizer != 0) {
					plot.Fertilize(playerScr.fertilizer == 1 ? false : true);
			}
			playerScr.holding_state = player_data_scr.State.NOTHING;
			playerScr.fertilizer = 0;
		}
		else {
			// TODO: Implement harvesting
			int type = plot.Harvest();
            if(type >= 10)
            {
                var coin_parts = Resources.Load("CoinExplosion");
                Instantiate(coin_parts, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
			playerScr.Harvested(type);
		}
	}
}
