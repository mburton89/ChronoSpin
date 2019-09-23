using UnityEngine;
using System.Collections;

public class ColorsMenu : MonoBehaviour {

	public ColorChanger colorChanger;
	public GameObject colorButtons;
	public NumberShower numberShower;

	public SpriteRenderer Slot1;
	public SpriteRenderer Slot2;
	public SpriteRenderer Slot3;
	public SpriteRenderer Slot4;
	public SpriteRenderer Slot5;
	public SpriteRenderer Slot6;
	public SpriteRenderer Slot7;
	public SpriteRenderer Slot8;
	public SpriteRenderer Slot9;
	public SpriteRenderer Slot10;
	public SpriteRenderer Slot11;
	public SpriteRenderer Slot12;

	public bool hasDoubleTapped;
	public bool isOnColorsMenu;

	void Start () {
		isOnColorsMenu = false;
	}

	#if UNITY_EDITOR
	void Update () {

		handleKeyboard();

		//handleDoubleTaps();
	}
	#endif

	public void handleKeyboard(){
		if(Input.GetKeyDown(KeyCode.M)){
			displayColorsMenu();
		}
	}

//	public void handleDoubleTaps(){
//		for (int i = 0; i < Input.touchCount; i++){  
//			Touch touch = Input.GetTouch(0);
//			Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); 
//			if(touchPosition.x < 1
//			&&){
//				if(!colorButtons.activeInHierarchy){
//					displayColorsMenu();
//				}
////				else{
////					hideColorsMenu();
////				}
//			}
//		}
//	}

	public void displayColorsMenu(){
		if(!isOnColorsMenu){
			colorChanger.turnWhite();
			colorButtons.SetActive(true);
			Slot1.color = new Color(.71f, 1, 0, 1f); //YELLOW/GREEN
			Slot2.color = Color.green;
			Slot3.color = Color.cyan;
			Slot4.color = new Color(0, .53f, 1, 1f); //MEDIUM BLUE
			Slot5.color = Color.blue;
			Slot6.color = new Color(.7f, .1f, .85f, 1f); //PURPLE
			Slot7.color = Color.magenta;
			Slot8.color = Color.red;
			Slot9.color = new Color(1, .3f, 0.0f, 1f); //RED/ORANGE
			Slot10.color = new Color(1, .55f, 0.0f, 1f); //ORANGE/AMBER
			Slot11.color = new Color(1, .77f, 0.0f, 1f); //ORANGE/YELLOW
			Slot12.color = Color.yellow;
			if(TutorialManager.instance != null){
				if(CameraManager.instance.isForSmartWatches){
					TutorialManager.instance.showPhrase(TutorialManager.instance.phrase3);
				}else{
					TutorialManager.instance.showPhrase(TutorialManager.instance.phrase2);
					TutorialManager.instance.hasSeenPhrase2 = true;
					//TutorialManager.instance.startPhrase3();
				}
			}
			isOnColorsMenu = true;
			NumberShower.instance.showConfigText();
		}
//		else{
//			colorChanger.toggleBackground();
//		}
	}

	public void hideColorsMenu(){
		isOnColorsMenu = false;
		colorButtons.SetActive(false);
		PlayerPrefs.SetFloat("playerOrthoSize",Camera.main.orthographicSize);
		PlayerPrefs.SetFloat("playerYPosition",Camera.main.transform.position.y);
		PlayerPrefs.SetFloat("playerXPosition",Camera.main.transform.position.x);
	}
}
