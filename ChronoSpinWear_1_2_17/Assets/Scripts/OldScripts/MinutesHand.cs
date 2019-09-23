using UnityEngine;
using System.Collections;

public class MinutesHand : WatchHand {
//
//	public GameObject pivot;
//	float pivotAngle;
//	float angleCompensationAmount;
//
//	void Start () {
//		pivotAngle = pivot.transform.rotation.eulerAngles.z;
//		angleCompensationAmount = 359.99f - pivotAngle;
//	}
//
//	void Update () {
//		spinClockwiseIntoWatchMode(1f);
//	}
//
//	public void spinClockwiseIntoWatchMode(float spinSpeed){
//		float angleToSpinToward = angleCompensationAmount - (System.DateTime.Now.Minute * 6);
//		if(angleToSpinToward <= 0){
//			angleToSpinToward = angleToSpinToward + 360;
//		}
////		if(angleToSpinToward == 357){
////			transform.rotation = Quaternion.Euler(0,0,357);
////		}
//		transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0,0,angleToSpinToward), 3 * Time.deltaTime);
//	}
//
////
//	public void alignWithCurrentTime(float spinSpeed){
////		pivot.transform.rotation.eulerAngles = new Vector3(0,0,0);
////		float angleToSpinToward = 360 - (System.DateTime.Now.Minute * 6);
////		if(angleToSpinToward <= 0){
////			angleToSpinToward = angleToSpinToward + 360;
////		}
////		transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0,0,angleToSpinToward), 1 * Time.deltaTime);
////	}
//	}
}
