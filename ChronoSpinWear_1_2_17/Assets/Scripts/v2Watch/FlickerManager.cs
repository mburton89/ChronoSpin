using UnityEngine;
using System.Collections;

public class FlickerManager : MonoBehaviour {
	
	public GameObject lineSprite1;
	public GameObject lineSprite2;
	public GameObject upperSecondHand;
	public GameObject upperMinuteHand;
	public GameObject lowerMinuteHand;
	public GameObject lowerHourHand;
	public GameObject lvlText;
	public string lvlTextString;

	public bool isStartingGameMode;

	void Start () {
		if(PlayerPrefs.GetFloat("PlayerLevel") < 33){
			lvlTextString = "LVL";
		}else{
			lvlTextString = "WTF";
		}
		isStartingGameMode = true;
		StartCoroutine(initiateFlickerCo(false));
	}

	void Update () {
		if(isStartingGameMode){
			putLowerHandsInGamePosition();
		}else{
			putLowerHandsInWatchPosition();
		}
	}

	public void flicker(bool isGameOver){
		StartCoroutine(initiateFlickerCo(isGameOver));
	}

	private IEnumerator initiateFlickerCo(bool isGameOver){
		float waitTime = .03f * (Time.timeScale/1);
		if(!isGameOver){
			yield return new WaitForSeconds (waitTime);
			lineSprite1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
			lineSprite2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
			upperSecondHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
			upperMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
			lowerMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
			lowerHourHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
			lvlText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		}
		yield return new WaitForSeconds (waitTime);
		lineSprite1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lineSprite2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		upperSecondHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		upperMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lowerMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lowerHourHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lvlText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load (lvlTextString, typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		lineSprite1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lineSprite2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		upperSecondHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		upperMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lowerMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lowerHourHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lvlText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		lineSprite1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lineSprite2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		upperSecondHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		upperMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lowerMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lowerHourHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lvlText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load (lvlTextString, typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		lineSprite1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lineSprite2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		upperSecondHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		upperMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lowerMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lowerHourHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lvlText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		lineSprite1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lineSprite2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		upperSecondHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		upperMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lowerMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lowerHourHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lvlText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load (lvlTextString, typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		lineSprite1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lineSprite2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		upperSecondHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		upperMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lowerMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lowerHourHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lvlText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		lineSprite1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lineSprite2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		upperSecondHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		upperMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lowerMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lowerHourHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lvlText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load (lvlTextString, typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (waitTime);
		lineSprite1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		lineSprite2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
		upperSecondHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		upperMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lowerMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lowerHourHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
		lvlText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		if(isGameOver){
			yield return new WaitForSeconds (waitTime);
			//lineSprite1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
			//lineSprite2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3DARK", typeof(Sprite)) as Sprite;
			upperSecondHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
			upperMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
			lowerMinuteHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
			lowerHourHand.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ILogo3", typeof(Sprite)) as Sprite;
			lvlText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load (lvlTextString, typeof(Sprite)) as Sprite;
		}
	}

	private IEnumerator initiatePostGameFlickerCo(){
		float waitTime = .1f;
		yield return new WaitForSeconds (waitTime);
	}

	public void putLowerHandsInGamePosition(){
		
	}

	public void putLowerHandsInWatchPosition(){

	}
}
