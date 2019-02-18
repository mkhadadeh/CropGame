using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tooltip_scr : MonoBehaviour {

    int show;
	// Use this for initialization
	void Start () {
        show = -1;
	}
	
	// Update is called once per frame
	void Update () {
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
            Debug.Log(transform.GetChild(show).gameObject);
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
