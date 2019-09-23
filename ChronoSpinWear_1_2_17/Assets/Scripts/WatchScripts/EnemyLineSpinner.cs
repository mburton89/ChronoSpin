using UnityEngine;
using System.Collections;

public class EnemyLineSpinner : MonoBehaviour {

	public EnemyLine TopEnemyLine;
	public EnemyLine LeftEnemyLine;
	public EnemyLine RightEnemyLine;

	public bool canSwitchDirections;
	public int spinningSpeed;
	bool canSpin;

	bool isTopsTurn;

	private static System.Random random = new System.Random();

	void Start () {
		canSpin = true;
		isTopsTurn = true;
	}

	void Update () {
//		spinTopLine();
//		decideToChangeDirectionsAt0();
//		resetCanSwitchDirections();
//
		determineReset();
		determineIfCanSpin();
		HandleLines();
		//HandleTopLineSpinning();
		//HandleKeyboard();
	}

	public void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			resetLinesBackToZero();
		} 
	}

	public void spinTopLine(){
		TopEnemyLine.spin();
	}

	public void spinRightLine(){
		//RightLine.spin();
	}

	public void HandleTopLineSpinning(){
		if(TopEnemyLine.spinningSpeed < 0){
			HandleTopLineCounterClockwiseSpinning();
		}else{
			HandleTopLineClockwiseSpinning();
		}
	}

	public void HandleTopLineClockwiseSpinning(){
		if(canSwitchDirections && TopEnemyLine.transform.rotation.eulerAngles.z >= 90 && TopEnemyLine.transform.rotation.eulerAngles.z < 130){
			determineAndInitiateDirectionChange();
		}else if(canSwitchDirections && TopEnemyLine.transform.rotation.eulerAngles.z >= 270 && TopEnemyLine.transform.rotation.eulerAngles.z < 300){
			determineAndInitiateDirectionChange();
		}else if(TopEnemyLine.transform.rotation.eulerAngles.z >= 180 && TopEnemyLine.transform.rotation.eulerAngles.z < 220){
			canSwitchDirections = true;
		}else if(TopEnemyLine.transform.rotation.eulerAngles.z >= 0 && TopEnemyLine.transform.rotation.eulerAngles.z < 40){
			canSwitchDirections = true;
		}
	}

	public void HandleTopLineCounterClockwiseSpinning(){
		if(canSwitchDirections && TopEnemyLine.transform.rotation.eulerAngles.z <= 90 && TopEnemyLine.transform.rotation.eulerAngles.z > 50){
			determineAndInitiateDirectionChange();
		}else if(canSwitchDirections && TopEnemyLine.transform.rotation.eulerAngles.z <= 270 && TopEnemyLine.transform.rotation.eulerAngles.z > 230){
			determineAndInitiateDirectionChange();
		}else if(TopEnemyLine.transform.rotation.eulerAngles.z <= 180 && TopEnemyLine.transform.rotation.eulerAngles.z > 140){
			canSwitchDirections = true;
		}else if(TopEnemyLine.transform.rotation.eulerAngles.z <= 360 && TopEnemyLine.transform.rotation.eulerAngles.z > 320){
			canSwitchDirections = true;
		}
	}

	public void determineAndInitiateDirectionChange(){
		float sequenceNumber = random.Next (1, 3);
		if(sequenceNumber == 1){
			TopEnemyLine.spinningSpeed = -TopEnemyLine.spinningSpeed;
		}
		canSwitchDirections = false;
	}

	public void HandleLines(){
		if(canSpin){
			float sequenceNumber = random.Next (1, 5);
			//sequenceNumber = 3;
			if(sequenceNumber == 1){
				LeftEnemyLine.spinningSpeed = -spinningSpeed;
				TopEnemyLine.spinningSpeed = -spinningSpeed;
				RightEnemyLine.spinningSpeed = 0;
			}else if (sequenceNumber == 2){
				LeftEnemyLine.spinningSpeed = -spinningSpeed;
				TopEnemyLine.spinningSpeed = -spinningSpeed;
				RightEnemyLine.spinningSpeed = 0;
			}else if (sequenceNumber == 3){
				LeftEnemyLine.spinningSpeed = 0;
				TopEnemyLine.spinningSpeed = -spinningSpeed;
				RightEnemyLine.spinningSpeed = spinningSpeed;
			}else if (sequenceNumber == 4){
				LeftEnemyLine.spinningSpeed = 0;
				TopEnemyLine.spinningSpeed = -spinningSpeed;
				RightEnemyLine.spinningSpeed = spinningSpeed;
			}
			canSpin = false;
		}
	}

	public void HandleLines2(){
		if(canSpin){
			if(isTopsTurn){
				LeftEnemyLine.spinningSpeed = 0;
				RightEnemyLine.spinningSpeed = 0;
				float sequenceNumber3 = random.Next (1, 3);
				if(sequenceNumber3 == 1){
					TopEnemyLine.spinningSpeed = spinningSpeed;
				}else{
					TopEnemyLine.spinningSpeed = -spinningSpeed;
				}
				isTopsTurn = false;
			}else{
				TopEnemyLine.spinningSpeed = 0;
				float sequenceNumber4 = random.Next (1, 3);
				if(sequenceNumber4 == 1){
					LeftEnemyLine.spinningSpeed = -spinningSpeed;
				}else{
					RightEnemyLine.spinningSpeed = spinningSpeed;
				}
				isTopsTurn = true;
			}
			canSpin = false;
		}
	}

	public void determineIfCanSpin(){
		if(LeftEnemyLine.transform.rotation.eulerAngles.z == 0
			&& TopEnemyLine.transform.rotation.eulerAngles.z == 0
			&& RightEnemyLine.transform.rotation.eulerAngles.z == 0){
			canSpin = true;
		}
	}

	public void resetLinesBackToZero(){
		//Debug.Log("RESET");

		LeftEnemyLine.spinningSpeed = 0;
		TopEnemyLine.spinningSpeed  = 0;
		RightEnemyLine.spinningSpeed  = 0;

		LeftEnemyLine.transform.eulerAngles = new Vector3(0,0,0);
		TopEnemyLine.transform.eulerAngles = new Vector3(0,0,0);
		RightEnemyLine.transform.eulerAngles = new Vector3(0,0,0);
	}

	public void determineReset(){
		//Clockwise
		if(TopEnemyLine.spinningSpeed > 0){
			if(TopEnemyLine.transform.rotation.eulerAngles.z >= 180){
				resetLinesBackToZero();
			}
		//CounterClockwise
		}else if(TopEnemyLine.spinningSpeed < 0){
			if(TopEnemyLine.transform.rotation.eulerAngles.z <= 180){
				resetLinesBackToZero();
			}
		}

//		else{
//			if(LeftEnemyLine.spinningSpeed > 0){
//				if(LeftEnemyLine.transform.rotation.eulerAngles.z >= 180){
//					resetLinesBackToZero();
//				}
//			}else if(RightEnemyLine.spinningSpeed < 0){
//				if(LeftEnemyLine.transform.rotation.eulerAngles.z <= 180){
//					resetLinesBackToZero();
//				}
//			}
//		}
	}
}
