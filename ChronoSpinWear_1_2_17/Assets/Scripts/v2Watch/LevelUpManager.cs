using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelUpManager : MonoBehaviour {

	private bool watchHandsAreMovingToFormStickFigure;
	private bool stickFigureIsCheering;
	private bool watchHandsAreMovingBackToGameMode;

	public GameObject LevelText;

	void Start () {
		PlayerPrefs.SetFloat("PlayerLevel", PlayerPrefs.GetFloat("PlayerLevel") + 1);
		Time.timeScale = 1;
		levelUp();
	}

	void Update () {

	}

	public void levelUp(){
		StartCoroutine(levelUpCo()); 
	}

	private IEnumerator levelUpCo(){ 
		LevelText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LevelUpText", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.4f);
		LevelText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.2f);
		LevelText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LevelUpText", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.4f);
		LevelText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.2f);
		LevelText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LevelUpText", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.8f);
		SceneManager.LoadScene(1);
	}
}
