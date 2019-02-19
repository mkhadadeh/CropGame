using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller_scr : MonoBehaviour {
	public static int money;
    public static int money_to_win;
	public enum GameState {IN_GAME, IN_FADE, END};
	GameState current_state;
	public GameObject PlotController;

	public int artificial_fertilizer_uses;

	public Transform LifeEventUI;
	public Transform wrist_ui;

	public life_event_manager_scr LE_manager;

	public bool wrist_ui_open;
	public bool life_events_open;

	public const int MAX_DAYS = 20;
	public int current_day;

    public GameObject FadePlane;
    float fade_val;
    bool faded;
	bool dontGrow;

    bool life_events_seen;
    public GameObject Warning_parts;
    public GameObject cursor;

    public AudioSource[] LifeEventScripts;

	// Use this for initialization
	void Start () {
        life_events_seen = false;
        money = 0;
        money_to_win = 15000;
		current_day = 0;
		current_state = GameState.IN_GAME;
		life_events_open = false;
		wrist_ui_open = false;
		dontGrow = false;
		artificial_fertilizer_uses = 0;
        fade_val = 0;
		LE_manager.SelectEvent();
        faded = false;
	}

	// Update is called once per frame
	void Update () {
        cursor.SetActive(true);
        if(!life_events_seen)
        {
            Warning_parts.SetActive(true);
        }
        else
        {
            Warning_parts.SetActive(false);
        }
		if(current_state == GameState.IN_GAME) {
            wrist_ui_open = wrist_ui.GetChild(0).gameObject.activeSelf;
			//Open up life events UI
			if(wrist_ui_open && life_events_open) {
                wrist_ui.GetChild(0).GetChild(0).gameObject.SetActive(false);
                wrist_ui.GetChild(0).GetChild(1).gameObject.SetActive(true);
                LE_manager.ShowEvent();
			}
			// Open up inventory UI
			if(wrist_ui_open && !life_events_open) {
				wrist_ui.GetChild(0).GetChild(0).gameObject.SetActive(true);
                wrist_ui.GetChild(0).GetChild(1).gameObject.SetActive(false);
                for (int i = 1; i < 6; i++) {
						LifeEventUI.GetChild(i).gameObject.SetActive(false);
				}
			}
		}
        else if(current_state == GameState.IN_FADE)
        {
            cursor.SetActive(false);
            if(fade_val < 3.0f && !faded)
            {
                Debug.Log("Stage1");
                FadePlane.SetActive(true);
                fade_val += Time.deltaTime;
                var alphaColor = FadePlane.GetComponent<MeshRenderer>().material.color;
                alphaColor.a = 1.0f;
                FadePlane.GetComponent<MeshRenderer>().material.color = Color.Lerp(FadePlane.GetComponent<MeshRenderer>().material.color, alphaColor, 1.0f * Time.deltaTime);
            }
            else if (fade_val >= 3.0f && !faded)
            {
                Debug.Log("Stage2");
                faded = true;
            }
            else if(fade_val > 0f && faded)
            {
                fade_val -= Time.deltaTime;
                Debug.Log("Stage3");
                var alphaColor = FadePlane.GetComponent<MeshRenderer>().material.color;
                alphaColor.a = 0f;
                FadePlane.GetComponent<MeshRenderer>().material.color = Color.Lerp(FadePlane.GetComponent<MeshRenderer>().material.color, alphaColor, 3.0f * Time.deltaTime);
            }
            else if(fade_val <= 0f && faded)
            {
                Debug.Log("Stage4");
                faded = false;
                FadePlane.SetActive(false);
                fade_val = 0;
                life_events_seen = false;
                current_state = GameState.IN_GAME;
            }
        }
	}

	public void NextDay() {
        if (current_state == GameState.IN_GAME) {
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
            life_events_open = false;
            LifeEventScripts[(int)LE_manager.current_event].Stop();
            LE_manager.SelectEvent();
			current_day++;
			if(current_day == MAX_DAYS) {
				current_state = GameState.END;
				GameOver();
			}
            current_state = GameState.IN_FADE;
		}
	}
	public void LE_Open_Button() {
		life_events_open = true;
        life_events_seen = true;
        LifeEventScripts[(int)LE_manager.current_event].Play();
    }
	public void LE_Close_Button() {
		life_events_open = false;
        LifeEventScripts[(int)LE_manager.current_event].Stop();
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

	public void GameOver() {
		SceneManager.LoadScene("GameOver");
	}

}
