using UnityEngine;
using System.Collections;

public class Rail : MonoBehaviour {

	public Vector3 watchPosition;
	public Vector3 watchRotation;

	public Vector3 startGamePosition;
	public Vector3 startGameRotation;

	public Vector3 gamePosition;
	public Vector3 gameRotation;

	public Vector3 startWatchPosition;
	public Vector3 startWatchRotation;

	public bool canFan;

	public bool rotationIsAligned;
	public bool positionIsAligned;
	public float spinningSpeed;

	public int angleToBeAt;
	public float yPositionToBeAt;

	public Vector3 actualUp = new Vector3 (0,-1,0);

	public bool willDisapear;

	void Start () {
		rotationIsAligned = false;
		spinningSpeed = 100;
		startGameRotation = new Vector3 (0,0,angleToBeAt);
		gamePosition = new Vector3(0,yPositionToBeAt,0);
	}

	void Update () {
		HandleKeyboard();
		if(canFan){
			fanToStartGamePosition();
		}
	}

	public void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.F)) {
			canFan = true;
		}
	}

	public void fanToStartGamePosition(){
		if(!rotationIsAligned){
			if(transform.rotation.eulerAngles.z > angleToBeAt + .5f){
				//transform.Rotate(0, 0, (-spinningSpeed)* Time.deltaTime,Space.Self);
				transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, startGameRotation, 10 * Time.deltaTime);
			}
			else{
				gameObject.SetActive(false);
				rotationIsAligned = true;
			}
		}else{
//			transform.rotation = Quaternion.Euler(0,0, angleToBeAt);
//			if(willDisapear){
				gameObject.SetActive(false);
//			}
		} 
	}


}
