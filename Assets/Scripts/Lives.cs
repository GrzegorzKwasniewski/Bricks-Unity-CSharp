using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lives : MonoBehaviour {

	public Text score;
	public static int lives = 5;
	
	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		score.text = lives.ToString();
	}
}
