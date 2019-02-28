using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tooltip_scr : MonoBehaviour {
    public Transform pointer;
    public Transform playerEye;
    public Transform[] tooltipAnchors;
    public Transform[] riverTooltips;
    int show;
	// Use this for initialization
	void Start () {
        show = -1;
	}
	
	// Update is called once per frame
	void Update () {
        // Tooltips move
        /*
        transform.position = ((pointer.position - playerEye.position) * 0.8f) + playerEye.position;
        Vector3 eulerRotation = new Vector3(pointer.transform.eulerAngles.x, pointer.transform.eulerAngles.y, pointer.transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(eulerRotation);
        */
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
        riverTooltips[0].position = tooltipAnchors[0].position;
        Vector3 eulerRotation = new Vector3(tooltipAnchors[0].eulerAngles.x, tooltipAnchors[0].eulerAngles.y, tooltipAnchors[0].eulerAngles.z);
        riverTooltips[0].rotation = Quaternion.Euler(eulerRotation);

        riverTooltips[1].position = tooltipAnchors[1].position;
        Vector3 eulerRotation2 = new Vector3(tooltipAnchors[1].eulerAngles.x, tooltipAnchors[1].eulerAngles.y, tooltipAnchors[1].eulerAngles.z);
        riverTooltips[1].rotation = Quaternion.Euler(eulerRotation2);
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
