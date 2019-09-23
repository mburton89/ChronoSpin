using UnityEngine;
using System.Collections;

public class CornersMenu : MonoBehaviour {

	public WatchManager watchManager;
	public CameraManager cameraManager;
	public ColorChanger colorChanger;

	public GameObject PlayButton;
	public GameObject ZoomInButton;
	public GameObject ZoomOutButton;
	public GameObject PreviousColorButton;
	public GameObject NextColorButton;

	public GameObject PlayText;
	public GameObject ZoomInText;
	public GameObject ZoomOutText;
	public GameObject PreviousColorText;
	public GameObject NextColorText;

	private bool hasTappedPlay;
	private bool hasTappedZoomIn;
	private bool hasTappedZoomOut;
	private bool hasTappedPreviousColor;
	private bool hasTappedNextColor;

	private bool hasDoubleTapped;

	void Start () {
		determinePlayerPrefs();
		determineTextVisibility();
	}
	
	// Update is called once per frame
//	void Update () {
//		determineDoubleTappage();
//		if(hasDoubleTapped){
//			handleInput();
//		}
//	}

	public void handleInput(){
#if UNITY_EDITOR
		hasDoubleTapped = true;
		if (Input.GetKeyDown(KeyCode.Keypad3)){
			play();
		}else if (Input.GetKeyDown(KeyCode.Keypad1)){
			cameraManager.toggleZoom();
		}else if (Input.GetKeyDown(KeyCode.Keypad7)){
			switchToPreviousColor();
		}else if (Input.GetKeyDown(KeyCode.Keypad9)){
			switchToNextColor();
		}
#endif
	}

	public void determineDoubleTappage(){
		Touch touch = Input.GetTouch(0);
		if(touch.tapCount >= 2){
			lightUpButtons();
			hasDoubleTapped = true;
		}
	}

	public void determinePlayerPrefs(){
		if(PlayerPrefs.GetInt("hasTappedPlay") != 1){
			hasTappedPlay = false;
		}else{
			hasTappedPlay = true;
		}

		if(PlayerPrefs.GetInt("hasTappedZoomIn") != 1){
			hasTappedZoomIn = false;
		}else{
			hasTappedZoomIn = true;
		}

		if(PlayerPrefs.GetInt("hasTappedZoomOut") != 1){
			hasTappedZoomOut = false;
		}else{
			hasTappedZoomOut = true;
		}

		if(PlayerPrefs.GetInt("hasTappedPreviousColor") != 1){
			hasTappedPreviousColor = false;
		}else{
			hasTappedPreviousColor = true;
		}

		if(PlayerPrefs.GetInt("hasTappedNextColor") != 1){
			hasTappedNextColor = false;
		}else{
			hasTappedNextColor = true;
		}
	}

	public void determineTextVisibility(){
		if(!hasTappedPlay){
			PlayText.SetActive(true);
		}
		if(!hasTappedZoomIn){
			ZoomInText.SetActive(true);
		}
		if(!hasTappedZoomOut){
			ZoomInText.SetActive(true);
		}
		if(!hasTappedPreviousColor){
			PreviousColorText.SetActive(true);
		}
		if(!hasTappedNextColor){
			NextColorText.SetActive(true);
		}
	}



	public void lightUpButtons(){
		//flicker them
	}

	public void play(){
		if(!hasTappedPlay){
			PlayerPrefs.SetInt("hasTappedPlay",1);
		}
		watchManager.startGame();
	}

	public void zoomIn(){
		if(!hasTappedZoomIn){
			PlayerPrefs.SetInt("hasTappedZoomIn",1);
		}
		cameraManager.zoomIn();
	}

	public void zoomOut(){
		if(!hasTappedZoomOut){
			PlayerPrefs.SetInt("hasTappedZoomOut",1);
		}
		cameraManager.zoomOut();
	}

	public void switchToPreviousColor(){
		if(!hasTappedPreviousColor){
			PlayerPrefs.SetInt("hasTappedPreviousColor",1);
		}
		colorChanger.choosePreviousColor();
	}

	public void switchToNextColor(){
		if(!hasTappedNextColor){
			PlayerPrefs.SetInt("hasTappedNextColor",1);
		}
		colorChanger.chooseNextColor();
	}
}
