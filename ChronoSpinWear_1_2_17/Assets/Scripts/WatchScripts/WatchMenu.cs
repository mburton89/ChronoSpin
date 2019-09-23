using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WatchMenu : MonoBehaviour {

	public GameObject mainCamera;

	public GameObject Level1Button;
	public GameObject Level2Button;
	public GameObject Level3Button;
	public GameObject Level4Button;
	public GameObject Level5Button;
	public GameObject Level6Button;
	public GameObject Level7Button;
	public GameObject Level8Button;
	public GameObject Level9Button;
	public GameObject Level10Button;
	public GameObject Level11Button;
	public GameObject Level12Button;
	public GameObject LevelNumber;

	public GameObject MinuteHand;
	public GameObject MinuteHandBackEnd1;
	//public GameObject MinuteHandBackEnd2;
	public GameObject HourHand;
	public GameObject HourHandFrontEnd;
	public GameObject HourHandPretendEnd;
	public GameObject SecondsHand;
	public GameObject LowerMinuteHandSprite;
	public GameObject HourHandSprite;

	public GameObject line;
	public int lineSpinningSpeed = 200;

	public ColorChanger colorChanger;

	public bool isStartingWatchMode;
	public bool isWatchMode;
	public bool isStartingGameMode;
	public bool isGameMode;

	public bool secondHandIsAligned;
	public bool minuteHandIsAligned;
	public bool hourHandIsAligned;
	public bool spinningLineIsAligned;

	public bool hourHandIsInGameMode;
	public bool lowerMinuteHandIsInGameMode;

	public bool secondHandIsAlignedToWatchMode;
	public bool minuteHandIsAlignedToWatchMode;
	public bool hourHandIsAlignedToWatchMode;

	public GameObject OuterSlot1;
	public GameObject OuterSlot2;
	public GameObject OuterSlot3;
	public GameObject OuterSlot4;
	public GameObject OuterSlot5;
	public GameObject OuterSlot6;
	public GameObject OuterSlot7;
	public GameObject OuterSlot8;
	public GameObject OuterSlot9;
	public GameObject OuterSlot10;
	public GameObject OuterSlot11;
	public GameObject OuterSlot12;

	public int spinningSpeed;

	public GameObject GameInterface;
	public GameObject WatchInterface;
	public Vector3 invisibleScale = new Vector3(0,0,0);
	public Vector3 visibleScale = new Vector3(1,1,0);

	public bool handsCanMove;

	public int secondHandAngleToBeAt;
	public int hourHandAngleToBeAt;

	private int spinTransitionSpeed = 3;
	//private int spinTransitionSpeed = 1;

	public int extraHourAngles;

	void Start () {
		startGameBuffer();
		isWatchMode = true;
		PlayerPrefs.SetFloat("PlayerLevel",1);
		Time.timeScale = 1;
		determineLevelNumber(PlayerPrefs.GetInt("PlayerLevel"));
	}
	
	void Update () {
		if(handsCanMove){
			alignHandsForWatchMode();
			spinLine();
		}else if(isStartingGameMode){
			alignHands();
		}

		HandleKeyboard();
		HandleUserTouches();
//		//spinLine();
//		if(isWatchMode){
//			determineHandsInWatchMode();
//		}else 
//		//establishGameLine();
		determineGameReadyness();
	}

	public void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			startLevel(1, Level1Button);
		}else if (Input.GetKeyDown(KeyCode.Alpha2)){
			startLevel(2, Level2Button);
		}else if (Input.GetKeyDown(KeyCode.Alpha3)){
			startLevel(3, Level3Button);
		}else if (Input.GetKeyDown(KeyCode.Alpha4)){
			startLevel(4, Level4Button);
		}else if (Input.GetKeyDown(KeyCode.Alpha5)){
			startLevel(5, Level5Button);
		}else if (Input.GetKeyDown(KeyCode.Alpha6)){
			startLevel(6, Level6Button);
		}else if (Input.GetKeyDown(KeyCode.Alpha7)){
			startLevel(7, Level7Button);
		}else if (Input.GetKeyDown(KeyCode.Alpha8)){
			startLevel(8, Level8Button);
		}else if (Input.GetKeyDown(KeyCode.Alpha9)){
			startLevel(9, Level9Button);
		}else if (Input.GetKeyDown(KeyCode.Alpha0)){
			//shoostHourHandToLowerScreen();
		}else if (Input.GetKeyDown(KeyCode.S)){
			//PrepSecondsAndHoursHandForTransition();
			startLevel(3, Level3Button);
			handsCanMove = false;
			isWatchMode = false;
			isStartingGameMode = true;
			startCameraAnimation();
		}
	}

	public void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); 
				if(touchPosition.x > 1.03 && touchPosition.x < 2.77 && touchPosition.y > 2.43 && touchPosition.y < 4.14){
					startLevel(1, Level1Button);
				}else if(touchPosition.x > 2.41 && touchPosition.x < 4.17 && touchPosition.y > 1.02 && touchPosition.y < 2.76){
					startLevel(2, Level2Button);
				}else if(touchPosition.x > 1.5 && touchPosition.x < 2.5 && touchPosition.y > -.5 && touchPosition.y < .5){
					//startLevel(3, Level3Button);
					handsCanMove = false;
					isWatchMode = false;
					isStartingGameMode = true;
					startCameraAnimation();
				}else if(touchPosition.x > 2.41 && touchPosition.x < 4.17 && touchPosition.y > -2.76 && touchPosition.y < 1.02){
					startLevel(4, Level4Button);
				}else if(touchPosition.x > 1.03 && touchPosition.x < 2.77 && touchPosition.y > -4.14 && touchPosition.y < -2.43){
					startLevel(5, Level5Button);
				}else if(touchPosition.x > -.89 && touchPosition.x < .89 && touchPosition.y > -4.67 && touchPosition.y < -2.93){
					startLevel(6, Level6Button);
				}else if(touchPosition.x < -1.03 && touchPosition.x > -2.77 && touchPosition.y > -4.14 && touchPosition.y < -2.43){
					startLevel(7, Level7Button);
				}else if(touchPosition.x < -2.41 && touchPosition.x > -4.17 && touchPosition.y > -2.76 && touchPosition.y < 1.02){
					startLevel(8, Level8Button);
				}else if(touchPosition.x < -2.92 && touchPosition.x > -4.68 && touchPosition.y > -.89 && touchPosition.y < .89){
					startLevel(9, Level9Button);
				}else if(touchPosition.x < -2.41 && touchPosition.x > -4.17 && touchPosition.y > 1.02 && touchPosition.y < 2.76){
					startLevel(10, Level10Button);
				}else if(touchPosition.x < -1.03 && touchPosition.x > -2.77 && touchPosition.y > 2.43 && touchPosition.y < 4.14){
					startLevel(11, Level11Button);
				}else if(touchPosition.x > -.89 && touchPosition.x < .89 && touchPosition.y < 4.67 && touchPosition.y > 2.93){
					startLevel(12, Level12Button);
				}else if(touchPosition.x > -1 && touchPosition.x < 1 && touchPosition.y < 1 && touchPosition.y > -1){
					//colorChanger.chooseNextColor();
				}
//				handsCanMove = false;
//				isWatchMode = false;
//				isStartingGameMode = true;
//				startCameraAnimation();
			}
		}
	}

	public void determineButtons(){
		if(PlayerPrefs.GetInt("PlayerLevel") > 1){
			Level1Button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircle" , typeof(Sprite)) as Sprite;
		}if(PlayerPrefs.GetInt("PlayerLevel") > 2){
			Level2Button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircle", typeof(Sprite)) as Sprite;
		}if(PlayerPrefs.GetInt("PlayerLevel") > 3){
			Level3Button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircle", typeof(Sprite)) as Sprite;
		}if(PlayerPrefs.GetInt("PlayerLevel") > 4){
			Level4Button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircle", typeof(Sprite)) as Sprite;
		}if(PlayerPrefs.GetInt("PlayerLevel") > 5){
			Level5Button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircle", typeof(Sprite)) as Sprite;
		}if(PlayerPrefs.GetInt("PlayerLevel") > 6){
			Level6Button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircle", typeof(Sprite)) as Sprite;
		}if(PlayerPrefs.GetInt("PlayerLevel") > 7){
			Level7Button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircle", typeof(Sprite)) as Sprite;
		}if(PlayerPrefs.GetInt("PlayerLevel") > 8){
			Level8Button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircle", typeof(Sprite)) as Sprite;
		}if(PlayerPrefs.GetInt("PlayerLevel") > 9){
			Level9Button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircle", typeof(Sprite)) as Sprite;
		}if(PlayerPrefs.GetInt("PlayerLevel") > 10){
			Level10Button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircle", typeof(Sprite)) as Sprite;
		}
	}

	public void startLevel(int levelNumber, GameObject button){
		StartCoroutine(startLevelCo(levelNumber, button));
	}

	private IEnumerator startLevelCo(int levelNumber, GameObject button){ 
		button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitCircle", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.025f);
//		button.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircle", typeof(Sprite)) as Sprite;
//		yield return new WaitForSeconds (.025f);
//		GameManager.Instance.menuSpeedNumber = levelNumber;
//		SceneManager.LoadScene(1);
//		GameManager.Instance.beginingLineRotation = line.transform.rotation.z;
	}

	public void spinLine(){
		line.transform.Rotate(0, 0, -lineSpinningSpeed * Time.deltaTime,Space.Self);
	}

	public void determineSeconds(){
		//Debug.Log("HOURS " + System.DateTime.Now);
		SecondsHand.transform.rotation = Quaternion.Euler(0,0,System.DateTime.Now.Second * -6);
	}

	public void determineMinutes(){
		//Debug.Log("MINUTES " + System.DateTime.UtcNow.Minute);
		MinuteHand.transform.rotation = Quaternion.Euler(0,0,System.DateTime.Now.Minute * -6);
	}

	public void determineHours(){
		//Debug.Log("HOURS " + System.DateTime.Now);
		HourHand.transform.rotation = Quaternion.Euler(0,0,(System.DateTime.Now.Hour * -30));
		//System.DateTime.Now.Minute
	}

//	public void determineExtraHourAngles(){
//
//	}

	public void determineHandsInWatchMode(){
		determineSeconds();
		determineMinutes();
		determineHours();
	}
		
	public void alignHands(){
//		float hourHandAngle = HourHand.transform.rotation.eulerAngles.z;
//		float minuteHandAngle = HourHand.transform.rotation.eulerAngles.z;
//
//		if(hourHandAngle <= 180){
//			hourHandAngle = hourHandAngle + 180;
//		}else{
//			hourHandAngle = hourHandAngle - 180;
//		}	
//		alignSecondHandToGameMode(minuteHandAngle);
//		alignMinuteHandToGameMode(hourHandAngle);
//		alignHourHandToGameMode();

		alignSecondHandTo180C();
		alignMinuteHandTo180();
		alignHourHandTo180();
		alignSpinningLineto180();
		StartCoroutine(prepareOuterSlotsForGameModeCo()); 
		//shoostHourHandToLowerScreen();
	}

	public void shoostLowerHandsToBottomOfScreen(){
		//shoostHourHandToLowerScreen();
	}

	public void alignHandsForWatchMode(){
		alignSecondHandToWatchMode();
		alignMinuteHandToWatchMode();
		alignHourHandToWatchMode();
	}

//	public void alignSecondHandToGameMode(float minuteHandAngle){
//		if(!secondHandIsAligned){
//			if(SecondsHand.transform.rotation.eulerAngles.z > minuteHandAngle + 5 || SecondsHand.transform.rotation.eulerAngles.z < minuteHandAngle - 5){
//				SecondsHand.transform.Rotate(0, 0, (-spinningSpeed * 2)* Time.deltaTime,Space.Self);	
//			}else{
//				secondHandIsAligned = true;
//			}
//		}else{
//			SecondsHand.transform.Rotate(0, 0, (-spinningSpeed)* Time.deltaTime,Space.Self);
//		}
//	}
//
//	public void alignSecondHandTo180(){
//		if(!secondHandIsAligned){
//			if(SecondsHand.transform.rotation.eulerAngles.z > 185 || SecondsHand.transform.rotation.eulerAngles.z < 175){
//				SecondsHand.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3 (0,0,180), 5 * Time.deltaTime);
//			}else{
//				secondHandIsAligned = true;
//			}
//		}else{
//			SecondsHand.transform.rotation = Quaternion.Euler(0,0,180);
//		}
//	}
//
//	public void alignSecondHandTo180B(){
//		if(!secondHandIsAligned){
//			if(SecondsHand.transform.rotation.eulerAngles.z > 181 || SecondsHand.transform.rotation.eulerAngles.z < 179){
//				SecondsHand.transform.eulerAngles = Vector3.Lerp(SecondsHand.transform.rotation.eulerAngles, new Vector3 (0,0,secondHandAngleToBeAt), Time.deltaTime);
//			}else{
//				secondHandIsAligned = true;
//			}
//		}else{
//			SecondsHand.transform.rotation = Quaternion.Euler(0,0,secondHandAngleToBeAt);
//		} 
//	}

	public void alignSecondHandTo180C(){
		if(!secondHandIsAligned){
			if(SecondsHand.transform.rotation.eulerAngles.z > 318 || SecondsHand.transform.rotation.eulerAngles.z < 312 ){
				SecondsHand.transform.eulerAngles = Vector3.Lerp(SecondsHand.transform.rotation.eulerAngles, new Vector3 (0,0,315), spinTransitionSpeed * Time.deltaTime);
			}else{
				secondHandIsAligned = true;
			}
		}else{
			SecondsHand.transform.rotation = Quaternion.Euler(0,0,315);
		}
	}

	public void alignSecondHandToWatchMode(){

		float zSecondAngle;
		zSecondAngle = 360 - (System.DateTime.Now.Second * 6);
		if(zSecondAngle == 360){
			SecondsHand.transform.rotation = Quaternion.Euler(0,0,359.99f);
		}else{
			SecondsHand.transform.eulerAngles = Vector3.Lerp(SecondsHand.transform.rotation.eulerAngles, new Vector3 (0,0,zSecondAngle), spinTransitionSpeed * Time.deltaTime);
		}
//		if(zSecondAngle == 354){
//			zSecondAngle = -6;
//		}
		//Debug.Log("SECONDS " + System.DateTime.Now.Second);

//		if(!secondHandIsAlignedToWatchMode){
//			if(SecondsHand.transform.rotation.eulerAngles.z > (360 - (System.DateTime.Now.Second * 6 - 5)) || SecondsHand.transform.rotation.eulerAngles.z < (360 - (System.DateTime.Now.Second * 6 + 5))){
//				//SecondsHand.transform.Rotate(0, 0, (-spinningSpeed * 2) * Time.deltaTime,Space.Self);
//				SecondsHand.transform.eulerAngles = Vector3.Lerp(SecondsHand.transform.rotation.eulerAngles, new Vector3 (0,0,360 - (System.DateTime.Now.Second * 6)), spinTransitionSpeed * Time.deltaTime);
//			}else{
//				secondHandIsAlignedToWatchMode = true;
//			}
//		}else{
//			SecondsHand.transform.rotation = Quaternion.Euler(0,0,System.DateTime.Now.Second * -6);
//		}
	}

	public void alignMinuteHandToGameMode(float hourHandAngle){
		if(!minuteHandIsAligned){
			if(MinuteHand.transform.rotation.eulerAngles.z > hourHandAngle + 5 || MinuteHand.transform.rotation.eulerAngles.z < hourHandAngle - 5){
				MinuteHand.transform.Rotate(0, 0, (-spinningSpeed * 1.5f)* Time.deltaTime,Space.Self);
			}else{
				minuteHandIsAligned = true;
			}
		}else{
			MinuteHand.transform.Rotate(0, 0, (-spinningSpeed)* Time.deltaTime,Space.Self);
		}
	}

	public void alignMinuteHandTo180(){
		if(!minuteHandIsAligned){
			if(MinuteHand.transform.rotation.eulerAngles.z > 48 || MinuteHand.transform.rotation.eulerAngles.z < 42){
				MinuteHand.transform.eulerAngles = Vector3.Lerp(MinuteHand.transform.rotation.eulerAngles, new Vector3 (0,0,45), spinTransitionSpeed * Time.deltaTime);
			}else{
				minuteHandIsAligned = true;
			}
		}else{
			MinuteHand.transform.rotation = Quaternion.Euler(0,0,45);
		}
	}

	public void alignMinuteHandTo180B(){
		if(!minuteHandIsAligned){
			if(MinuteHand.transform.rotation.eulerAngles.z > 1){
				MinuteHand.transform.eulerAngles = Vector3.Lerp(MinuteHand.transform.rotation.eulerAngles, new Vector3 (0,0,0), spinTransitionSpeed * Time.deltaTime);
			}else{
				minuteHandIsAligned = true;
			}
		}else{
			MinuteHand.transform.rotation = Quaternion.Euler(0,0,0);
		}
	}

	public void alignMinuteHandToWatchMode(){

		float zMinuteAngle;
		zMinuteAngle = 360 - (System.DateTime.Now.Minute * 6);
		if(zMinuteAngle == 360){
			MinuteHand.transform.rotation = Quaternion.Euler(0,0,359.99f);
		}else{
			MinuteHand.transform.eulerAngles = Vector3.Lerp(MinuteHand.transform.rotation.eulerAngles, new Vector3 (0,0,zMinuteAngle), spinTransitionSpeed * Time.deltaTime);
		}

//		MinuteHand.transform.eulerAngles = Vector3.Lerp(MinuteHand.transform.rotation.eulerAngles, new Vector3 (0,0,360 - (System.DateTime.Now.Minute * 6)), spinTransitionSpeed * Time.deltaTime);
//		if(!minuteHandIsAlignedToWatchMode){
//			if(MinuteHand.transform.rotation.eulerAngles.z > (360 - (System.DateTime.Now.Minute * 6 - 5)) || MinuteHand.transform.rotation.eulerAngles.z < (360 - (System.DateTime.Now.Minute * 6 + 5))){
//				MinuteHand.transform.Rotate(0, 0, (-spinningSpeed * 1.5f) * Time.deltaTime,Space.Self);
//			}else{
//				minuteHandIsAlignedToWatchMode = true;
//			}
//		}else{
//			MinuteHand.transform.rotation = Quaternion.Euler(0,0,System.DateTime.Now.Minute * -6);
//		}
	}

//	public void alignHourHandToGameMode(){
//		HourHand.transform.Rotate(0, 0, (-spinningSpeed)* Time.deltaTime,Space.Self);
//		hourHandIsAligned = true;
//	}
//
	public void alignHourHandTo180(){
		if(!hourHandIsAligned){
			if(HourHand.transform.rotation.eulerAngles.z > 318 || HourHand.transform.rotation.eulerAngles.z < 312){
				HourHand.transform.eulerAngles = Vector3.Lerp(HourHand.transform.rotation.eulerAngles, new Vector3 (0,0,315), spinTransitionSpeed * Time.deltaTime);
			}else{
				hourHandIsAligned = true;
			}
		}else{
			HourHand.transform.rotation = Quaternion.Euler(0,0,315);
		}
	}
//
//	public void alignHourHandTo180B(){
//		if(!hourHandIsAligned){
//			if(HourHand.transform.rotation.eulerAngles.z > 181 || HourHand.transform.rotation.eulerAngles.z < 179){
//				HourHand.transform.eulerAngles = Vector3.Lerp(HourHand.transform.rotation.eulerAngles, new Vector3 (0,0,180), 10 * Time.deltaTime);
//			}else{
//				hourHandIsAligned = true;
//			}
//		}else{
//			HourHand.transform.rotation = Quaternion.Euler(0,0,180);
//		}
//	}

	public void alignHourHandTo180C(){
		if(!hourHandIsAligned){
			if(HourHand.transform.rotation.eulerAngles.z > 1){
				HourHand.transform.eulerAngles = Vector3.Lerp(HourHand.transform.rotation.eulerAngles, new Vector3 (0,0,0), spinTransitionSpeed * Time.deltaTime);
			}else{
				hourHandIsAligned = true;
			}
		}else{
			HourHand.transform.rotation = Quaternion.Euler(0,0,0);
		}
	}

	public void alignSpinningLineto180(){
		if(!spinningLineIsAligned){
			if(line.transform.rotation.eulerAngles.z > 1){
				line.transform.eulerAngles = Vector3.Lerp(line.transform.rotation.eulerAngles, new Vector3 (0,0,0), spinTransitionSpeed * Time.deltaTime);
			}else{
				spinningLineIsAligned = true;
			}
		}else{
			line.transform.rotation = Quaternion.Euler(0,0,0);
		}
	}

	public void alignHourHandToWatchMode(){

//		float zHourAngle = 360 - (System.DateTime.Now.Hour * 30);
//		if(zHourAngle == 360 || zHourAngle == 0){
//			HourHand.transform.rotation = Quaternion.Euler(0,0,359.99f);
//		}else{
//			HourHand.transform.eulerAngles = Vector3.Lerp(HourHand.transform.rotation.eulerAngles, new Vector3 (0,0,zHourAngle), spinTransitionSpeed * Time.deltaTime);
//			HourHand.transform.eulerAngles = Vector3.Lerp(HourHand.transform.rotation.eulerAngles, new Vector3 (0,0,360 - (hourTime * 30) - (System.DateTime.Now.Minute/2)), spinTransitionSpeed * Time.deltaTime);
//		}

//		float hourTime = System.DateTime.Now.Hour;
//		if(hourTime >= 12){
//			hourTime = hourTime - 12;
//		}
//		if(hourTime == 0){
//			HourHand.transform.rotation = Quaternion.Euler(0,0,359.99f);
//		}else{
//			HourHand.transform.eulerAngles = Vector3.Lerp(HourHand.transform.rotation.eulerAngles, new Vector3 (0,0,360 - (hourTime * 30) - (System.DateTime.Now.Minute/2)), spinTransitionSpeed * Time.deltaTime);
//		}

		float hourTime = System.DateTime.Now.Hour;
		if(hourTime >= 12){
			hourTime = hourTime - 12;
		}
		float zHourAngle = 360 - (hourTime * 30) - (System.DateTime.Now.Minute/2);
		if(hourTime == 0){
			HourHand.transform.rotation = Quaternion.Euler(0,0,zHourAngle);
		}else{
			HourHand.transform.eulerAngles = Vector3.Lerp(HourHand.transform.rotation.eulerAngles, new Vector3 (0,0,zHourAngle), spinTransitionSpeed * Time.deltaTime);
		}



//		if(!hourHandIsAlignedToWatchMode){
//			if(HourHand.transform.rotation.eulerAngles.z > (360 - ((hourTime * 30  - (System.DateTime.Now.Minute/2)) + 1)) || HourHand.transform.rotation.eulerAngles.z < ((360 - (hourTime * 30 - (System.DateTime.Now.Minute/2)) - 1))){
//				//HourHand.transform.Rotate(0, 0, (-spinningSpeed * 2) * Time.deltaTime,Space.Self);
//				HourHand.transform.eulerAngles = Vector3.Lerp(HourHand.transform.rotation.eulerAngles, new Vector3 (0,0,360 - (hourTime * 30) - (System.DateTime.Now.Minute/2)), spinTransitionSpeed * Time.deltaTime);
//			}else{
//				hourHandIsAlignedToWatchMode = true;
//			}
//		}else{
//			HourHand.transform.rotation = Quaternion.Euler(0,0,(System.DateTime.Now.Hour * -30) - (System.DateTime.Now.Minute/2));
//		}
	}

	public void determineGameReadyness(){
//		if(secondHandIsAligned){
//			HourHandPretendEnd.transform.localScale = visibleScale;//Show Hour Pretend End
//			SecondsHand.transform.localScale = invisibleScale;//Hide SecondHang 
//			HourHandFrontEnd.transform.localScale = invisibleScale;//Hide Hour Front End
			if(minuteHandIsAligned){
//				MinuteHandBackEnd1.transform.localScale = visibleScale;
//				HourHandPretendEnd.transform.localScale = invisibleScale;
//				StartCoroutine(determineGameReadynessCo()); 
				gameObject.GetComponent<Animator>().enabled = true;
				//StartCoroutine(determineGameReadynessCo()); 
			}


		//Debug.Log(HourHandSprite.transform.position.y);
		if(HourHandSprite.transform.position.y < -2.47){
			SceneManager.LoadScene(1);
		}

//		}

//		if(minuteHandIsAligned && secondHandIsAligned && hourHandIsAligned){
//					
//		}
	}

	private IEnumerator determineGameReadynessCo(){
		yield return new WaitForSeconds (.33f);
		SceneManager.LoadScene(1);
	}

	public void startCameraAnimation(){
		//mainCamera.GetComponent<Animator>().Play("GameStart");
		//flicker();
	}

	public void flicker(){
		StartCoroutine(flickerCo()); 
	}

	private IEnumerator flickerCo(){
		GameInterface.transform.localScale = visibleScale;
		WatchInterface.transform.localScale = invisibleScale;
		yield return new WaitForSeconds (.03f);
		GameInterface.transform.localScale = invisibleScale;
		WatchInterface.transform.localScale = visibleScale;
		yield return new WaitForSeconds (.03f);
		GameInterface.transform.localScale = visibleScale;
		WatchInterface.transform.localScale = invisibleScale;
		yield return new WaitForSeconds (.03f);
		GameInterface.transform.localScale = invisibleScale;
		WatchInterface.transform.localScale = visibleScale;
		yield return new WaitForSeconds (.03f);
		GameInterface.transform.localScale = visibleScale;
		WatchInterface.transform.localScale = invisibleScale;
		yield return new WaitForSeconds (.03f);
		GameInterface.transform.localScale = invisibleScale;
		WatchInterface.transform.localScale = visibleScale;
		yield return new WaitForSeconds (.03f);
		GameInterface.transform.localScale = visibleScale;
		WatchInterface.transform.localScale = invisibleScale;
		yield return new WaitForSeconds (.03f);
		GameInterface.transform.localScale = invisibleScale;
		WatchInterface.transform.localScale = visibleScale;
		yield return new WaitForSeconds (.03f);
		GameInterface.transform.localScale = visibleScale;
		WatchInterface.transform.localScale = invisibleScale;
	}

	public void startGameBuffer(){
		StartCoroutine(startGameBufferCo()); 
	}

	private IEnumerator startGameBufferCo(){
		yield return new WaitForSeconds (1.1f);
		handsCanMove = true;
	}

	public void determineLevelNumber(int PlayerLevel){
		LevelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load (PlayerLevel + "b", typeof(Sprite)) as Sprite;
		//Debug.Log(PlayerLevel + "b");
		lineSpinningSpeed = 80 + (PlayerLevel * 20);
	}

	public void PrepSecondsAndHoursHandForTransition(){
		SecondsHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SecondsHandREVERSE" , typeof(Sprite)) as Sprite;
		if(SecondsHand.transform.rotation.eulerAngles.z > 180){
			SecondsHand.transform.rotation = Quaternion.Euler(0,0,SecondsHand.transform.rotation.eulerAngles.z - 180);
		}else{
			SecondsHand.transform.rotation = Quaternion.Euler(0,0,SecondsHand.transform.rotation.eulerAngles.z + 180);
		}

		HourHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HoursHandREVERSE" , typeof(Sprite)) as Sprite;
		if(HourHand.transform.rotation.eulerAngles.z > 180){
			HourHand.transform.rotation = Quaternion.Euler(0,0,HourHand.transform.rotation.eulerAngles.z - 180);
		}else{
			HourHand.transform.rotation = Quaternion.Euler(0,0,HourHand.transform.rotation.eulerAngles.z + 180);
		}
	}

//	public void shoostHourHandToLowerScreen(){
//
//	}

	public void prepareOuterSlotsForGameMode(){
		StartCoroutine(prepareOuterSlotsForGameModeCo()); 
	}

	private IEnumerator prepareOuterSlotsForGameModeCo(){
		OuterSlot6.SetActive(false);
		yield return new WaitForSeconds (.02f);
		OuterSlot5.SetActive(false);
		OuterSlot7.SetActive(false);
		yield return new WaitForSeconds (.02f);
		OuterSlot4.SetActive(false);
		OuterSlot8.SetActive(false);
		yield return new WaitForSeconds (.02f);
		OuterSlot3.SetActive(false);
		OuterSlot9.SetActive(false);
		yield return new WaitForSeconds (.02f);
		OuterSlot2.SetActive(false);
		OuterSlot10.SetActive(false);
		yield return new WaitForSeconds (.02f);
		OuterSlot1.SetActive(false);
		OuterSlot11.SetActive(false);
		yield return new WaitForSeconds (.02f);
	}
		

}
