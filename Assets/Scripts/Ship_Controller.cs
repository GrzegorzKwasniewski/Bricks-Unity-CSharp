using UnityEngine;
using System.Collections;

public class Ship_Controller : MonoBehaviour {

	void Start () {
		this.transform.rotation = new Quaternion(90f, 90f, 0f, 0);
	}
	
	void Update () {
	
		this.transform.position += new Vector3 (0.1f * Time.timeScale, 0, 0);
		
		if (this.transform.position.x > 7.0f){
			Destroy(gameObject);
		}
	}
	
	void OnTrrigerEnter2D(Collider2D collider){
		audio.Play();
	}
}
