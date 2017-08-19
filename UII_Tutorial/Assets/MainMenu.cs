using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GameObject faderKeyIn, faderCuti, faderAktif, alert, tentangKami;
	public AudioClip[] suara;
	public AudioSource mp3;

	// Use this for initialization
	void Start () {

		//Agar Monitor Tidak Sleep
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		mp3.clip = suara [3];
		mp3.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (alert.activeSelf || tentangKami.activeSelf){
				alert.SetActive (false);
				tentangKami.SetActive (false);
			}else {
				alert.SetActive (true);
			}
		}
	}

	//========== KeyIn ============
	public void keyIn () {
		faderKeyIn.SetActive (true);
		mp3.clip = suara [0];
		mp3.Play ();
		StartCoroutine ("menuKeyIn");
	}

	public IEnumerator menuKeyIn () {

		yield return new WaitForSeconds (1.5f);
		Application.LoadLevel ("PK1");
	}

	//========== Cuti ===========
	public void Cuti () {
		faderCuti.SetActive (true);
		mp3.clip = suara [1];
		mp3.Play ();
		StartCoroutine ("menuCuti");
	}
	
	public IEnumerator menuCuti () {
		
		yield return new WaitForSeconds (1.5f);
		Application.LoadLevel ("PK2");
	}

	//========== Aktif ============
	public void Aktif () {
		faderAktif.SetActive (true);
		mp3.clip = suara [2];
		mp3.Play ();
		StartCoroutine ("menuAktif");
	}
	
	public IEnumerator menuAktif () {
		
		yield return new WaitForSeconds (1.5f);
		Application.LoadLevel ("PK3");
	}

	public void tentang(){
		tentangKami.SetActive (true);
	}

	public void batalKeluar(){
		alert.SetActive (false);
	}

	public void Quit () {
		Application.Quit ();
	}
}
