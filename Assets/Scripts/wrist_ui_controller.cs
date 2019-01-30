using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrist_ui_controller : MonoBehaviour {

    public GameObject WristDisplay;
    public player_inventory_values PlayerVals;

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
        bool RayPermission = false;
        Vector3 WristPosition = transform.TransformDirection(Vector3.right);
        Debug.DrawLine(transform.position, transform.position + WristPosition);
        if (Physics.Raycast(transform.position, WristPosition, 1, 9))
        {
            //Debug.Log("Open Menu!");
            RayPermission = true;
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
            Debug.Log(BtnText.text);
        }
    }

    public void ButtonPress(int button)
    {

    }

}
