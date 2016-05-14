using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lives : MonoBehaviour {

	public static int lives = 5;
	public Text score;
	
	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		score.text = lives.ToString();
	}
}
