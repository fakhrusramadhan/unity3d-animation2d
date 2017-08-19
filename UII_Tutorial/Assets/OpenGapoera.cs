using UnityEngine;
using System.Collections;

public class OpenGapoera : MonoBehaviour {

	public GameObject fadeOut;
	// Use this for initialization
	void Start () {
		
		StartCoroutine ("tungguSplash");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator tungguSplash(){
		yield return new WaitForSeconds (1f);
		fadeOut.SetActive (true);
		yield return new WaitForSeconds (1f);
		Application.LoadLevel ("MainMenu");
	}

}
