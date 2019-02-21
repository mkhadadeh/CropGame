using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_scr : MonoBehaviour {

    public AudioSource intro;
    bool play;
	// Use this for initialization
	void Start () {
        play = false;
	}

	// Update is called once per frame
	void Update () {
        if(play && !intro.isPlaying)
        {
            play = false;
            SceneManager.LoadScene("MainScene");
        }
	}

	public void PlayGame() {
        if (play == false)
        {
            intro.Play();
            play = true;
        }
        else
        {
            intro.Stop();
        }
	}
    public void QuitGame()
    {
        Application.Quit();
    }

}
