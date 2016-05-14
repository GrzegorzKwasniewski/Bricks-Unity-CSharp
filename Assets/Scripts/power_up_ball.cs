using UnityEngine;
using System.Collections;

public class power_up_ball : MonoBehaviour {

	public float tweakY = 4.0f;
	public static bool fireBall;
	public static bool stoneBall;
	public static bool isPaddleSmall;
	
	public GameObject bonus;
	
	private Paddle paddle;
	private Ball ball;
	private Vector3 extraBallPos;

	void Start(){
		Vector2 tweak = new Vector2(0f, tweakY);
		this.rigidbody2D.velocity -= tweak;
		paddle = GameObject.FindObjectOfType<Paddle>();
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update(){

		extraBallPos = paddle.transform.position + new Vector3(0, 0.6f, 0);
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag.Equals ("Paddle")) {
			if (gameObject.tag.Equals ("PowerUp_Ball_1")) {
				GameObject bonusFromBall = Instantiate (bonus, new Vector3 (paddle.transform.position.x - 0.5f, paddle.transform.position.y + 0.5f, 0f), Quaternion.identity) as GameObject;
			} else if (gameObject.tag.Equals ("PowerUp_Ball_2")) {
				fireBall = true;
				Ball.ballPower = 200;
			} else if (gameObject.tag.Equals ("PowerUp_Ball_3")) {
				GameObject bonusFromBall = Instantiate (bonus, extraBallPos, Quaternion.identity) as GameObject;
			} else if (gameObject.tag.Equals ("PowerUp_Ball_4")) {
				GameObject bonusFromBall = Instantiate (bonus, new Vector3 (-7.0f, Random.Range (-2.0f, 7.0f), 0f), Quaternion.identity) as GameObject;
			} else if (gameObject.tag.Equals ("PowerUp_Ball_5")) {
				GameObject bonusFromBall = Instantiate (bonus, new Vector3 (Random.Range (-4.0f, 4.0f), 11.0f, 0f), Quaternion.identity) as GameObject;
			} else if (gameObject.tag.Equals ("PowerUp_Ball_6")) {
				GameObject bonusFromBall = Instantiate (bonus, new Vector3 (0, -12.0f, 0f), Quaternion.identity) as GameObject;
				Debug.Log ("No i jest grucha");
			} else if (gameObject.tag.Equals ("PowerUp_Ball_7")) {
				Lives.lives++;
			} else if (gameObject.tag.Equals ("PowerUp_Ball_8")) {
				GameObject bonusFromBall = Instantiate (bonus, new Vector3 (Random.Range (3.0f, 9.0f), Random.Range (17.0f, 7.0f), 0f), Quaternion.identity) as GameObject;
			} else if (gameObject.tag.Equals ("PowerUp_Ball_9")) {
				Debug.Log ("Ok działa");
				stoneBall = true;
				Ball.ballPower = 0;
			} else if (gameObject.tag.Equals ("PowerUp_Ball_10")) {
				for (int i = 0; i <= 5; i++) {
					GameObject bonusFromBall = Instantiate (bonus, extraBallPos, Quaternion.identity) as GameObject;
				}
			} else if (gameObject.tag.Equals ("PowerUp_Ball_11")) {
				GameObject bonusFromBall = Instantiate (bonus, new Vector3 (Random.Range (-3.0f, 3.0f), 11f, 0f), Quaternion.identity) as GameObject;
			} else if (gameObject.tag.Equals ("PowerUp_Ball_12")) {
				isPaddleSmall = true;
			}
		
			Destroy (gameObject);
			
	} else if (collider.gameObject.tag.Equals("Collider_power_up")) {
			Destroy(gameObject);
		}
	}

		
}
