using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	private Background background;
	
	// Use this for initialization
	void Start () {
		background = GameObject.FindObjectOfType<Background>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			if (Time.timeScale == 1.0F){
				Time.timeScale = 0.1F;
				background.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
				
			} else {
				Time.timeScale = 1.0F;
				background.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			}
		}
	}
}