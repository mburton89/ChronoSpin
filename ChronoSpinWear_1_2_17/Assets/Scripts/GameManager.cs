using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

	public GameObject mainCamera;

	private static GameManager _instance;
	public static GameManager Instance{get{return _instance ?? (_instance = new GameManager());}}
	public Background background;
	public SpinningLine line;
	public DateTime started; 
	public Projectile projectile;
	public FiringPatterns patterns;
	public HUDTab upperTab;
	public HUDTab leftTab;
	public HUDTab rightTab;
	//public HUDTab lowerTab;
	public v3PairsDispenser projectileDispenser;
	public CameraPivot camera;
	public LightRay lightRay;
	public GameObject GreenImages;

	//NATHALIE IS SMOKING HOT AND SHE'S MY GF. BOOYAH

	public TimeSpan RunningTime{get{return DateTime.UtcNow - started;}}
	public double pointsAlreadyAccumulated;
	public double timePoints; 

	public float projectileSpeedNegOne = 1.9f; //2.492f
	public float projectileSpeedZero = 1.9f; //2.492f
	public float projectileSpeed1 = 1.9f; //2.492f
	public float projectileSpeed2 = 2.9f;
	public float projectileSpeed3 = 3.3f;
	public float projectileSpeed4 = 3.695f; 
	public float projectileSpeed5 = 4.1f; 
	public float projectileSpeed6 = 4.53f; 
	public float projectileSpeed7 = 4.88f; //
	public float projectileSpeed8 = 5.29f; 
	public float projectileSpeed9 = 5f; 
	public float projectileSpeed10 = 5.7f; 

	public float firstWaitTimeNegOne = 2f; //40 BPM
	public float firstWaitTimeZero = 1.5f; //50 BPM
	public float firstWaitTime1 = 1.03f; //60 BPM
	public float firstWaitTime2 = .8571428f; //70 BPM
	public float firstWaitTime3 = .75f; //80 BPM
	public float firstWaitTime4 = .6666667f; //90BPM
	public float firstWaitTime5 = .6f; //100BPM
	public float firstWaitTime6 = .5454545f; //110BPM
	public float firstWaitTime7 = .5f; //120BPM
	public float firstWaitTime8 = .4615385f; //130BPM
	public float firstWaitTime9 = .4285714f; //140BPM
	public float firstWaitTime10 = .4f; //150BPM
	
	public int lineSpinningSpeedNegOne = 181; //124
	public int lineSpinningSpeedZero = 181; //149
	public int lineSpinningSpeed1 = 181;
	public int lineSpinningSpeed2 = 214;
	public int lineSpinningSpeed3 = 241;
	public int lineSpinningSpeed4 = 276;
	public int lineSpinningSpeed5 = 302;
	public int lineSpinningSpeed6 = 336;
	public int lineSpinningSpeed7 = 359;
	public int lineSpinningSpeed8 = 390;
	public int lineSpinningSpeed9 = 424; //NOT USING
	public int lineSpinningSpeed10 = 445;

	public float speedChangeWaitTime = 4;
	public float secondWaitTime1 = 1.5f;
	public float secondWaitTime2 = 1.2f;
	public float secondWaitTime3 = .9f;
	public float secondWaitTime4 = .6f;

	public float lineRotation;
	public float beginingLineRotation;

//	public int lineSpinningSpeed1 = 150;
//	public int lineSpinningSpeed2 = 178;
//	public int lineSpinningSpeed3 = 224;
//	public int lineSpinningSpeed4 = 296;
	
	public bool isGameOver;
	public bool isInsaneMode;

	public bool isComingFromFirstLevel;
	public bool isComingFromSecondLevel;

	public int menuSpeedNumber;

	//public int speed;

	public int Points {get; private set;}  

	public AudioClip cameraEndSound;
	public AudioClip gameOverSound;

	public GameObject GameInterface;
	public GameObject WatchInterface;
	public Vector3 invisibleScale = new Vector3(0,0,0);
	public Vector3 visibleScale = new Vector3(1,1,0);

	public GameObject BackHand;
	public GameObject FrontHand;

	public bool frontHandIsAligned;
	public bool backHandIsAligned;

	public FlickerManager flickerManager;
	public ProgressCircle progressCircle;

	public WatchHand lowerHand1;
	public WatchHand lowerHand2;
	public WatchHand upperHand1;
	public WatchHand upperHand2;

	public ColorChanger colorChanger;

	public bool canLookForRemainingProjectiles;
	public bool allProjectilesAreBelowLine;

	private GameManager(){
		//contructor to instantiate GameManager Singleton
	}

//	void Awake(){
//		colorChanger.determineColor();
//	}

	void Start () {
		started = DateTime.UtcNow;  
	}


	void Update(){
		//HandleKeyboard();


		if(line.canSpin == false){
			alignHandsToWatchMode();
			determineGameReadyness();
			lowerHand1.slideUpIntoWatchPosition();
			lowerHand2.slideUpIntoWatchPosition();
		}else{
			lowerHand1.slideDownIntoGamePosition();
			lowerHand2.slideDownIntoGamePosition();
		}
//
//		if(canLookForRemainingProjectiles){
//			if(allProjectilesAreBelowLine){
//				SceneManager.LoadScene(2);
//			}
//		}
	}
//	void Update () {
////		if(Application.loadedLevel == 1){
////			HandleKeyboard();   
////			//HandleUserTouches(); 
////		}
//
//		//timePoints = (RunningTime.TotalSeconds * 10 + pointsAlreadyAccumulated);
//		//Debug.Log("timePoints == " + timePoints);
////		Debug.Log("timePoints: " + timePoints);
////		if(RunningTime.TotalSeconds > 15f){  
////			PlayerPrefs.SetInt("Mode", PlayerPrefs.GetInt("Mode") + 1);
////			determineMode();			 
////		} 
//	}

	public void HandleKeyboard(){
		if (Input.GetKey(KeyCode.UpArrow)) {
			progressCircle.layerName = "Hidden";
		}
	} 

	public void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase >= TouchPhase.Began){ //&& touch.tapCount == 1){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);  
					restartSession();
			}
		}
	}
	 
	public void displayGameOverScreen(){
		//mainCamera.GetComponent<Animator>().Play("WatchStart");
		flickerManager.flicker(true);
		progressCircle.layerName = "Hidden";
		progressCircle.recoilProgressCircle();
		line.canSpin = false;
		line.GetComponent<BoxCollider2D>().enabled = false;
		initiateGameOverAnimation();
//		recordScore();
	}

	public void initiateGameOverAnimation(){
		StartCoroutine(initiateGameOverAnimationCo()); 
	}

	private IEnumerator initiateGameOverAnimationCo(){ 
		projectileDispenser.canFire = false;
		//flicker();
		//AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
		Projectile[] projectiles = FindObjectsOfType(typeof(Projectile)) as Projectile[];
		foreach (Projectile projectile in projectiles){
			projectile.GetComponent<Projectile>().Speed = 0;
			projectile.flicker();
		}
			
		yield return new WaitForSeconds (.5f);
       	SceneManager.LoadScene(0);
	}

	public void restartSession(){
		//isGameOver = false;
		Debug.Log("MORE SHTUFF");
//		upperTab.raiseUpperTab();  
//		leftTab.raiseLeftTab();
//		rightTab.lowerRightTab();
//		lowerTab.openLowerTab(); 
		returnToGame();
	}

	public void ResetPointsToZero(){
		Points = 0;     
	} 

	public void ResetPoints(int points){ 
		Points = points;
	}  
	
	public void AddPoints(int pointsToAdd){
		Points += pointsToAdd;
	}

	public void determineMode(){
		resetTimer();
	}

	public void resetTimer(){
		started = DateTime.UtcNow;
	}
 
	public void returnToGame(){
		StartCoroutine(returnToGameCo());    
	}
	
	private IEnumerator returnToGameCo(){   
		yield return new WaitForSeconds (.1f);   
		if(Application.loadedLevel == 1){  
			Debug.Log("SMELLOOO");
			Application.LoadLevel(0); 
		} 
	}

	public void recordScore(){
		float score;
		score = (float)RunningTime.TotalSeconds;  
		if(Application.loadedLevel == 1){
			if(score > PlayerPrefs.GetFloat("insaneModeHighScore")){
				PlayerPrefs.SetFloat("insaneModeHighScore",score);
			}
		}else{
			if(score > PlayerPrefs.GetFloat("normalModeHighScore")){
				PlayerPrefs.SetFloat("normalModeHighScore",score);
			}
		}
	}

    public void determineNextScene() {
		SceneManager.LoadScene(0);

//        if (PlayerPrefs.GetInt("PlayerLevel") > 1)
//        {
//            PlayerPrefs.SetInt("adCounter", PlayerPrefs.GetInt("adCounter") + 1);
//            if (Advertisement.IsReady())
//            {
//                if (PlayerPrefs.GetInt("adCounter") >= 7)
//                {
//                    SceneManager.LoadScene(5);
//                }
//                else {
//                    SceneManager.LoadScene(6);
//                }
//            }
//            else {
//                SceneManager.LoadScene(6);
//            }
//        }
//        else {
//             SceneManager.LoadScene(6);
//        }
	   }


	public void flicker(){
		StartCoroutine(flickerCo()); 
	}

	private IEnumerator flickerCo(){
		line.transform.localScale = invisibleScale;
		yield return new WaitForSeconds (.03f);
		line.transform.localScale = visibleScale;
		yield return new WaitForSeconds (.03f);
		line.transform.localScale = invisibleScale;
		yield return new WaitForSeconds (.03f);
		line.transform.localScale = visibleScale;
		yield return new WaitForSeconds (.03f);
		line.transform.localScale = invisibleScale;
		yield return new WaitForSeconds (3f);
		yield return new WaitForSeconds (.03f);
		line.transform.localScale = visibleScale;
		yield return new WaitForSeconds (.03f);
		line.transform.localScale = invisibleScale;
		yield return new WaitForSeconds (.03f);
		line.transform.localScale = visibleScale;
		yield return new WaitForSeconds (.03f);
		line.transform.localScale = invisibleScale;
	}

	public void alignHandsToWatchMode(){
//		alignFrontHandTo180();
//		alignBackHandTo180();
	}

	public void alignFrontHandTo180(){
		if(!frontHandIsAligned){
			if(FrontHand.transform.rotation.eulerAngles.z > 5 && FrontHand.transform.rotation.eulerAngles.z < 355){
				FrontHand.transform.Rotate(0, 0, (-181 * 2f)* Time.deltaTime,Space.Self);
			}else{
				frontHandIsAligned = true;
			}
		}else{
			FrontHand.transform.rotation = Quaternion.Euler(0,0,0);
		}
	}

	public void alignBackHandTo180(){
		if(!backHandIsAligned){
			if(BackHand.transform.rotation.eulerAngles.z > 185 || BackHand.transform.rotation.eulerAngles.z < 175){
				BackHand.transform.Rotate(0, 0, (-181 * 2f)* Time.deltaTime,Space.Self);
			}else{
				backHandIsAligned = true;
			}
		}else{
			BackHand.transform.rotation = Quaternion.Euler(0,0,180);
		}
	}

	public void determineGameReadyness(){

		if(backHandIsAligned && frontHandIsAligned){
			StartCoroutine(determineGameReadynessCo()); 
		}
	}

	private IEnumerator determineGameReadynessCo(){
		yield return new WaitForSeconds (.02f);
		SceneManager.LoadScene(0);
	}

	public void levelUp(){
		//incrementLevel
		//moveHandsIntoLevelUpPosition
		//wait .2f
		//cheer
		//wait .2f
		//moveBackIntoGamePosition
	}

//	public bool checkForProjectiles(){
//		Projectile[] projectiles = FindObjectsOfType(typeof(Projectile)) as Projectile[];
//		foreach (Projectile projectile in projectiles){
//			projectile.GetComponent<Projectile>().Speed = 0;
//			projectile.flicker();
//		}
//	}
}