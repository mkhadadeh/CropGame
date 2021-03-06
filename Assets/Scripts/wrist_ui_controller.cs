﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrist_ui_controller : MonoBehaviour {

    public GameObject WristDisplay;
    public player_inventory_values PlayerVals;
    public player_data_scr PlayerHoldingVals;
    public controller_scr GameControl;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
        if(CheckRayCollision())
            WristDisplay.SetActive(true);
        else
            WristDisplay.SetActive(false);

        UpdateValues();
	}

    bool CheckRayCollision()
    {
        RaycastHit hit;
        bool RayPermission = false;
        Vector3 WristPosition = transform.TransformDirection(Vector3.right);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 100, Color.yellow);
        if (Physics.Raycast(transform.position, WristPosition, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Player")
            {
                //Debug.Log("Open Menu!");
                RayPermission = true;
            }
        }
        return RayPermission;

    }

    void UpdateValues()
    {
        for (int i = 1; i < 6; i++)
        {
            UnityEngine.UI.Text BtnText;
            BtnText = transform.GetChild(0).GetChild(0).GetChild(i).gameObject.GetComponentInChildren<UnityEngine.UI.Text>();
            BtnText.text = PlayerVals.AmountOfItems[i - 1].ToString();
        }
        transform.GetChild(0).GetChild(0).GetChild(6).gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text  = PlayerVals.MoneyReserve.ToString();
        transform.GetChild(0).GetChild(0).GetChild(16).gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = "Day: " + (GameControl.current_day + 1).ToString() + "/" + controller_scr.MAX_DAYS.ToString();

    }

    public void ButtonPress(int button)
    {
      //Debug.Log("1");
      // If the player is holding an item, return it to the inventory.
      if(PlayerHoldingVals.holding_state != player_data_scr.State.NOTHING) {
        //Debug.Log("2");
        if(PlayerHoldingVals.holding_state == player_data_scr.State.FERTILIZER) {
          //Debug.Log("3");
          PlayerVals.AmountOfItems[PlayerHoldingVals.fertilizer + 2]++;
        }
        else{
          //Debug.Log("4");
          PlayerVals.AmountOfItems[PlayerHoldingVals.seed_type - 1]++;
        }
        PlayerHoldingVals.holding_state = player_data_scr.State.NOTHING;
      }
      if(PlayerVals.AmountOfItems[button] > 0) {
        //Debug.Log("5");
        // Hold the new item if you have it
        if(button > 2) {
          //Debug.Log("6");
          // Hold Fertilizer
          PlayerHoldingVals.holding_state = player_data_scr.State.FERTILIZER;
          PlayerHoldingVals.fertilizer = button - 2;
        }
        else {
          //Debug.Log("7s");
          // Hold plant
          PlayerHoldingVals.holding_state = player_data_scr.State.SEED;
          PlayerHoldingVals.seed_type = button + 1;
        }
        PlayerVals.AmountOfItems[button]--;
      }
    }

}
