using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public Texture2D textureToDisplay;
	public GameObject whateverTheFuckIWant;
	void OnGUI(){
		GUI.Label(new Rect(0,0, textureToDisplay.width, textureToDisplay.height),textureToDisplay);
	}
}
