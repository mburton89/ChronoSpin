using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {

	public static TutorialManager instance;

	public GameObject transparentCircle;
	public GameObject phrase1;
	public GameObject phrase2;
	public GameObject phrase3;
	public GameObject phrase4;
	public GameObject phrase5;
	public GameObject phrase6;

	public bool hasSeenPhrase2;
	public bool hasSeenPhrase4;

	void Awake(){
		if(instance != null){
			Destroy(gameObject);
			return;
		}
		instance = this;
	}

	public void startTutorial(){
		showPhrase(phrase1);
	}

	public void showPhrase(GameObject phrase){
		hidePhrases();
		transparentCircle.transform.localScale = Vector3.one;
		phrase.transform.localScale = Vector3.one;
	}

	public void hidePhrases(){
		phrase1.transform.localScale = Vector3.zero;
		phrase2.transform.localScale = Vector3.zero;
		phrase3.transform.localScale = Vector3.zero;
		phrase4.transform.localScale = Vector3.zero;
		phrase5.transform.localScale = Vector3.zero;
		phrase6.transform.localScale = Vector3.zero;
	}

	public void startPhrase3(){
		StartCoroutine(startPhrase3Co());
	}

	private IEnumerator startPhrase3Co(){
		phrase3.transform.localScale = Vector3.one;
		yield return new WaitForSeconds(.4f);
		phrase3.transform.localScale = Vector3.zero;
		phrase4.transform.localScale = Vector3.one;
		yield return new WaitForSeconds(.7f);
		transparentCircle.transform.localScale = Vector3.zero;
		phrase4.transform.localScale = Vector3.zero;
	}

	public void startPhrase1(){
		StartCoroutine(startPhrase1Co());
	}

	private IEnumerator startPhrase1Co(){
		phrase1.transform.localScale = Vector3.one;
		yield return new WaitForSeconds(4);
		phrase1.transform.localScale = Vector3.zero;
		phrase2.transform.localScale = Vector3.one;
	}
}
