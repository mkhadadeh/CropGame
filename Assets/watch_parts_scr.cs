using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watch_parts_scr : MonoBehaviour {
    public Transform[] points;
    public LineRenderer[] line_renderers;
    Vector3[] positions;
	// Use this for initialization
	void Start () {
        positions = new Vector3[8];
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 8; i++)
        {
            positions[i] = points[i].position;
        }
        Debug.Log(positions);
        line_renderers[0].SetPositions(positions);
	}
}
