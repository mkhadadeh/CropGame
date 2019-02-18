using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning_scr : MonoBehaviour {
    public GameObject warningIcon;
    private void Update()
    {
        byte[] shake = { 255 };
        OVRHaptics.Channels[0].Preempt(new OVRHapticsClip(shake, 1));
    }

    private void OnEnable()
    {
        warningIcon.SetActive(true);
    }
    private void OnDisable()
    {
        warningIcon.SetActive(false);
    }
}
