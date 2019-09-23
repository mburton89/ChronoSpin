using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {
//
	public bool isGreen;
	public bool isCyan;
	public bool isMediumBlue;
	public bool isBlue;
	public bool isMagenta;
	public bool isPurple;
	public bool isRed;
	public bool isOrangeRed;
	public bool isOrange;
	public bool isOrangeYellow;
	public bool isYellow;
	public bool isYellowGreen;
	public bool isWhite;

	public GameObject background;
	public GameObject circleOverLayer;
	public GameObject squareOverLayer;
	public bool bgIsLit;

	public Camera camera;
	public CameraManager cameraManager;
	public ColorsMenu colorsMenu;

	void Awake () {
		determineColor();
	}
		
//	void Start () {
//		//isGreen = true;
//		//PlayerPrefs.SetString("Color","d");
//		determineColor();
//	}
	
	// Update is called once per frame

	#if UNITY_EDITOR
	void Update () {
		if(Input.GetKeyDown(KeyCode.C)){
			chooseNextColor();
		}else if(Input.GetKeyDown(KeyCode.I)){
			invertColors();
		}else if(Input.GetKeyDown(KeyCode.B)){
			toggleBackground();
		}else if(Input.GetKeyDown(KeyCode.Z)){
			cameraManager.toggleZoom();
		}
	}
	#endif

	public void invertColors () {
		SpriteRenderer[] nonBlackRenderers;
		SpriteRenderer[] blackRenderers;

		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				//nonBlackRenderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
				render.color = Color.cyan;
			}else{
				render.color = Color.blue;
			}
		}

//		foreach (SpriteRenderer nonBlackRender in renderers) {
//			nonBlackRender.color = Color.black;
//		}
//		foreach (SpriteRenderer blackRender in renderers) {
//			blackRender.color = Color.green;
//		} 

		isGreen = true;
		isWhite = false;
		PlayerPrefs.SetString("Color","Green");
	}

	public void turnGreen () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.green;
			}
		}
		resetColorBools();
		isGreen = true;
		isWhite = false;
		PlayerPrefs.SetString("Color","Green");
	}

	public void turnCyan () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.cyan;
			}
		}
		resetColorBools();
		isCyan = true;
		isGreen = false;
		PlayerPrefs.SetString("Color","Cyan");
	}


	public void turnMediumBlue(){
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = new Color(0, .53f, 1, 1f); //MEDIUM BLUE
			}
		}
		resetColorBools();
		isMediumBlue = true;
		PlayerPrefs.SetString("Color","MediumBlue");
	}

	public void turnBlue(){
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.blue;
			}
		}
		resetColorBools();
		isBlue = true;
		isCyan = false;
		PlayerPrefs.SetString("Color","Blue");
	}

	public void turnMagenta () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.magenta;
			}
		}
		resetColorBools();
		isMagenta = true;
		isBlue = false;
		PlayerPrefs.SetString("Color","Magenta");
	}

	public void turnPurple () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = new Color(.7f, .1f, .85f, 1f);
			}
		}
		resetColorBools();
		isPurple = true;
		isMagenta = false;
		PlayerPrefs.SetString("Color","Purple");
	}

	public void turnRed () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.red;
			}
		}
		resetColorBools();
		isRed = true;
		isPurple = false;
		PlayerPrefs.SetString("Color","Red");
	}
		
	public void turnOrangeRed () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = new Color(1, .3f, 0.0f, 1f); //RED/ORANGE
			}
		}
		resetColorBools();
		isOrangeRed = true;
		PlayerPrefs.SetString("Color","OrangeRed");
	}

	public void turnOrange () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = new Color(1, .55f, 0.0f, 1f);
			}
		}
		resetColorBools();
		isOrange = true;
		isRed = false;
		PlayerPrefs.SetString("Color","Orange");
	}

	public void turnOrangeYellow () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = new Color(1, .77f, 0.0f, 1f); //ORANGE/YELLOW
			}
		}
		resetColorBools();
		isOrangeYellow = true;
		PlayerPrefs.SetString("Color","OrangeYellow");
	}

	public void turnYellow () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.yellow;
			}
		}
		resetColorBools();
		isYellow = true;
		isOrange = false;
		PlayerPrefs.SetString("Color","Amber");
	}

	public void turnYellowGreen () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = new Color(.71f, 1, 0, 1f); //YELLOW/GREEN
			}
		}
		resetColorBools();
		isYellowGreen = true;
		PlayerPrefs.SetString("Color","YellowGreen");
	}

	public void turnWhite () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.white;
			}
		}
		resetColorBools();
		isWhite = true;
		isYellow = false;
		PlayerPrefs.SetString("Color","White");
	}

	public void chooseNextColor () {
		//print("chooseNextColor");
		if(isGreen){
			turnCyan();
			return;
		}
		else if(isCyan){
			turnBlue();
			return;
		}
		else if(isBlue){
			turnMagenta();
			return;
		}
		else if(isMagenta){
			turnPurple();
			return;
		}
		else if(isPurple){
			turnRed();
			return;
		}
		else if(isRed){
			turnOrange();
			return;
		}
		else if(isOrange){
			turnYellow();
			return;
		}
		else if(isYellow){
			turnWhite();
			return;
		}
		else if(isWhite){
			turnGreen();
			return;
		}
		else{
			turnCyan();
			return;
		}
	}

	public void choosePreviousColor () {
		//print("choosePreviousColor");
		if(isGreen){
			turnWhite();
			return;
		}
		else if(isCyan){
			turnGreen();
			return;
		}
		else if(isBlue){
			turnCyan();
			return;
		}
		else if(isMagenta){
			turnBlue();
			return;
		}
		else if(isPurple){
			turnMagenta();
			return;
		}
		else if(isRed){
			turnPurple();
			return;
		}
		else if(isOrange){
			turnRed();
			return;
		}
		else if(isYellow){
			turnOrange();
			return;
		}
		else if(isWhite){
			turnYellow();
			return;
		}
		else{
			turnGreen();
			return;
		}
	}


//	public void turnColor () {
//		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
//		foreach (SpriteRenderer render in renderers) {
//			if (render.color != Color.black) {
//				render.color = Color.green;
//
//			}	
//		}
//	}

	public void resetColorBools(){
		isGreen = false;
		isCyan = false;
		isMediumBlue = false;
		isBlue = false;
		isMagenta = false;
		isPurple = false;
		isRed = false;
		isOrangeRed = false;
		isOrange = false;
		isOrangeYellow = false;
		isYellow = false;
		isYellowGreen = false;
		isWhite = false;
		if(colorsMenu != null){
			colorsMenu.hideColorsMenu();
		}

		if(TutorialManager.instance != null && !isWhite){
			
			//TutorialManager.instance.showPhrase(TutorialManager.instance.phrase4);
		}

		if(NumberShower.instance != null){
			NumberShower.instance.determineDate();
		}
	}

	public void determineColor(){
		if(!CameraManager.instance.isForSmartWatches){
			if(PlayerPrefs.GetString("Background") == "isLit"){
				background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitBG", typeof(Sprite)) as Sprite;
				if(circleOverLayer != null){
					circleOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitCircleOverLayer", typeof(Sprite)) as Sprite;
				}
				if(squareOverLayer != null){
					squareOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitSquareOverLayer", typeof(Sprite)) as Sprite;
				}
			}else{
				background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitBG", typeof(Sprite)) as Sprite;
				if(circleOverLayer != null){
					circleOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircleOverLayer", typeof(Sprite)) as Sprite;
				}
				if(squareOverLayer != null){
					squareOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitSquareOverLayer", typeof(Sprite)) as Sprite;
				}
			}
		}else{
			print("GORRRGGG");
			background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitBG", typeof(Sprite)) as Sprite;
			if(circleOverLayer != null){
				circleOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitCircleOverLayer", typeof(Sprite)) as Sprite;
			}
			if(squareOverLayer != null){
				squareOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitSquareOverLayer", typeof(Sprite)) as Sprite;
			}
		}
		if(PlayerPrefs.GetString("Color") == "Green"){
			turnGreen();
		}else if(PlayerPrefs.GetString("Color") == "Cyan"){
			turnCyan();
		}else if(PlayerPrefs.GetString("Color") == "MediumBlue"){
			turnMediumBlue();
		}else if(PlayerPrefs.GetString("Color") == "Blue"){
			turnBlue();
		}else if(PlayerPrefs.GetString("Color") == "Magenta"){
			turnMagenta();
		}else if(PlayerPrefs.GetString("Color") == "Purple"){
			turnPurple();
		}else if(PlayerPrefs.GetString("Color") == "Red"){
			turnRed();
		}else if(PlayerPrefs.GetString("Color") == "OrangeRed"){
			turnOrangeRed();
		}else if(PlayerPrefs.GetString("Color") == "Orange"){
			turnOrange();
		}else if(PlayerPrefs.GetString("Color") == "OrangeYellow"){
			turnOrangeYellow();
		}else if(PlayerPrefs.GetString("Color") == "Amber"){
			turnYellow();
		}else if(PlayerPrefs.GetString("Color") == "YellowGreen"){
			turnYellowGreen();
		}else if(PlayerPrefs.GetString("Color") == "White"){
			turnWhite();
		}
	}

	public void toggleBackground(){
		//Color currentBackgroundColor = background.GetComponent<SpriteRenderer>().color;
		//print("HEY");
		if(cameraManager.isForSmartWatches){
			cameraManager.rotateCamera();
		}else{
			if(bgIsLit){
				background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitBG", typeof(Sprite)) as Sprite;
				if(circleOverLayer != null){
					circleOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircleOverLayer", typeof(Sprite)) as Sprite;
				}
				if(squareOverLayer != null){
					squareOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitSquareOverLayer", typeof(Sprite)) as Sprite;
				}
				bgIsLit = false;
				PlayerPrefs.SetString("Background","isNotLit");
			}else{
				background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitBG", typeof(Sprite)) as Sprite;
				if(circleOverLayer != null){
					circleOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitCircleOverLayer", typeof(Sprite)) as Sprite;
				}
				if(squareOverLayer != null){
					squareOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitSquareOverLayer", typeof(Sprite)) as Sprite;
				}
				bgIsLit = true;
				PlayerPrefs.SetString("Background","isLit");
			}
		}
	}
	 
	public void lightUpBG(bool isLit){
		if(isLit){
			background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitBG", typeof(Sprite)) as Sprite;
			if(circleOverLayer != null){
				circleOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitCircleOverLayer", typeof(Sprite)) as Sprite;
			}
			if(squareOverLayer != null){
				squareOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LitSquareOverLayer", typeof(Sprite)) as Sprite;
			}
			bgIsLit = false;
			PlayerPrefs.SetString("Background","isNotLit");
		}else{
			background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitBG", typeof(Sprite)) as Sprite;
			if(circleOverLayer != null){
				circleOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitCircleOverLayer", typeof(Sprite)) as Sprite;
			}
			if(squareOverLayer != null){
				squareOverLayer.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UnlitSquareOverLayer", typeof(Sprite)) as Sprite;
			}
			bgIsLit = true;
			PlayerPrefs.SetString("Background","isLit");
		}
	}
}
