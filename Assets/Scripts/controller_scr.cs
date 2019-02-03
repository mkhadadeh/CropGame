using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller_scr : MonoBehaviour {
	public static int money;
	public enum GameState {IN_GAME, IN_FADE, END};
	GameState current_state;

	public GameObject PlotController;
	public enum RobotEvents {ROTATION_DEMAND, RIVER_MALFUNCTION, SHOP_SALE, A_FERT_PRICE_UP, TAX};
	int plant_demand;
	public enum TaxType {ALL_CROPS_LESS, ALL_SEEDS_MORE, ALL_FERTILIZERS_MORE};
	public Transform LifeEventUI;
	RobotEvents current_event;
	public Transform wrist_ui;

	bool wrist_ui_open;
	public bool life_events_open;

	const int MAX_DAYS = 20;
	int current_day;

	// Use this for initialization
	void Start () {
		money = 0;
		current_day = 0;
		current_state = GameState.IN_GAME;
		life_events_open = false;
		wrist_ui_open = false;
		current_event = (RobotEvents)Random.Range(0,5);
	}

	// Update is called once per frame
	void Update () {
		if(current_state == GameState.IN_GAME) {
			wrist_ui_open = wrist_ui.gameObject.activeSelf;
			if(wrist_ui_open && life_events_open) {
				wrist_ui.GetChild(0).GetChild(0).gameObject.SetActive(false);
				for(int i = 1; i < 6; i++) {
					if(i == (int)current_event + 1) {
						if(!LifeEventUI.GetChild(i).gameObject.activeSelf)
						LifeEventUI.GetChild(i).gameObject.SetActive(true);
					}	else {
						if(LifeEventUI.GetChild(i).gameObject.activeSelf) {
							LifeEventUI.GetChild(i).gameObject.SetActive(false);
						}
					 }
				}
			}
			if(wrist_ui_open && !life_events_open) {
				wrist_ui.GetChild(0).GetChild(0).gameObject.SetActive(true);
			}
		}
	}

	public void NextDay() {
		if(current_state == GameState.IN_GAME) {
			for(int i = 0; i < PlotController.transform.childCount; i++) {
				PlotController.transform.GetChild(i).GetComponent<plot_scr>().Grow();
			}
			current_event = (RobotEvents)Random.Range(0,5);
			current_day++;
			if(current_day == MAX_DAYS) {
				current_state = GameState.END;
				GameOver();
			}
			current_state = GameState.IN_FADE;
			Fade();
		}
	}
	public void LE_Open_Button() {
		life_events_open = true;
	}
	public void LE_Close_Button() {
		life_events_open = false;
	}

	void Fade() {
		//TODO: Implement Fading
		current_state = GameState.IN_GAME;
	}

	public void GameOver() {
		SceneManager.LoadScene("GameOver");
	}
}
