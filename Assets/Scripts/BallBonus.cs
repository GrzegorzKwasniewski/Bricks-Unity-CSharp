using UnityEngine;
using System.Collections;

public class BallBonus : MonoBehaviour {
	
	public float ballSpeedY;	
	public int ballBonusPower = 100;
	public AudioClip ballDestroyed;
	
	private Paddle paddle;
	private bool hasStarted = false;
	private SimpleTouchAreaButton areaButton;
	private float ballSpeedFromOptions;	
	private Vector3 paddleToBallVector = new Vector3(0, 0.6f, 0);
	
	void Start () {
		ballSpeedFromOptions = PlayerPrefsManager.GetBallSpeed ();
		
		if (ballSpeedFromOptions == 1) {
			ballSpeedY = 11f;
		} else if (ballSpeedFromOptions == 2) {
			ballSpeedY = 13f;
		} else if (ballSpeedFromOptions == 3) {
			ballSpeedY = 15f;
		}
		
		areaButton = GameObject.FindObjectOfType<SimpleTouchAreaButton>();
		paddle = GameObject.FindObjectOfType<Paddle>();
		this.transform.position = paddle.transform.position + paddleToBallVector;
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
	
		if (collider.gameObject.tag.Equals("Lose_Collider")){
			AudioSource.PlayClipAtPoint(ballDestroyed, this.transform.position, 1.0f);
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		
		if (collision.gameObject.tag.Equals("Wall")) {
		
			if (this.rigidbody2D.velocity.y <= 0){
				this.rigidbody2D.velocity -= new Vector2(0, 0.05f);
			} else if (this.rigidbody2D.velocity.y > 0){
				this.rigidbody2D.velocity += new Vector2 (0, 0.05f);
			}
		}
		
		if (hasStarted){
			audio.Play();
		}
	}
	
	void FixedUpdate() {
		rigidbody2D.velocity = rigidbody2D.velocity.normalized * ballSpeedY;
	}
	
	void Update () {
	
		if (!hasStarted){
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			if (Input.GetKeyDown(KeyCode.Space) || areaButton.CanFire()){
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (Random.Range(-5.0f, 5.0f), ballSpeedY);
			}
		}
	}
}
