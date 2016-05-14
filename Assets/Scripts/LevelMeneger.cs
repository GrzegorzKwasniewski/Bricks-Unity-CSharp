using UnityEngine;
using System.Collections;

public class LevelMeneger : MonoBehaviour {

	public GameObject summaryCanvas;
	public GameObject unbreakable;
	public GameObject unbreakable_collider;
	public float loadNextLevel = 3.0f;
	public LoseCollider loseCollider;
	public static bool isTwoBalls;
	public static bool isFireBall;
	public int levelNumber;

	
	void Start(){
		Time.timeScale = 1.0F;
		loseCollider = GameObject.FindObjectOfType<LoseCollider>();
		Ball.ballCount = 0;
	}
	
	void Update(){
		if (Application.loadedLevel == 0){
			Invoke ("SplashLoadNextLevel", loadNextLevel);
		}
		
		if (Brick.brickCount == 0){
			PlayerPrefsManager.UnlockedLevel(levelNumber);
		}
	}
		
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Brick.brickCount = 0;
		Application.LoadLevel (name);
	}

	public void LoadLevelWithTwoBalls(string name){
		Debug.Log ("New Level load: " + name);
		Brick.brickCount = 0;
		Application.LoadLevel (name);
		isTwoBalls = true;

	}

	public void LoadLevelWithFireBall(string name){
		Debug.Log ("New Level load: " + name);
		Brick.brickCount = 0;
		Application.LoadLevel (name);
		isFireBall = true;
		
	}
	
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		Brick.brickCount = 0;
		//Ball.ballCount--;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed() {
		if (Brick.brickCount <= 0) {
			loseCollider.collider2D.isTrigger = false;
			Instantiate(summaryCanvas, this.transform.position, Quaternion.identity);
			Instantiate(unbreakable, new Vector3(0.326f, -5.94f, 0f), Quaternion.identity);
			Instantiate(unbreakable_collider, new Vector3(0f, -7.74f, 0f), Quaternion.identity);

			
			//LoadNextLevel();
		}
	}
	
	public void SplashLoadNextLevel(){
		
		Application.LoadLevel(Application.loadedLevel + 1);
		
	}
}
