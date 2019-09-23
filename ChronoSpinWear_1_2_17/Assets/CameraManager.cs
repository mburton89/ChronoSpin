using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public static CameraManager instance;

	public Camera camera;
	public ColorsMenu colorsMenu;
	public ColorChanger colorChanger;
	public bool isForSmartWatches = false;
	public bool isZoomedIn = true;

	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f; 
	public float maxCameraSize = 50;
	public float minCameraSize = 8;

	public float speed = .500f;

	void Awake(){
		if(instance != null){
			Destroy(gameObject);
			return;
		}
		instance = this;

		if(isForSmartWatches || PlayerPrefs.GetFloat("PlayerLevel") >= 1){ 
			determinePositioningOfCamera();
		}
	}

	void Start () {
		//print("DEVICE TYPE: " + SystemInfo.deviceModel);
		if(SystemInfo.deviceModel.Contains("360")){
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}

		if(isForSmartWatches){
			//Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
			//Screen.sleepTimeout = 15;
		}

		colorChanger.lightUpBG(false);
	}
	
	// Update is called once per frame
	void Update () {
		//print("TOUCH COUNT: " + Input.touchCount);
		//if(!isForSmartWatches){
			if (Input.touchCount == 3){
				colorsMenu.displayColorsMenu(); 
			}
			if(colorsMenu != null && colorsMenu.colorButtons.activeInHierarchy){
				handleGestures(); 
				establishPositionBoundaries();
			}
		//}
	}

	public void determinePositioningOfCamera(){
		if(isForSmartWatches){
			Camera.main.orthographicSize = 4.8f;
			Camera.main.transform.position = new Vector3 (0,0,-10);
			if(PlayerPrefs.GetFloat("PlayerLevel") >= 1){
				Camera.main.transform.Rotate(new Vector3 (0,0,PlayerPrefs.GetFloat("cameraRotation")));
			}
		}else{
			Camera.main.orthographicSize = PlayerPrefs.GetFloat("playerOrthoSize");
			Camera.main.transform.position = new Vector3 (PlayerPrefs.GetFloat("playerXPosition"), PlayerPrefs.GetFloat("playerYPosition"), -10);
		}
	}

	public void toggleZoom(){
		if(!isZoomedIn){
			Camera.main.orthographicSize = 11;
			Camera.main.transform.position = new Vector3 (0,-2.5f,-10);
			isZoomedIn = true;
		}else if(isZoomedIn){
			Camera.main.orthographicSize = 16;
			Camera.main.transform.position = new Vector3 (0,-5.5f,-10);
			isZoomedIn = false;
		}	
	}

	public void zoomIn(){
		Camera.main.orthographicSize = 11;
		Camera.main.transform.position = new Vector3 (0,-2.5f,-10);
		isZoomedIn = true;
	}

	public void zoomOut(){
		Camera.main.orthographicSize = 16;
		Camera.main.transform.position = new Vector3 (0,-5.5f,-10);
		isZoomedIn = false;
	}

	public void establishPositionBoundaries(){
		var pos = transform.position;
		float orthoSize = camera.orthographicSize;
		pos.x = Mathf.Clamp(camera.transform.position.x, -orthoSize + (orthoSize/2.5f) , orthoSize - (orthoSize/2.5f));
		pos.y = Mathf.Clamp(camera.transform.position.y, -orthoSize + (orthoSize/10) , orthoSize - (orthoSize/10));
		pos.z = -10;
		camera.transform.position = pos;
	}

	public void rotateCamera(){
		Vector3 rotation = new Vector3(0,0,90);
		Camera.main.transform.Rotate(rotation);
		PlayerPrefs.SetFloat("cameraRotation",Camera.main.transform.eulerAngles.z);
	}

	void handleGestures(){
		// If there are two touches on the device...


		if (Input.touchCount == 1){// && Input.GetTouch(0).phase == TouchPhase.Moved) {
//			if(TutorialManager.instance != null && TutorialManager.instance.hasSeenPhrase2){
//				TutorialManager.instance.showPhrase(TutorialManager.instance.phrase3);
//			}
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			//camera.transform.Translate(0, -touchDeltaPosition.y/34 * (camera.orthographicSize/50), 0);
			camera.transform.Translate( -touchDeltaPosition.x/34 * (camera.orthographicSize/22),-touchDeltaPosition.y/34 * (camera.orthographicSize/22), 0);
		}else if (Input.touchCount == 2){
//			if(TutorialManager.instance != null && TutorialManager.instance.hasSeenPhrase2){
//				TutorialManager.instance.showPhrase(TutorialManager.instance.phrase3);
//			}

			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			// If the camera is orthographic...
			if (camera.orthographic){
				// ... change the orthographic size based on the change in distance between the touches.
				camera.orthographicSize += deltaMagnitudeDiff/10 * orthoZoomSpeed;

				// Make sure the orthographic size never drops below 8 or above 50.
				camera.orthographicSize = Mathf.Max(camera.orthographicSize, 8f);
				camera.orthographicSize = Mathf.Min(camera.orthographicSize, 50f);

			}else{
				// Otherwise change the field of view based on the change in distance between the touches.
				camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

				// Clamp the field of view to make sure it's between 0 and 180.
				camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
			}
		}else if (Input.touchCount == 5){
			colorChanger.lightUpBG(false);
			PlayerPrefs.SetInt("isBlackForever", 1);
			PlayerPrefs.SetInt("isLitForever", 0);
			PlayerPrefs.SetInt("cantTilt", 1);
		}else if (Input.touchCount == 4){
			colorChanger.lightUpBG(true);
			PlayerPrefs.SetInt("isLitForever", 1);
			PlayerPrefs.SetInt("isBlackForever", 0);
		}

//		else if (Input.touchCount == 3){
//			if(System.DateTime.Now.Hour >= 19 || System.DateTime.Now.Hour < 7){
//				colorChanger.lightUpBG(false);
//			}else{
//				colorChanger.lightUpBG(true);
//			}
//			PlayerPrefs.SetInt("isLitForever", 0);
//			PlayerPrefs.SetInt("isBlackForever", 0);
//		}
//		else if (Input.touchCount == 5){
//			colorChanger.lightUpBG(false);
//		}
	}
}
