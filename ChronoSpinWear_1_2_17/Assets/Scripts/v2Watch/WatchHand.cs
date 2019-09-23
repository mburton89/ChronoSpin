using UnityEngine;
using System.Collections;

public class WatchHand : MonoBehaviour {

	public GameObject Pivot;
	public float pivotAngle;
	public float angleCompensationAmount;
	private float spinSpeed = 10;
	//private float spinSpeed = 5;

	public Vector3 gameModePosition;
	public Vector3 watchModePosition;
	public Vector3 levelUpPosition;

	void Start () {
		angleCompensationAmount = 359.99f - pivotAngle;
	}
		
	public void spinClockwiseIntoWatchModePosition(float timeTypeTime, float ThreeSixityDividedByNumberOfTimeTypesInAnHour){
		float angleToSpinToward = angleCompensationAmount - (timeTypeTime * ThreeSixityDividedByNumberOfTimeTypesInAnHour);
		if(angleToSpinToward <= 0){
			angleToSpinToward = angleToSpinToward + 360;
		}
		if(angleToSpinToward > 355){
			transform.rotation = Quaternion.Euler(0,0,356.99f);
		}
		transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0,0,angleToSpinToward), spinSpeed/2 * Time.deltaTime);
	}

	public void resetAngleCompensation(){
		float anglesToAddToPivot = 359.99f - transform.rotation.eulerAngles.z;
		transform.rotation = Quaternion.Euler(0,0,359.99f);
		Pivot.transform.rotation = Quaternion.Euler(0,0,Pivot.transform.rotation.eulerAngles.z - anglesToAddToPivot);
		angleCompensationAmount = 359.99f - Pivot.transform.rotation.eulerAngles.z;
	}

	public void spinClockwiseIntoGameModePosition(float desiredPositionToSpinTo){
		float angleToSpinToward = angleCompensationAmount - (360 - desiredPositionToSpinTo);
		if(angleToSpinToward <= 0){
			angleToSpinToward = angleToSpinToward + 360;
		}
		transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0,0,angleToSpinToward), spinSpeed * Time.deltaTime);
	}

	public void slideDownIntoGamePosition(){
		transform.position = Vector3.MoveTowards(transform.position, gameModePosition, .1f);
	}

	public void slideUpIntoWatchPosition(){
		transform.position = Vector3.MoveTowards(transform.position, watchModePosition, .1f);
	}

	public void slideIntoLevelUpPosition(bool areLowerHands){
		transform.position = Vector3.MoveTowards(transform.position, levelUpPosition, .1f);
		if(areLowerHands){
			transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0,0,pivotAngle), spinSpeed * Time.deltaTime);
		}
	}
}
