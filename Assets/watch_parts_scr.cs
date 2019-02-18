using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watch_parts_scr : MonoBehaviour {
    public Transform[] watch_points;
    public Transform[] UI_points;
    public LineRenderer[] line_renderers;
    public GameObject WristUI;
    public GameObject spotlight;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (WristUI.activeSelf)
        {
            if (!line_renderers[0].gameObject.activeSelf)
            {
                for (int i = 0; i < 4; i++)
                {
                    line_renderers[i].gameObject.SetActive(true);
                }
                spotlight.SetActive(true);
            }
            for (int i = 0; i < 4; i++)
            {
                line_renderers[i].SetPosition(0, watch_points[i].position);
                line_renderers[i].SetPosition(1, UI_points[i].position);
            }
        }
        else
        {
            if (line_renderers[0].gameObject.activeSelf)
            {
                for (int i = 0; i < 4; i++)
                {
                    line_renderers[i].gameObject.SetActive(false);
                }
                spotlight.SetActive(false);
            }
            
        }
	}
}
