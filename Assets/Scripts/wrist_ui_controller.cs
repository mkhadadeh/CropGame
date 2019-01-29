using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrist_ui_controller : MonoBehaviour {

    public GameObject WristDisplay;
    private float RotationCondition = 45;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(CheckRayCollision())
            WristDisplay.SetActive(true);
        else
            WristDisplay.SetActive(false);
	}

    bool CheckRayCollision()
    {
        bool RayPermission = false;
        Vector3 WristPosition = transform.TransformDirection(Vector3.right);
        Debug.DrawLine(transform.position, transform.position + WristPosition);
        if (Physics.Raycast(transform.position, WristPosition, 1, 9))
        {
            Debug.Log("Open Menu!");
            RayPermission = true;
        }
        return RayPermission;
       
    }
}
