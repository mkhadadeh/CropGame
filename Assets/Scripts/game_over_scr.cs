using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_over_scr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Score: " + controller_scr.money.ToString();
	}

	// Update is called once per frame
	void Update () {

	}

	public void Menu() {
		SceneManager.LoadScene("MainMenu");
	}
}
