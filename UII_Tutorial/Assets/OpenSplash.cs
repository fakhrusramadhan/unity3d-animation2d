using UnityEngine;
using System.Collections;

public class OpenSplash : MonoBehaviour {
	public GameObject fadeOut;
	// Use this for initialization
	void Start () {
	
		StartCoroutine ("tungguSplash");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator tungguSplash(){
		yield return new WaitForSeconds (2f);
		fadeOut.SetActive (true);
		yield return new WaitForSeconds (0.8f);
		Application.LoadLevel ("MainMenu");
	}
}
