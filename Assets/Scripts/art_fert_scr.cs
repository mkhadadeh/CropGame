using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class art_fert_scr : MonoBehaviour {
    ParticleSystem parts;
    public GameObject outputPt;
    AudioSource sound;
	// Use this for initialization
	void Start () {
        parts = GetComponent<ParticleSystem>();
        parts.Stop();
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
     
    }
    public void Spray()
    {
        transform.position = outputPt.transform.position;
        Vector3 eulerRotation = new Vector3(outputPt.transform.eulerAngles.x + 180, outputPt.transform.eulerAngles.y, outputPt.transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(eulerRotation);
        parts.Play();
        sound.Play();
    }
}
