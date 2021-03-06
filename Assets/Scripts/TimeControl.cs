﻿using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	Background background;
	
	void Start () {
		background = GameObject.FindObjectOfType<Background>();
	}
	
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