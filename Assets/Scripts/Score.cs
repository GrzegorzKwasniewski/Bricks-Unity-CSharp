using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text score;
	public static int scoreSum;

	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
	void Update () {
		score.text = scoreSum.ToString();
	}
}