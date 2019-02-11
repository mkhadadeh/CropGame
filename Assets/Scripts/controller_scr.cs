using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller_scr : MonoBehaviour {
	public static int money;
	public enum GameState {IN_GAME, IN_FADE, END};
	GameState current_state;
	public GameObject PlotController;

	public int artificial_fertilizer_uses;

	public Transform LifeEventUI;
	public Transform wrist_ui;

	public life_event_manager_scr LE_manager;

	bool wrist_ui_open;
	public bool life_events_open;

	const int MAX_DAYS = 20;
	int current_day;

	bool dontGrow;

	// Use this for initialization
	void Start () {
		money = 0;
		current_day = 0;
		current_state = GameState.IN_GAME;
		life_events_open = false;
		wrist_ui_open = false;
		dontGrow = false;
		artificial_fertilizer_uses = 0;
		LE_manager.SelectEvent();
	}

	// Update is called once per frame
	void Update () {
		if(current_state == GameState.IN_GAME) {
			wrist_ui_open = wrist_ui.gameObject.activeSelf;
			//Open up life events UI
			if(wrist_ui_open && life_events_open) {
				LE_manager.ShowEvent();
			}
			// Open up inventory UI
			if(wrist_ui_open && !life_events_open) {
				wrist_ui.GetChild(0).GetChild(0).gameObject.SetActive(true);
				for(int i = 1; i < 6; i++) {
						LifeEventUI.GetChild(i).gameObject.SetActive(false);
				}
			}
		}
	}

	public void NextDay() {
		if(current_state == GameState.IN_GAME) {
			if(LE_manager.river_problem_solved == false) {
				dontGrow = true;
				LE_manager.river_problem_solved = true;
			}
			for(int i = 0; i < PlotController.transform.childCount; i++) {
				if(!dontGrow) {
					PlotController.transform.GetChild(i).GetComponent<plot_scr>().Grow();
				}
				if(PlotController.transform.GetChild(i).GetComponent<plot_scr>().art_fert_used) {
					PlotController.transform.GetChild(i).GetComponent<plot_scr>().art_fert_used = false;
					artificial_fertilizer_uses += 1;
				}
			}
			dontGrow = false;
			LE_manager.SelectEvent();
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
