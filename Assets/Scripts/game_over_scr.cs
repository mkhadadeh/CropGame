using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_over_scr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Money Made: $" + controller_scr.money.ToString();
        if(controller_scr.money >= 10000)
        {
            transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>().text = "You Win!";
        }
        else
        {
            transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>().text = "You Lose!"; ;
        }
	}

	// Update is called once per frame
	void Update () {

	}

	public void Menu() {
		SceneManager.LoadScene("MainMenu");
	}
}
