using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpinningLine : MonoBehaviour {

	//public Animator Animator; 
	public AudioClip Bass;
	public AudioClip Snare;
	public int spinningSpeed;
	public bool canSpin;

	public GameObject leftSide;
	public GameObject rightSide;
	//public AudioSource AudioSource;

	public MusicManager musicManager;
	public CameraPivot gameCamera;

	private bool isLit;

	public bool isSpinningClockwise;
	public bool isCCW;

	void Start () {
		//spinningSpeed = 200;

		//if(Application.loadedLevel != 0){
		//canSpin = true;
		//}
		//Animator.enabled = false;
		canSpin = true;
		isSpinningClockwise = true;
		waitToSpin();
	}

	void Update () {
	
		if(canSpin){
            //darkenBothSides();
#if UNITY_EDITOR
			HandleKeyboard();
#endif
			HandleUserTouches();
			//determineDirectionToSpin();

			//transform.Rotate(0, 0, spinningSpeed * Time.deltaTime,Space.Self);
			//determineSpinning();
			//determineSound();
			//AudioSource.enabled = false;
		}else{
			//determineRemainingDistanceToSpin();
			//Animator.enabled = true;
			spinningSpeed = 0;
			if(transform.rotation.eulerAngles.z < 359.99f){
				transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3 (0,0,360), 10 * Time.deltaTime);
			}
			//gameObject.GetComponentInChildren<Animator>().enabled = true;
			//Animator.SetTrigger("LineVanish");
			//gameObject.GetComponentInChildren<Animator>().SetTrigger("LineVanish");
		}
	}

//	public void HandleKeyboard(){
//		if (Input.GetKey(KeyCode.LeftArrow)) {
//			spinLineCounterClockwise();
//			//AudioSource.enabled = true;
//		}else{
//			spinLineClockwise();
//		}
//	} 

	public void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			isSpinningClockwise = !isSpinningClockwise;
		}
	} 

	public void determineDirectionToSpin(){
		if(isSpinningClockwise){
			spinLineClockwise();
		}else{
			spinLineCounterClockwise();
		}
	}
	
//		public void HandleUserTouches(){
//			for (int i = 0; i < Input.touchCount; i++){  
//				Touch touch = Input.GetTouch(i);
//				if (touch.phase != TouchPhase.Ended){
//					spinLineCounterClockwise();
//				}else{
//					spinLineClockwise();
//				}
//			}
//		}
	
//	public void HandleUserTouches(){
// 		if(Input.touchCount > 0){
//			spinLineCounterClockwise();
// 		}else{
//			spinLineClockwise();
// 		}
//	}
//
//	public void HandleUserTouches(){
//		if(Input.touchCount > 0){
//			Touch touch = Input.GetTouch(0);
//			if(touch.phase == TouchPhase.Began){
//				isSpinningClockwise = !isSpinningClockwise;
//			}		
//		}
//	}

	public void HandleUserTouches(){
		spinLineClockwise();
 		if(Input.touchCount > 0){
			spinningSpeed = -174;
 		}else{
			spinningSpeed = 174;
 		}
	}

	public void determineSpinning(){
		
	}

	public void spinOnMenu(){
		transform.Rotate(0, 0, -spinningSpeed* Time.deltaTime,Space.Self);
	}

	public void spinLineClockwise(){
		//gameCamera.transform.Rotate(0, 0, -spinningSpeed* Time.deltaTime,Space.Self);   
		transform.Rotate(0, 0, -spinningSpeed * Time.deltaTime,Space.Self);    
		//lightUpRightSide();
	}
	       
	public void spinLineCounterClockwise(){
		//gameCamera.transform.Rotate(0, 0, spinningSpeed* Time.deltaTime,Space.Self); 
		transform.Rotate(0, 0, spinningSpeed * Time.deltaTime,Space.Self); 
		//lightUpLeftSide();
	}

	public void lightUpLeftSide(){
		leftSide.GetComponent<SpriteRenderer>().enabled = true;
		rightSide.GetComponent<SpriteRenderer>().enabled = false;
		isLit = true;
	}

	public void lightUpRightSide(){
		rightSide.GetComponent<SpriteRenderer>().enabled = true;
		leftSide.GetComponent<SpriteRenderer>().enabled = false;
		isLit = true;
	}

	public void darkenBothSides(){
		leftSide.GetComponent<SpriteRenderer>().enabled = false;
		rightSide.GetComponent<SpriteRenderer>().enabled = false;
		isLit = false;
		//spinLineClockwise();
	}

	public void determineRemainingDistanceToSpin(){
		int currentSpinningRotation = (int)Math.Ceiling(transform.rotation.eulerAngles.z);
		int remainingDistanceToSpin = currentSpinningRotation % 180;   
//		if(remainingDistanceToSpin != 45){
//			transform.Rotate(0, 0, (200)* Time.deltaTime,Space.Self);
//		}

		if(remainingDistanceToSpin < 40 || remainingDistanceToSpin > 50){
			transform.Rotate(0, 0, (200)* Time.deltaTime,Space.Self);
		}

		Debug.Log((remainingDistanceToSpin) + " REMAINDER");       
		
//		if(remainingDistanceToSpin != 45){
//			transform.Rotate(0, 0, (spinningSpeed)* Time.deltaTime,Space.Self);
//		}
	}

	public void rotateStartGame(){
		//Animator.SetTrigger("RotateAgainstCamera");   
	}    

	public void initiateStartGameAnimtaion(){
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
//		Animator.enabled = true;
//		Animator.SetTrigger("lineStartGame");   
	}

	public void flicker(){
		StartCoroutine(flickerCo()); 
	}
	
	private IEnumerator flickerCo(){ 
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (.025f);
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (.025f);
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (.025f);
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (.025f);
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (.025f);
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (.025f);
	}
//
//	public void determineSound(){
//		if(isLit){
//			AudioSource.volume = 0.17f;
//			//AudioSource.enabled = true;
//		}else{
//			AudioSource.volume = 0.05f;
//			//AudioSource.enabled = false;
//		}
//	}

	public void waitToSpin(){
		StartCoroutine(waitToSpinCo()); 
	}

	private IEnumerator waitToSpinCo(){ 
		yield return new WaitForSeconds (.05f);
		spinningSpeed = 174;
	}
}
