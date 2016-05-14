using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	public Ball ball;
	public GameObject loseCanvas;
	public GameObject blocks;
	
	private LevelMeneger levelMeneger;
	
	
	void Start(){
		levelMeneger = GameObject.FindObjectOfType<LevelMeneger>();
		blocks = GameObject.FindWithTag("Blocks");
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag.Equals("Ball")){
		Instantiate(ball, ball.transform.position, Quaternion.identity);
		Ball.ballCount--;
		Ball.ballPower = 100;
		}
		
		if(Ball.ballCount == 0){
		Lives.lives--;
		}
		
		if (Lives.lives == 0){
		//levelMeneger.LoadLevel("Lose Screen");
		blocks.SetActive(false);
		Instantiate(loseCanvas, this.transform.position, Quaternion.identity);
		PlayerPrefsManager.SetHighestScore(Score.scoreSum);
		Score.scoreSum = 0;
		LevelMeneger.isTwoBalls = false;
		LevelMeneger.isFireBall = false;
		Lives.lives = 5;
		}
	}
}