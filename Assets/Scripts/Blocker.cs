using UnityEngine;
using System.Collections;

public class Blocker : MonoBehaviour {

	private Ball ball;
	private Vector3 ballPos;
	private bool ballPosTrue = false;
	private bool destroyerBack = true;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (this.transform.position.y < -8.81 && destroyerBack){
			this.transform.position += new Vector3(0, 0.1f, 0);
		} else if (this.transform.position.y >= -8.81 && destroyerBack){
			ballPosTrue = true;
		}
		if (ballPosTrue){
			AutoPlay();
		}
		Invoke("Destroy", 10.0f);
	}
	
	void AutoPlay(){
		if (ball != null){
		ballPos = ball.transform.position;
		this.transform.position = new Vector3(Mathf.Clamp(ballPos.x,-3.8f, 3.8f),-8.81f,0);
		} else {
			Destroy(gameObject);	
		}
	}
	
	void Destroy(){
		ballPosTrue = false;
		destroyerBack = false;
		this.transform.position -= new Vector3(0,0.1f,0);
		if (this.transform.position.y < -12.0f){
		Destroy(gameObject);
		}
	}
}
