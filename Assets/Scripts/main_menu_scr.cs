using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_scr : MonoBehaviour {

    public AudioSource intro;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
        
	}

	public void PlayGame() {
        SceneManager.LoadScene("MainScene");
    }

    public void Hear()
    {
        intro.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
