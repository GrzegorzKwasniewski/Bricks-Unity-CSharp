using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	public int levelNumber;
	public Text level;
	public Button button;

	void Awake(){
		if (PlayerPrefsManager.IsLevelUnlocked(levelNumber)){
			level.text = levelNumber.ToString();
			button.interactable = true;
		} else {
			level.text = "-";
			button.interactable = false;
		}
	}
}
