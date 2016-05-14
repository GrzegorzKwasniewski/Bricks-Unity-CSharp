 using UnityEngine;
using System.Collections;

public class Music_Player : MonoBehaviour {

	static Music_Player instance = null;

	private AudioSource levelMusic;
	
	void Awake (){
		if (instance != null){
			GameObject.Destroy(gameObject);
			
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		
		levelMusic = GetComponent<AudioSource>();
		levelMusic.volume = 0f;
		
	}
	
	// Use this for initialization
	void Start () {
		//levelMusic = GetComponent<AudioSource>();
		levelMusic.volume = PlayerPrefsManager.GetMasterVolume ();

	}

	public void ChangeVolume(float volume){
		levelMusic.volume = volume;
	}
}
