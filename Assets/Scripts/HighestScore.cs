using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighestScore : MonoBehaviour {

	public Text score;
	public int scoreNumber;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			score.text = PlayerPrefsManager.GetHighestScore(scoreNumber).ToString();
		}
}

