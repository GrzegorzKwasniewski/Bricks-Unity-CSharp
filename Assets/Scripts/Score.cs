using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text score;
	public static int scoreSum;


	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		score.text = scoreSum.ToString();
	}
}
