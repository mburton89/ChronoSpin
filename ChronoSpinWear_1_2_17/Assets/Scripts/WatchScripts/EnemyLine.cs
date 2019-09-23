using UnityEngine;
using System.Collections;

public class EnemyLine : MonoBehaviour {

	public int spinningSpeed;
	private bool lineIsAligned;

	void Start () {
	
	}
		
	public void Update(){
		spin();
	}

	public void testSpin(){
//		if (rotating){
//			Vector3 to = new Vector3(20, 20, 90);
//			if (Vector3.Distance(transform.eulerAngles, to) > 10.01f){
//				//transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, spinningSpeed);
//				//transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
//				//transform.Rotate(0, 0, spinningSpeed * Time.deltaTime,Space.Self); 
//			}else{
//				transform.eulerAngles = to;
//				rotating = false;
//			}
//		}
	}

	public void spin(){
		transform.Rotate(0, 0, (spinningSpeed)* Time.deltaTime,Space.Self);
	}

	public void spinCounterClockwise180(){
		if(!lineIsAligned){
			if(transform.rotation.eulerAngles.z > 182 || transform.rotation.eulerAngles.z < 155){
				transform.Rotate(0, 0, (spinningSpeed)* Time.deltaTime,Space.Self);
			}
			else{
				lineIsAligned = true;
			}
		}else{
			transform.rotation = Quaternion.Euler(0,0,0);
		}  
	}

	public void spinClockwise180(){
		if(!lineIsAligned){
			if(transform.rotation.eulerAngles.z > 182 || transform.rotation.eulerAngles.z < 155){
				transform.Rotate(0, 0, (-spinningSpeed)* Time.deltaTime,Space.Self);
			}else{
				lineIsAligned = true;
			}
		}else{
			transform.rotation = Quaternion.Euler(0,0,0);
		}  
	}
}
