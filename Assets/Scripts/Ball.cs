using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballSpeedY;
	public Sprite[] ballSprite;
	public Sprite fireBallSprite;
	public Sprite stoneBallSprite;
	public Sprite secondBallSprite;

	public float fireBallTime = 0f;
	public static int ballPower = 100;
	public static bool ballIsBigger;
	public static int ballCount;
	public AudioClip ballDestroyed;
	public GameObject secondBall;
	public bool ballForMainMenu = false;
	
	private Paddle paddle;
	private bool hasStarted = false;
	private SimpleTouchAreaButton areaButton;
	private float ballSpeedFromOptions;
	private AudioSource audio;
	private Vector3 paddleToBallVector = new Vector3(0, 0.6f, 0);

	void Start () {
		audio = GetComponent<AudioSource>();
		
		if (PlayerPrefsManager.GetSoundEffects() == 0f) {
			audio.mute = true;
		}
		
		ballSpeedFromOptions = PlayerPrefsManager.GetBallSpeed ();
		
		if (ballSpeedFromOptions == 1) {
			ballSpeedY = 11f;
		} else if (ballSpeedFromOptions == 2) {
			ballSpeedY = 13f;
		} else if (ballSpeedFromOptions == 3) {
			ballSpeedY = 15f;
		}

		if (gameObject.tag.Equals("Ball")){
			ballCount++;
		}
			
		if (ballForMainMenu == true){
			rigidbody2D.AddForce(new Vector2 (-0.6f, 1.2f), ForceMode2D.Impulse);
		}
		
		if (ballForMainMenu != true){
			areaButton = GameObject.FindObjectOfType<SimpleTouchAreaButton>();
			paddle = GameObject.FindObjectOfType<Paddle>();
			this.transform.position = paddle.transform.position + paddleToBallVector;
				
			if (LevelMeneger.isTwoBalls == true) {
				GameObject ball = Instantiate(secondBall, this.transform.position, Quaternion.identity) as GameObject;
			}
		}

		if (LevelMeneger.isFireBall == true) {
			this.GetComponent<SpriteRenderer> ().sprite = fireBallSprite;
			ballPower = 200;
		} else {
			this.GetComponent<SpriteRenderer>().sprite = ballSprite[Ball_Select.ballSelNum];
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag.Equals("Lose_Collider") || collider.gameObject.tag.Equals("Fire_Ball")) {
			if (PlayerPrefsManager.GetSoundEffects() == 1f) {
				AudioSource.PlayClipAtPoint(ballDestroyed, this.transform.position, 1.0f);
			}
			Destroy(gameObject);
			}
			
		if (collider.tag == "Paddle") {
			rigidbody2D.AddForce(new Vector2 (Random.Range(-0.5f, 0.5f), 1.2f), ForceMode2D.Impulse);
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
	
		if (hasStarted){
			audio.Play();
		}
	}
	
	void FixedUpdate() {			
		rigidbody2D.velocity = rigidbody2D.velocity.normalized * ballSpeedY;
	}
	
	void Update () {
	
		if (ballForMainMenu != true)
		{ 
			if (!hasStarted) {
				this.transform.position = paddle.transform.position + paddleToBallVector;
				
				if (Input.GetKeyDown(KeyCode.Space) || areaButton.CanFire()){
					hasStarted = true;
					rigidbody2D.AddForce(new Vector2 (Random.Range(-0.5f, 0.5f), 1.2f), ForceMode2D.Impulse);
				}
			}
		}

		if (LevelMeneger.isFireBall != true) {
			if (power_up_ball.fireBall) {
				power_up_ball.fireBall = !power_up_ball.fireBall;
				this.GetComponent<SpriteRenderer> ().sprite = fireBallSprite;
				StartCoroutine (AlterBallTime (fireBallTime));
			} 
		}

		if (power_up_ball.stoneBall) {
			power_up_ball.stoneBall = !power_up_ball.stoneBall;
			this.GetComponent<SpriteRenderer> ().sprite = stoneBallSprite;
			StartCoroutine (AlterBallTime (fireBallTime));
		}
		
		Mathf.Clamp(this.rigidbody2D.velocity.x, 11f, 11f);		
	}
	
	IEnumerator AlterBallTime(float time) {
		yield return new WaitForSeconds(time);
		this.GetComponent<SpriteRenderer>().sprite = ballSprite[Ball_Select.ballSelNum];
		ballPower = 100;	
	}
	
	void NormalBall(){
		transform.localScale = new Vector3(0.5f, 0.5f, 0);
	}
}
