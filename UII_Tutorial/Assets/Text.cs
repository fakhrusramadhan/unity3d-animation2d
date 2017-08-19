using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {
	public GameObject[] textNarasi;
	

	// On Enable Berfungsi Mengaktifkan Script Saat GameObject setActive(true);
	void OnEnable () {
		narasi ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	}

	public void narasi () {

		for (int i = 0; i < textNarasi.Length; i++) {
			textNarasi [i].SetActive (false);
		}

		StartCoroutine ("tunggu");
	}

	public IEnumerator tunggu () {
		textNarasi [0].SetActive (true);
		for (int i = 0; i < textNarasi.Length-1; i++) {
			yield return new WaitForSeconds (6f);

				textNarasi [i].SetActive (false);
				textNarasi [i+1].SetActive (true);
				
		}
		//yield return new WaitForSeconds (5f);
		//textNarasi [textNarasi.Length - 1].SetActive (false);

		// lenght dihitung dari yang diinputkan pada scene
		// sedangkan jumlah indeks adalah length - 1
	}
	
}
