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
        var playerInv = playerObj.GetComponent<player_inventory_values>();

		if(playerScr.holding_state == player_data_scr.State.SEED) {
			if(plot.Plant(playerScr.seed_type)) {
                if (!(playerInv.AmountOfItems[playerScr.seed_type - 1] > 0)) {
                    playerScr.seed_type = 0;
                    playerScr.holding_state = player_data_scr.State.NOTHING;
                }
                else
                {
                    playerInv.AmountOfItems[playerScr.seed_type - 1]--;
                }
			}
		}
		else if(playerScr.holding_state == player_data_scr.State.FERTILIZER) {
			if(playerScr.fertilizer != 0) {
				plot.Fertilize(playerScr.fertilizer == 1 ? false : true);
                if (playerScr.fertilizer == 2) playerScr.AFertParts.GetComponent<art_fert_scr>().Spray();
                
            }
            if (!(playerInv.AmountOfItems[playerScr.fertilizer + 2] > 0)) {
                playerScr.holding_state = player_data_scr.State.NOTHING;
                playerScr.fertilizer = 0;
            }
            else
            {
                playerInv.AmountOfItems[playerScr.fertilizer + 2]--;
            }
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
