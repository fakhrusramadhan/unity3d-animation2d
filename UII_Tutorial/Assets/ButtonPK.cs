using UnityEngine;
using System.Collections;

public class ButtonPK : MonoBehaviour {

	public GameObject informasi, pauseMenu, alert, nextFX, backFX, replay;
	public GameObject[] Scene;
	public AudioClip[] Suara;
	public AudioSource mp3;
	public GameObject notifPause, tblMenu, tblInfo, tungguProses, keMenuUtama;
	//public Animator anim;

	int JmlScene, angka;

	// Use this for initialization
	void Start () {
		JmlScene = Scene.Length - 1;
		Play ();
		StartCoroutine ("prosesLoading");
	}
	
	// Update is called once per frame
	void Update () {

		if ((informasi.activeSelf || pauseMenu.activeSelf || alert.activeSelf ) && Input.GetKeyDown (KeyCode.Escape)) {
			if (alert.activeSelf){
				alert.SetActive (false);

			}else {
				informasi.SetActive (false);
				pauseMenu.SetActive (false);
			}
		} else if (pauseMenu.activeSelf == false && Input.GetKeyDown (KeyCode.Escape)) {

			if(mp3.time == 0 || mp3.isPlaying){
				Time.timeScale = 1;
				pauseMenu.SetActive (true);
			}else {
				Pause();
			}

		}

		TombolEffect ();

	}

	IEnumerator prosesLoading () {
		yield return new WaitForSeconds (1f);
		tungguProses.SetActive (false);
	}

	IEnumerator prosesKeMenu () {
		keMenuUtama.SetActive (true);
		yield return new WaitForSeconds (1f);
		Application.LoadLevel ("MainMenu");
	}

	public void information () {
		/*if (mp3.time == 0) {
			Time.timeScale = 1;
		} else {
			aksiPlay ();
		}*/
		informasi.SetActive (true);
	}

	public void menu () {
		if(mp3.time == 0){
			Time.timeScale = 1;
		}else {
			aksiPlay();
		}
		pauseMenu.SetActive (true);
	}
	
	public void Next() {
		bool ubah = true; // ketika onclick maka dari false (setelah loop) jadi true
		Stop ();

		for (int i = 0; i < Scene.Length; i++) {
				if (Scene[i].activeSelf && ubah == true) {
					Scene[i].SetActive(false);
					Scene[i+1].SetActive(true);
					
					aksiPlay();
					ubah = false; // menghentikan loopping, akan jadi true ketika di onclick
					Debug.Log ("Scene ke : " + i);
					Debug.Log ("Ubah ke : " + ubah);
				}
		}
		
	}
	
	public void Prev () {
		bool ubah = false;
		Stop ();
		for (int i = 0; i < Scene.Length; i++) {

				if (Scene[i].activeSelf && ubah == false) {
					Scene[i].SetActive(false);
					Scene[i-1].SetActive(true);
					//Play ();
					aksiPlay();
					ubah = true;		
				}
			
		}
	}

	public void Play () {
		bool ubah = true;
		for (int i = 0; i < Scene.Length; i++) {
			if (Scene[i].activeSelf && ubah) {
				if (!mp3.isPlaying){
					mp3.clip = Suara[i];
					mp3.Play();
				}
				ubah = false;
			}
		}
	}


	public void Stop () {
		mp3.Stop ();
	}


	public void Pause () {

		for (int i = 0; i < Scene.Length; i++) {
			if (Scene[i].activeSelf) {

				if (mp3.isPlaying) {
					mp3.Pause();
					aksiPause();

				} else if (!mp3.isPlaying && mp3.time != 0){
					aksiPlay();

				}else if (!mp3.isPlaying && mp3.time == 0) {
					Scene[i].SetActive(false);
					Scene[i].SetActive(true);
					mp3.Play ();
				}

			}
			
		}

	}
	

	void aksiPause () {
		notifPause.SetActive(true);
		tblMenu.SetActive (false);
		tblInfo.SetActive (false);
		Time.timeScale = 0; // Menghentikan Animasi
	}

	void aksiPlay () {
		Time.timeScale = 1;
		tblMenu.SetActive (true);
		tblInfo.SetActive (true);
		notifPause.SetActive(false);
		Play();
	}


	void TombolEffect () {
		if (mp3.time == 0) {
			nextFX.SetActive (true);
			backFX.SetActive (true);
			replay.SetActive (true);
		} else {
			nextFX.SetActive (false);
			backFX.SetActive (false);
			replay.SetActive (false);
		}
	}


	// STEP Scene
	public void PilihStep1 (){
		angka = 0;
		Jumpto ();
		Stop ();
		Play ();
	}

	public void PilihStep2 (){
		angka = 1;
		Jumpto ();
		Stop ();
		Play ();
	}

	public void PilihStep3 () {
		angka = 2;
		Jumpto ();
		Stop ();
		Play ();
	}
	
	public void PilihStep4 () {
		angka = 3;
		Jumpto ();
		Stop ();
		Play ();
	}
	
	public void PilihStep5 () {
		angka = 4;
		Jumpto ();
		Stop ();
		Play ();
	}
	
	public void PilihStep6 () {
		angka = 5;
		Jumpto ();
		Stop ();
		Play ();
	}

	public void PilihStep7 (){
		angka = 6;
		Jumpto ();
		Stop ();
		Play ();
	}

	public void PilihStep8 (){
		angka = 7;
		Jumpto ();
		Stop ();
		Play ();
	}

	public void PilihStep9 (){
		angka = 8;
		Jumpto ();
		Stop ();
		Play ();
	}

	public void PilihStep10 (){
		angka = 9;
		Jumpto ();
		Stop ();
		Play ();
	}

	public void PilihStep11 (){
		angka = 10;
		Jumpto ();
		Stop ();
		Play ();
	}


	public void Jumpto () {

		Debug.Log ("angka " + angka+" panjang "+JmlScene);

			//tampilkan scene sesuai angka (nomor urut scene)
			Scene[angka].SetActive(false);
			Scene[angka].SetActive(true);

		//untuk semua scene yg tidak sesuai dengan angka scene, maka disable
		for (int i = 0; i <= JmlScene; i++) {
			if (angka!=i) {
				Scene[i].SetActive(false);
				Debug.Log ("yang dimatikan scene " + Scene[i]);
			}
		}
		informasi.SetActive (false);
	}

	public void Home () {
		StartCoroutine ("prosesKeMenu");
	}

	public void Resume () {
		pauseMenu.SetActive (false);
		informasi.SetActive (false);
	}
	
	public void Restart () {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void ExitAlert () {
		alert.SetActive (true);
	}

	public void batalKeluar(){
		alert.SetActive (false);
	}

	public void Quit () {
		Application.Quit ();
	}

}
