using UnityEngine;
using System.Collections;

public class FireBallMovingDown : MonoBehaviour {

	public Ball ball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag.Equals ("Ball")){
			Destroy(collider.gameObject);
			Instantiate(ball, ball.transform.position, Quaternion.identity);
			Ball.ballCount--;
			Ball.ballPower = 100;
		}
	}
}