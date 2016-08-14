using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lives : MonoBehaviour {

	public Text score;
	public static int lives = 5;
	
	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
	void Update () {
		score.text = lives.ToString();
	}
}
