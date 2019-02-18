using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tooltip_scr : MonoBehaviour {
    public Transform pointer;
    public Transform playerEye;
    int show;
	// Use this for initialization
	void Start () {
        show = -1;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = ((pointer.position - playerEye.position) * 0.8f) + playerEye.position;
        Vector3 eulerRotation = new Vector3(pointer.transform.eulerAngles.x, pointer.transform.eulerAngles.y, pointer.transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(eulerRotation);
        if (show == -1)
        {
            for (int i = 0; i < 7; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else
        {
            transform.GetChild(show).gameObject.SetActive(true);
        }
    }

    public void ShowTip(int i)
    {
        show = i;
    }
    public void HideTips()
    {
        show = -1;
    }
}
