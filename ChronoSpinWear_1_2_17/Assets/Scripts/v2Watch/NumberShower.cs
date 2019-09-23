using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NumberShower : MonoBehaviour {

	public static NumberShower instance;

	public GameObject numberSlot;
	public GameObject textLabel;

	public GameObject centralPivot;
	public GameObject labelPivot;

	public ColorChanger colorChanger;

	private float spinSpeed = 10;

	private float dayOfMonth;
	private string dayOfMonthString;
	private string dayOfWeek;
	private string dayOfWeekString;
	private string playerLevel;

	void Awake(){
		if(instance != null){
			Destroy(gameObject);
			return;
		}
		instance = this;
	}

	void Start () {
		determineBackground();
		if(SceneManager.GetActiveScene().buildIndex == 0){
			determineDate();
		}else{
			determinePlayerLevel();
		}
	}

	void Update () {
		textLabel.transform.rotation = Quaternion.Euler(0,0,0);
		numberSlot.transform.rotation = Quaternion.Euler(0,0,0);
	}

	public void spinIntoGamePosition(){
		centralPivot.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0,0,0), spinSpeed * Time.deltaTime);
	}

	public void spinIntoWatchPosition(){
		centralPivot.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0,0,270), spinSpeed * Time.deltaTime);
	}

	public void determineDate(){
		//DAY OF WEEK

		dayOfWeek = System.DateTime.Now.DayOfWeek.ToString();
		if(dayOfWeek == "Monday"){
			textLabel.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MON", typeof(Sprite)) as Sprite;
		}else if(dayOfWeek == "Tuesday"){
			textLabel.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("TUE", typeof(Sprite)) as Sprite;
		}else if(dayOfWeek == "Wednesday"){
			textLabel.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("WED", typeof(Sprite)) as Sprite;
		}else if(dayOfWeek == "Thursday"){
			textLabel.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("THU", typeof(Sprite)) as Sprite;
		}else if(dayOfWeek == "Friday"){
			textLabel.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("FRI", typeof(Sprite)) as Sprite;
		}else if(dayOfWeek == "Saturday"){
			textLabel.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SAT", typeof(Sprite)) as Sprite;
		}else if(dayOfWeek == "Sunday"){
			textLabel.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SUN", typeof(Sprite)) as Sprite;
		}
		//Debug.Log("DAY OF WEEK: " + dayOfWeek);

		//DAY OF MONTH
		dayOfMonth = System.DateTime.Now.Day;
		dayOfMonthString = dayOfMonth.ToString();
		numberSlot.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load (dayOfMonthString, typeof(Sprite)) as Sprite;
		//Debug.Log("DAY OF MONTH: " + dayOfMonth);


	}

	public void showConfigText(){
		textLabel.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Config", typeof(Sprite)) as Sprite;
		numberSlot.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
	}

	public void determinePlayerLevel(){
		float playerLevelFloat = PlayerPrefs.GetFloat("PlayerLevel");
		if(playerLevelFloat < 33){
			playerLevel = playerLevelFloat.ToString();
			numberSlot.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load (playerLevel, typeof(Sprite)) as Sprite;
			textLabel.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LVL", typeof(Sprite)) as Sprite;
		}else{
			playerLevelFloat = playerLevelFloat - 32;
			playerLevel = playerLevelFloat.ToString();
			numberSlot.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load (playerLevel, typeof(Sprite)) as Sprite;
			textLabel.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("WTF", typeof(Sprite)) as Sprite;
		}
	}

	public void levelUp(){
		textLabel.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LevelUpText", typeof(Sprite)) as Sprite;
		PlayerPrefs.SetFloat("PlayerLevel", PlayerPrefs.GetFloat("PlayerLevel") + 1);
		StartCoroutine(levelUpCo()); 
	}

	private IEnumerator levelUpCo(){
		yield return new WaitForSeconds (Time.timeScale * 3);
		SceneManager.LoadScene(1);
	}

	public void determineBackground(){
		PlayerPrefs.SetInt("isBlackForever",1);
		if(PlayerPrefs.GetInt("isBlackForever") == 1){
			colorChanger.lightUpBG(false);
		}else if(PlayerPrefs.GetInt("isLitForever") == 1){
			colorChanger.lightUpBG(true);
		}else{
			if(System.DateTime.Now.Hour >= 19 || System.DateTime.Now.Hour < 7){
				colorChanger.lightUpBG(false);
			}else{
				colorChanger.lightUpBG(true);
			}
		}
	}
}
