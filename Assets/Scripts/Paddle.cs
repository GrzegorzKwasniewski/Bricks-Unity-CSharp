using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float speed;
	public Sprite[] paddleSprite;
	public float minX = -3.5f;
	public float maxX = 3.5f;
	public float paddleToNormal = 10f;
	
	private Ball ball;
	private SimpleTouchPad touchPad;
	private float mousePosInBlocks;
	
	void Start() {
		touchPad = GameObject.FindObjectOfType<SimpleTouchPad>();
		this.GetComponent<SpriteRenderer>().sprite = paddleSprite[Paddle_Select.paddleSelNum];
		ball = GameObject.FindObjectOfType<Ball>();
		this.transform.position = new Vector3(0f, -7.0f,0f);
	}
	
	void Update () {
	
		if (Input.touchCount == 1){
			Touch touch = Input.GetTouch(0);	
			float x = -5.5f + 11 * touch.position.x / Screen.width;
			float y = -10.0f + 20 * touch.position.x / Screen.height;	
			transform.position = new Vector3 (x, this.transform.position.y, 0);
		}
	
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			this.transform.position = new Vector3(this.transform.position.x - 0.05f * speed,transform.position.y,0f);
		} else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			this.transform.position = new Vector3(this.transform.position.x + 0.05f * speed,transform.position.y,0f);
		}
		
		this.transform.position = new Vector3 
			( 
				 Mathf.Clamp(rigidbody2D.position.x, minX, maxX),
				 -7.0f,
				 0.0f
			);
		
		if (power_up_ball.isPaddleSmall) {
			power_up_ball.isPaddleSmall = !power_up_ball.isPaddleSmall;
			gameObject.GetComponent<Animator>().SetTrigger("Small");
			StartCoroutine (PaddleToNormal (paddleToNormal));
		}
	}
	
	IEnumerator PaddleToNormal(float time) {
		yield return new WaitForSeconds(time);
		gameObject.GetComponent<Animator>().SetTrigger("Normal");
		
	}
}
