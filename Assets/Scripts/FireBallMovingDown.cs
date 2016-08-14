using UnityEngine;
using System.Collections;

public class FireBallMovingDown : MonoBehaviour {

	public Ball ball;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag.Equals ("Ball")){
			Destroy(collider.gameObject);
			Instantiate(ball, ball.transform.position, Quaternion.identity);
			Ball.ballCount--;
			Ball.ballPower = 100;
		}
	}
}