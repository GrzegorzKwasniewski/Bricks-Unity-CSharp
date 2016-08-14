using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighestScore : MonoBehaviour {

	public Text score;
	public int scoreNumber;

	void Update () {
		score.text = PlayerPrefsManager.GetHighestScore(scoreNumber).ToString();
	}
}

