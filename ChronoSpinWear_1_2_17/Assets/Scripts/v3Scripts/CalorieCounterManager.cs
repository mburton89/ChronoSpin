using UnityEngine;
using System.Collections;

public class CalorieCounterManager : MonoBehaviour {

	public GUISkin Skin;
	public int totalCalories;
	public int caloriesToAdd;

	// Use this for initialization
	void Start () { 
	
	}
	
	// Update is called once per frame
	void Update () {
		HandleKeyboard();
		Debug.Log(totalCalories);
	}

	public void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			increaseTotalCalories(20);
		} 
	}

	public void increaseTotalCalories(int caloriesToAdd){
		totalCalories = totalCalories + caloriesToAdd;
	}
	
	public void OnGUI(){
		GUI.skin = Skin;

		GUILayout.BeginArea(new Rect(0 ,0, Screen.width, Screen.height)); //also added padding for GameSkin on Inspector
		{
			GUILayout.BeginVertical(Skin.GetStyle("GameHud"));
			{

				GUILayout.Label(string.Format("{0}", totalCalories), Skin.GetStyle("EnemyKillText")); 

//				if(Application.loadedLevel == 0 || Application.loadedLevel == 4){
//					GUILayout.Label(string.Format("NINJEVADE"), Skin.GetStyle("EnemyKillText")); 
//				}

//				if(Application.loadedLevel == 2){
//					GUILayout.Label(string.Format("GAME OVER"), Skin.GetStyle("EnemyKillText"));
//				}

//		UNCOMMENT FOR TIME GUI
//				var time = LevelManager.Instance.RunningTime;
//				GUILayout.Label(string.Format(
//					"{0:00}:{1:00} with {2} bonus", 
//					time.Minutes + (time.Hours * 60), 
//					time.Seconds,
//				    LevelManager.Instance.CurrentTimeBonus), Skin.GetStyle("TimeText"));
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();
	}
}
