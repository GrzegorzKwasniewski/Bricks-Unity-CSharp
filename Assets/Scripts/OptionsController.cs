using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSilder;
	public Slider ballSpeedSlider;
	public Slider soundEffects;
	public LevelMeneger levelMeneger;
	
	private Music_Player musicManager;
	
	void Start () {
		musicManager = GameObject.FindObjectOfType<Music_Player>();
		
		if (Application.loadedLevelName == "Options_Sound") {
			volumeSilder.value = PlayerPrefsManager.GetMasterVolume ();
			soundEffects.value = PlayerPrefsManager.GetSoundEffects ();
		} else if (Application.loadedLevelName == "Options_Gameplay") {
			ballSpeedSlider.value = PlayerPrefsManager.GetBallSpeed ();
		}
	}
	
	void Update () {
	
		if (Application.loadedLevelName == "Options_Sound") {
			musicManager.ChangeVolume(volumeSilder.value);		
		}
	}
	
	public void SaveAndExitGamePlay() {
		PlayerPrefsManager.SetBallSpeed(ballSpeedSlider.value);
		levelMeneger.LoadLevel("Start");
	}

	public void SaveAndExitSound() {
		PlayerPrefsManager.SetMasterVolume(volumeSilder.value);
		PlayerPrefsManager.SetSoundEffects(soundEffects.value);

		levelMeneger.LoadLevel("Start");
	}
	
	public void SetDefaults() {
		volumeSilder.value = 1f;
	}
}
