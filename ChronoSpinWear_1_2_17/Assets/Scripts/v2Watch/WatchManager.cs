using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WatchManager : MonoBehaviour {

	//CLOCK STUFF
	public WatchHand TopHand1;
	public WatchHand TopHand2;
	public WatchHand MiddleHand1;
	public WatchHand MiddleHand2;
	public WatchHand BottomHand1;
	public WatchHand BottomHand2;
	public NumberShower numberShower;
	public GameObject centerAxis;
	public float centerAxisYPos;

	private bool secondsTimeIsLessThanMinutesTime;
	private bool hoursTimeIsLessThanMinutesTime;
	private bool topHand1IsALesserAngleThanTopHand2;
	private bool middleHand1IsALesserAngleThanMiddleHand2;
	private bool bottomHand1IsALesserAngleThanBottomHand2;
	private bool isWatchMode;
	private bool isGameMode;
	private bool canSwitchBools;
	public bool canStart;
	public bool hasSwipedUp;

	//SPINNING LINE STUFF
	public GameObject SpinningLine;
	public GameObject LevelNumber;
	public float lineSpinningSpeed;

	//OUTER SLOT STUFF
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

	//MISC
	public ColorChanger colorChanger;
	public ColorsMenu colorsMenu;

	public Vector3 _firstTouchPosition;
	public Vector3 _lastTouchPosition;
	public float _minimumDragDistance;

	public float cantTilt;
	public bool canChooseColor = true;
//	void Awake () {
//		colorChanger.determineColor();
//	}

	void Start () {
		//Input.gyro.enabled = true;
		//PlayerPrefs.DeleteAll();
		//PlayerPrefs.SetFloat("PlayerLevel", 0); 
		if(PlayerPrefs.GetFloat("PlayerLevel") < 1){
			PlayerPrefs.SetString("Background","isNotLit");
			PlayerPrefs.SetFloat("PlayerLevel", 1);
			if(TutorialManager.instance != null){
				TutorialManager.instance.startPhrase1();
			}
		}else{
			Destroy(TutorialManager.instance.gameObject);
		}
//		if(PlayerPrefs.GetFloat("cantTilt") == 1){
//			cantTilt = true;
//		}
		StartCoroutine(initiatePreGameBufferCo());
		centerAxisYPos = 290; //centerAxis.transform.position.y;
		_minimumDragDistance = 15;
	}

	void Update () {
		
		//handleDoubleTaps();
		if(!colorsMenu.colorButtons.activeInHierarchy){
//			if(!cantTilt){
//				determinePhonesGravity();
//			}
			handleSwipeGestures();
			//handleDoubleTaps();
#if UNITY_EDITOR
			handleKeyboard();

#endif
		}

		if(canStart && hasSwipedUp){
			isWatchMode = false;
			resetHandsAngleCompensation();
			determineIfTopHand1IsALesserAngleThanTopHand2();
			StartCoroutine(startGameCo());
			numberShower.determinePlayerLevel();
			isGameMode = true;
		}

		if(isWatchMode){
			spinTopHandsClockwiseToWatchMode();
			spinMiddleHandsClockwiseToWatchMode();
			spinBottomHandsClockwiseToWatchMode();
			spinLineForWatchMode();
			numberShower.spinIntoWatchPosition();
		}else if(isGameMode){
			spinTopHandsClockwiseToGameMode();
			spinMiddleHandsClockwiseToGameMode();
			spinBottomHandsClockwiseToGameMode();
			spinLineIntoGamePosition();
			numberShower.spinIntoGamePosition();
		}	
	}

	public void startGameBro(){
		isWatchMode = false;
		resetHandsAngleCompensation();
		determineIfTopHand1IsALesserAngleThanTopHand2();
		StartCoroutine(startGameCo());
		numberShower.determinePlayerLevel();
		isGameMode = true;
		spinTopHandsClockwiseToGameMode();
		spinMiddleHandsClockwiseToGameMode();
		spinBottomHandsClockwiseToGameMode();
		spinLineIntoGamePosition();
		numberShower.spinIntoGamePosition();
	}

	public void handleKeyboard(){
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			isWatchMode = true;
			isGameMode = false;
		}else if (Input.GetKeyDown(KeyCode.Alpha2)){
			isWatchMode = false;
			resetHandsAngleCompensation();
			determineIfTopHand1IsALesserAngleThanTopHand2();
			StartCoroutine(startGameCo());
			numberShower.determinePlayerLevel();
			isGameMode = true;
		}
	}

	public void handleDoubleTaps(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(0);
			if (touch.tapCount >= 2){
				colorChanger.chooseNextColor();
			}
//			print("centerAxisYPos " + centerAxisYPos);
//			print("touch.position.y " + touch.position.y);
		}
	}


	public void handleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); 
				if(touchPosition.y > 0){
					colorChanger.chooseNextColor();
				}else if(touchPosition.y < 0 && touchPosition.y > -3){
					isWatchMode = false;
					resetHandsAngleCompensation();
					determineIfTopHand1IsALesserAngleThanTopHand2();
					StartCoroutine(startGameCo());
					numberShower.determinePlayerLevel();
					isGameMode = true;
				}
			}
		}
	}

	private void handleSwipeGestures(){
		if (Input.touchCount == 1){
			numberShower.determineDate();
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began){
				_firstTouchPosition = touch.position;
				_lastTouchPosition = touch.position;
			}
//			else if (touch.phase == TouchPhase.Moved){
//				_lastTouchPosition = touch.position;
//			}
			else if (touch.phase == TouchPhase.Moved){
				_lastTouchPosition = touch.position;  
				if (Mathf.Abs(_lastTouchPosition.x - _firstTouchPosition.x) > _minimumDragDistance || Mathf.Abs(_lastTouchPosition.y - _firstTouchPosition.y) > _minimumDragDistance){
					if (Mathf.Abs(_lastTouchPosition.x - _firstTouchPosition.x) > Mathf.Abs(_lastTouchPosition.y - _firstTouchPosition.y)){
						if ((_lastTouchPosition.x > _firstTouchPosition.x)){   
							//Right swipe
						}else{   
							//Left swipe
						}
					}else{
						if (_lastTouchPosition.y > _firstTouchPosition.y){
							//Up Swipe
							hasSwipedUp = true;
//							isWatchMode = false;
//							resetHandsAngleCompensation();
//							determineIfTopHand1IsALesserAngleThanTopHand2();
//							StartCoroutine(startGameCo());
//							numberShower.determinePlayerLevel();
//							isGameMode = true;
						}else{
							//Down swipe
							if(canChooseColor){
								colorChanger.chooseNextColor();
								canChooseColor = false;
							}
						}
					}
				}else{   
					//It's a tap as the drag distance is less than 20% of the screen height
				}
			}else if (touch.phase == TouchPhase.Ended){
				canChooseColor = true;
			}
		}
	}

	public void startGame(){
		isWatchMode = false;
		resetHandsAngleCompensation();
		determineIfTopHand1IsALesserAngleThanTopHand2();
		StartCoroutine(startGameCo());
		numberShower.determinePlayerLevel();
		isGameMode = true;
	}


		
	//CLOCK STUFF
	public void spinTopHandsClockwiseToWatchMode(){
		if(secondsTimeIsLessThanMinutesTime){
			if(System.DateTime.Now.Minute - System.DateTime.Now.Second == 0){
				canSwitchBools = true;
			}else if(canSwitchBools && System.DateTime.Now.Minute - System.DateTime.Now.Second == -1){
				secondsTimeIsLessThanMinutesTime = false;
				canSwitchBools = false;
			}else{
				TopHand2.spinClockwiseIntoWatchModePosition(System.DateTime.Now.Minute, 6);
				TopHand1.spinClockwiseIntoWatchModePosition(System.DateTime.Now.Second, 6);
			}

		}else{
			if(System.DateTime.Now.Minute - System.DateTime.Now.Second == 0){
				canSwitchBools = true;
			}else if(canSwitchBools && System.DateTime.Now.Minute - System.DateTime.Now.Second == -1){
				secondsTimeIsLessThanMinutesTime = true;
				canSwitchBools = false;
			}else{
				TopHand1.spinClockwiseIntoWatchModePosition(System.DateTime.Now.Minute, 6);
				TopHand2.spinClockwiseIntoWatchModePosition(System.DateTime.Now.Second, 6);
			}
		}
	}

	public void spinMiddleHandsClockwiseToWatchMode(){
		float minuteTime = System.DateTime.Now.Minute;
		float hourTime = System.DateTime.Now.Hour;
		if(hourTime >= 12){
			hourTime = hourTime - 12;
		}
		hourTime = hourTime + (minuteTime/60);
		if(hoursTimeIsLessThanMinutesTime){
			MiddleHand2.spinClockwiseIntoWatchModePosition(hourTime, 30);
			MiddleHand1.spinClockwiseIntoWatchModePosition(minuteTime, 6);
			//Debug.Log("spinMiddleHandsClockwiseToWatchMode CASE 1");
		}else{
			MiddleHand2.spinClockwiseIntoWatchModePosition(minuteTime, 6);
			MiddleHand1.spinClockwiseIntoWatchModePosition(hourTime, 30);
			//Debug.Log("spinMiddleHandsClockwiseToWatchMode CASE 2");
		}
	}

	public void spinBottomHandsClockwiseToWatchMode(){
		float minuteTime = System.DateTime.Now.Minute;
		float hourTime = System.DateTime.Now.Hour;
		if(hourTime >= 12){
			hourTime = hourTime - 12;
		}
		hourTime = hourTime + (minuteTime/60);
		if(hoursTimeIsLessThanMinutesTime){
			BottomHand2.spinClockwiseIntoWatchModePosition(hourTime, 30);
			BottomHand1.spinClockwiseIntoWatchModePosition(minuteTime, 6);
			//Debug.Log("spinBottomHandsClockwiseToWatchMode CASE 1");
		}else{
			BottomHand2.spinClockwiseIntoWatchModePosition(minuteTime, 6);
			BottomHand1.spinClockwiseIntoWatchModePosition(hourTime, 30);
			//Debug.Log("spinBottomHandsClockwiseToWatchMode CASE 2");
		}
	}

	public void spinTopHandsClockwiseToGameMode(){
		if(topHand1IsALesserAngleThanTopHand2){
			TopHand1.spinClockwiseIntoGameModePosition(315);
			TopHand2.spinClockwiseIntoGameModePosition(45);
			//Debug.Log(" spinTopHandsClockwiseToGameMode CASE 1");
		}else{
			TopHand1.spinClockwiseIntoGameModePosition(45);
			TopHand2.spinClockwiseIntoGameModePosition(315);
			//Debug.Log(" spinTopHandsClockwiseToGameMode CASE 2");
		}
	}

	public void spinMiddleHandsClockwiseToGameMode(){
		if(middleHand1IsALesserAngleThanMiddleHand2){
			MiddleHand1.spinClockwiseIntoGameModePosition(225);
			MiddleHand2.spinClockwiseIntoGameModePosition(135);
			//Debug.Log(" spinMiddleHandsClockwiseToGameMode CASE 1");
		}else{
			MiddleHand1.spinClockwiseIntoGameModePosition(135);
			MiddleHand2.spinClockwiseIntoGameModePosition(225);
			//Debug.Log(" spinMiddleHandsClockwiseToGameMode CASE 2");
		}
	}

	public void spinBottomHandsClockwiseToGameMode(){
		if(bottomHand1IsALesserAngleThanBottomHand2){
			BottomHand1.spinClockwiseIntoGameModePosition(180);
			BottomHand2.spinClockwiseIntoGameModePosition(0);
			//Debug.Log(" spinBottomHandsClockwiseToGameMode CASE 1");
		}else{
			BottomHand1.spinClockwiseIntoGameModePosition(0);
			BottomHand2.spinClockwiseIntoGameModePosition(180);
			//Debug.Log(" spinMiddleHandsClockwiseToGameMode CASE 2");
		}
	}

	public void determineIfSecondsTimeIsLessThanMinutesTime(){
		float secondsTime = System.DateTime.Now.Second;
		float minutesTime = System.DateTime.Now.Minute;
		if(secondsTime < minutesTime){
			secondsTimeIsLessThanMinutesTime = true;
			//secondsHand angle will be greater than minutesHand angle
		}
	}

	public void determineIfHoursTimeIsLessThanMinutesTime(){
		float hoursTime = System.DateTime.Now.Hour * 5;
		if(hoursTime >= 60){
			hoursTime = hoursTime - 60;
		}
		float minutesTime = System.DateTime.Now.Minute;
		if(hoursTime < minutesTime){
			hoursTimeIsLessThanMinutesTime = true;
			//hoursHand angle will be greater than minutesHand angle
		}
		//Debug.Log("hoursTimeIsLessThanMinutesTime = " + hoursTimeIsLessThanMinutesTime);
	}

	public void determineIfTopHand1IsALesserAngleThanTopHand2(){
		float topHand1Angle = TopHand1.transform.rotation.eulerAngles.z;
		float topHand2Angle = TopHand2.transform.rotation.eulerAngles.z;
		if(topHand1Angle < topHand2Angle){
			topHand1IsALesserAngleThanTopHand2 = true;
		}
	}

	public void determineIfMiddleHand1IsALesserAngleThanMiddleHand2(){
		float middleHand1Angle = MiddleHand1.transform.rotation.eulerAngles.z;
		float middleHand2Angle = MiddleHand2.transform.rotation.eulerAngles.z;
		if(middleHand1Angle < middleHand2Angle){
			middleHand1IsALesserAngleThanMiddleHand2 = true;
		}
	}

	public void resetHandsAngleCompensation(){
		TopHand1.resetAngleCompensation();
		TopHand2.resetAngleCompensation();
		MiddleHand1.resetAngleCompensation();
		MiddleHand2.resetAngleCompensation();
		BottomHand1.resetAngleCompensation();
		BottomHand2.resetAngleCompensation();
	}

	//SPINNING LINE STUFF
	public void determineLevelNumber(int PlayerLevel){
		LevelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load (PlayerLevel + "b", typeof(Sprite)) as Sprite;
		lineSpinningSpeed = 80 + (PlayerLevel * 20);
		//Debug.Log(PlayerLevel + "b");
	}

	public void spinLineForWatchMode(){
		SpinningLine.transform.Rotate(0, 0, -lineSpinningSpeed * Time.deltaTime,Space.Self);
	}

	public void spinLineIntoGamePosition(){
		SpinningLine.transform.eulerAngles = Vector3.Lerp(SpinningLine.transform.rotation.eulerAngles, new Vector3 (0,0,0), 10 * Time.deltaTime);
	}

	//OUTER CIRCLE STUFF
	private IEnumerator prepareOuterSlotsForGameModeCo(){
		bool isGoingToWatchMode = false;
		float waitTime = .025f;
		OuterSlot1.SetActive(isGoingToWatchMode);
		yield return new WaitForSeconds (waitTime);
		OuterSlot2.SetActive(isGoingToWatchMode);
		yield return new WaitForSeconds (waitTime);
		OuterSlot3.SetActive(isGoingToWatchMode);
		yield return new WaitForSeconds (waitTime);
		OuterSlot4.SetActive(isGoingToWatchMode);
		yield return new WaitForSeconds (waitTime);
		OuterSlot5.SetActive(isGoingToWatchMode);
		yield return new WaitForSeconds (waitTime);
		OuterSlot6.SetActive(isGoingToWatchMode);
		yield return new WaitForSeconds (waitTime);
		OuterSlot7.SetActive(isGoingToWatchMode);
		yield return new WaitForSeconds (waitTime);
		OuterSlot8.SetActive(isGoingToWatchMode);
		yield return new WaitForSeconds (waitTime);
		OuterSlot9.SetActive(isGoingToWatchMode);
		yield return new WaitForSeconds (waitTime);
		OuterSlot10.SetActive(isGoingToWatchMode);
		yield return new WaitForSeconds (waitTime);
		OuterSlot11.SetActive(isGoingToWatchMode);
	}

	private IEnumerator prepareOuterSlotsForWatchModeCo(){
		float waitTime = .025f;
		OuterSlot1.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		yield return new WaitForSeconds (waitTime);
		OuterSlot2.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		yield return new WaitForSeconds (waitTime);
		OuterSlot3.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		yield return new WaitForSeconds (waitTime);
		OuterSlot4.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		yield return new WaitForSeconds (waitTime);
		OuterSlot5.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		yield return new WaitForSeconds (waitTime);
		OuterSlot6.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		canStart = true;
		yield return new WaitForSeconds (waitTime);
		OuterSlot7.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		yield return new WaitForSeconds (waitTime);
		OuterSlot8.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		yield return new WaitForSeconds (waitTime);
		OuterSlot9.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		yield return new WaitForSeconds (waitTime);
		OuterSlot10.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		yield return new WaitForSeconds (waitTime);
		OuterSlot11.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
	}

	private IEnumerator startGameCo(){
		StartCoroutine(prepareOuterSlotsForGameModeCo()); 
		yield return new WaitForSeconds (0.6f);
		//yield return new WaitForSeconds (1.2f);
		SceneManager.LoadScene(1);
		//Debug.Log("startGameCo");
	}

	private IEnumerator initiatePreGameBufferCo(){
		yield return new WaitForSeconds (.05f);
		determineIfSecondsTimeIsLessThanMinutesTime();
		determineIfHoursTimeIsLessThanMinutesTime();
		determineLevelNumber(PlayerPrefs.GetInt("PlayerLevel"));
		isWatchMode = true;
		StartCoroutine(prepareOuterSlotsForWatchModeCo()); 
	}

	public void determinePhonesGravity(){
		if(Input.gyro.gravity.y > .3f){
			startGameBro();
		}
	}
}
