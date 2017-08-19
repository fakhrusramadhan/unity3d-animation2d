using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
	
	public Texture2D GambarFadeOut;
	public float fadeSpeed = 1f;
	
	int drawDepth = -1000;
	float alpha = -1.0f;		// alpha 1.0 fade out, -1.0 fade in
	int fadeDir = 1;			//fadeDir fade out (-1) // fade in (1)
	
	void Start () {
		
	}
	
	void OnGUI () {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		
		alpha = Mathf.Clamp01 (alpha);
		
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), GambarFadeOut);
	}
		
}
