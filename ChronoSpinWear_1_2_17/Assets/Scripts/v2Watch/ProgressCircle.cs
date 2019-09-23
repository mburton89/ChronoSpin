using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ProgressCircle : MonoBehaviour {
	
	public NumberShower numberShower;
	public v3PairsDispenser projectileDispenser;
	public SpinningLine line;

	public GameObject slot1_1;
	public GameObject slot1_2;
	public GameObject slot1_3;
	public GameObject slot1_4;
	public GameObject slot1_5;

	public GameObject slot2_1;
	public GameObject slot2_2;
	public GameObject slot2_3;
	public GameObject slot2_4;
	public GameObject slot2_5;

	public GameObject slot3_1;
	public GameObject slot3_2;
	public GameObject slot3_3;
	public GameObject slot3_4;
	public GameObject slot3_5;

	public GameObject slot4_1;
	public GameObject slot4_2;
	public GameObject slot4_3;
	public GameObject slot4_4;
	public GameObject slot4_5;

	public GameObject slot5_1;
	public GameObject slot5_2;
	public GameObject slot5_3;
	public GameObject slot5_4;
	public GameObject slot5_5;

	public GameObject slot6_1;
	public GameObject slot6_2;
	public GameObject slot6_3;
	public GameObject slot6_4;
	public GameObject slot6_5;

	public GameObject slot7_1;
	public GameObject slot7_2;
	public GameObject slot7_3;
	public GameObject slot7_4;
	public GameObject slot7_5;

	public GameObject slot8_1;
	public GameObject slot8_2;
	public GameObject slot8_3;
	public GameObject slot8_4;
	public GameObject slot8_5;

	public GameObject slot9_1;
	public GameObject slot9_2;
	public GameObject slot9_3;
	public GameObject slot9_4;
	public GameObject slot9_5;

	public GameObject slot10_1;
	public GameObject slot10_2;
	public GameObject slot10_3;
	public GameObject slot10_4;
	public GameObject slot10_5;

	public GameObject slot11_1;
	public GameObject slot11_2;
	public GameObject slot11_3;
	public GameObject slot11_4;
	public GameObject slot11_5;

	public GameObject slot12_1;
	public GameObject slot12_2;
	public GameObject slot12_3;
	public GameObject slot12_4;
	public GameObject slot12_5;

	private float timeBetweenIncrements;
	public string layerName = "Default";
	public bool hasLeveledUpThisSession;

	void Start () {
		timeBetweenIncrements = Time.timeScale/5; 
		//Debug.Log("TIME " + Time.timeScale);
		startProgressCircle();

		if(SceneManager.GetActiveScene().buildIndex == 2){
			layerName = "Hidden";
			timeBetweenIncrements = timeBetweenIncrements/18;
		}
	}

//	void Update () {
//		determineLevelUpages();
//	}
		
	public void startProgressCircle(){
		StartCoroutine(startProgressCircleCo()); 
	}

	private IEnumerator startProgressCircleCo(){
		//12s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot12_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot12_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot12_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot12_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		//1s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot1_1.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot1_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot1_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot1_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot1_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		//2s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot2_1.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot2_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot2_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot2_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot2_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		//3s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot3_1.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot3_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot3_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot3_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot3_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		//4s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot4_1.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot4_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot4_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot4_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot4_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		//5s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot5_1.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot5_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot5_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot5_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot5_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		//6s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot6_1.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot6_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot6_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot6_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot6_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		//7s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot7_1.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot7_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot7_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot7_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot7_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		//8s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot8_1.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot8_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot8_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot8_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot8_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		//9s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot9_1.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot9_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot9_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot9_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot9_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		//10s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot10_1.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot10_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot10_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot10_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot10_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		projectileDispenser.canFire = false;

		//11s
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot11_1.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot11_2.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot11_3.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot11_4.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
		yield return new WaitForSeconds (timeBetweenIncrements);
		slot11_5.GetComponent<SpriteRenderer>().sortingLayerName = layerName;

		//isLevelingUp = true;
		if(SceneManager.GetActiveScene().buildIndex == 1){
			//If last projectile is lower than -3y
			yield return new WaitForSeconds (Time.timeScale);
			//yield return new WaitForSeconds (2);
			Time.timeScale = 1;
			line.canSpin = false;
			line.GetComponent<BoxCollider2D>().enabled = false;
//			yield return new WaitForSeconds (timeBetweenIncrements * 10);
			yield return new WaitForSeconds (.8f);
			determineLevelUpages();
		}

	}

	public void recoilProgressCircle(){
		//determineLastSlotThatWasLit ...Was it in the 11s 12s 5s 1s....dont be exact just find which section out of the twelve
		//determineSpeedToRecoild ...The farther along the progress circle was the greater the speed to recoil
		StartCoroutine(recoilProgressCircleCo()); 
	}

	private IEnumerator recoilProgressCircleCo(){
		//Code for all slots but use an int to determine where to start the reooil
		//timeBetweenIncrements = timeBetweenIncrements/160; //WAS .005f
		timeBetweenIncrements = .02f; //WAS .005f

		//11s
		slot11_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot11_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot11_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot11_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot11_1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (timeBetweenIncrements);

		//10s
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot10_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot10_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot10_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot10_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot10_1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (timeBetweenIncrements);

		//9s
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot9_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot9_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot9_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot9_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot9_1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (timeBetweenIncrements);

		//8s
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot8_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot8_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot8_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot8_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot8_1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (timeBetweenIncrements);

		//7s
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot7_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot7_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot7_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot7_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot7_1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (timeBetweenIncrements);

		//6s
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot6_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot6_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot6_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot6_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot6_1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (timeBetweenIncrements);

		//5s
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot5_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot5_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot5_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot5_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot5_1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (timeBetweenIncrements);

		//4s
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot4_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot4_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot4_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot4_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot4_1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (timeBetweenIncrements);

		//3s
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot3_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot3_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot3_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot3_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot3_1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (timeBetweenIncrements);

		//2s
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot2_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot2_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot2_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot2_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot2_1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (timeBetweenIncrements);

		//1s
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot1_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot1_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot1_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot1_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot1_1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (timeBetweenIncrements);

		//12s
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot12_5.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot12_4.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot12_3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
//		yield return new WaitForSeconds (timeBetweenIncrements);
		slot12_2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
	}

	public void determineLevelUpages(){
		if(slot11_5.GetComponent<SpriteRenderer>().sortingLayerName == "Default"){
			if(!hasLeveledUpThisSession){
				//Debug.Log("LAYER NAME: " + slot11_5.GetComponent<SpriteRenderer>().sortingLayerName);
//				line.canSpin = false;
				hasLeveledUpThisSession = true;
				//numberShower.levelUp();
				SceneManager.LoadScene(2);
			}
		}	
	}
}
