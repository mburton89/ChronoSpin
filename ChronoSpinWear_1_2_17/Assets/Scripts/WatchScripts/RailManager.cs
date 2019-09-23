using UnityEngine;
using System.Collections;

public class RailManager : MonoBehaviour {
	
	public GameObject topLeftRails;
	public GameObject topRightRails;
	public GameObject bottomLeftRails;
	public GameObject bottomRightRails;

	public bool topLeftpositionIsAligned;
	public bool topRightpositionIsAligned;
	public bool bottomLeftpositionIsAligned;
	public bool bottomRightpositionIsAligned;

	public float topPositionToBeAt;
	public float bottomPositionToBeAt;

	public bool canMove;
	public bool canShrink;
	public Vector3 topGamePosition;
	public Vector3 bottomGamePosition;

	public GameObject Dial;
	public GameObject OuterDial;

	void Start () {
		topGamePosition = new Vector3(0,topPositionToBeAt,0);
		bottomGamePosition = new Vector3(0,bottomPositionToBeAt,0);
	}

	void Update () {

		HandleKeyboard();
		if(canMove){
			moveIntoGamePosition();
		}
		if(canShrink){
			shrinkDial();
		}
	}

	public void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.M)) {
			canMove = true;
		} else if(Input.GetKeyDown(KeyCode.D)) {
			canShrink = true;
		}
	}

	public void moveIntoGamePosition(){
		moveTopLeftRailsIntoGamePosition();
		moveTopRightRailsIntoGamePosition();
		moveBottomLeftRailsIntoGamePosition();
		moveBottomRightRailsIntoGamePosition();
	}

	public void moveTopLeftRailsIntoGamePosition(){
		if(!topLeftpositionIsAligned){
			if(topLeftRails.transform.position.y < topGamePosition.y){
				//topLeftRails.transform.Translate(Vector3.up * Time.deltaTime);
				topLeftRails.transform.Translate(Vector3.up * .1f);
				//topLeftRails.transform.position = new Vector3(0,topGamePosition.y/2,0);
				//topLeftRails.transform.position = Vector3.Lerp(transform.position, topGamePosition, 5 * Time.deltaTime);
			}
			else{
				topLeftpositionIsAligned = true;
			}
		}else{
			topLeftRails.transform.position = topGamePosition;
		} 
	}

	public void moveTopRightRailsIntoGamePosition(){
		if(!topRightpositionIsAligned){
			if(topRightRails.transform.position.y < topGamePosition.y){
				//topRightRails.transform.Translate(Vector3.up * Time.deltaTime);
				topRightRails.transform.Translate(Vector3.up * .1f);
			}
			else{
				topRightpositionIsAligned = true;
			}
		}else{
			topRightRails.transform.position = topGamePosition;
		} 
	}

	public void moveBottomLeftRailsIntoGamePosition(){
		if(!bottomLeftpositionIsAligned){
			if(bottomLeftRails.transform.position.y > bottomGamePosition.y){
				//bottomLeftRails.transform.Translate(Vector3.down * Time.deltaTime);
				bottomLeftRails.transform.Translate(Vector3.down * .1f);
			}
			else{
				bottomLeftpositionIsAligned = true;
			}
		}else{
			bottomLeftRails.transform.position = bottomGamePosition;
		} 
	}

	public void moveBottomRightRailsIntoGamePosition(){
		if(!bottomRightpositionIsAligned){
			if(bottomRightRails.transform.position.y > bottomGamePosition.y){
				//bottomRightRails.transform.Translate(Vector3.down * Time.deltaTime);
				bottomRightRails.transform.Translate(Vector3.down * .1f);
			}
			else{
				bottomRightpositionIsAligned = true;
			}
		}else{
			bottomRightRails.transform.position = bottomGamePosition;
		} 
	}

	public void shrinkDial(){
		if(Dial.transform.localScale.y > 0){
			Dial.transform.localScale -= Vector3.one * .05f;
		}
		if(OuterDial.transform.localScale.y < 10){
			OuterDial.transform.localScale += Vector3.one * .5f;
		}
	}
}
