using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighestScore : MonoBehaviour {

	// TODO Czy to jest gdzieś używane???
	public Text score;
	public int scoreNumber;
	
	// Update is called once per frame
	void Update () {
			score.text = PlayerPrefsManager.GetHighestScore(scoreNumber).ToString();
		}
}

