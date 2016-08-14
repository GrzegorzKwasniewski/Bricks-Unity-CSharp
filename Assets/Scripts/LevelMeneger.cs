using UnityEngine;
using System.Collections;

public class LevelMeneger : MonoBehaviour {

	public GameObject summaryWinningCanvas;
	public GameObject summaryCanvas;
	public GameObject summaryDialog;
	public GameObject unbreakable;
	public GameObject unbreakable_collider;
	public float loadNextLevel = 3.0f;
	public LoseCollider loseCollider;
	public static bool isTwoBalls;
	public static bool isFireBall;
	public int levelNumber;
	public bool isLastLevel;
	public bool levelForPlaying;
	public bool startScene;

	
	void Start(){
		Time.timeScale = 1.0F;
		loseCollider = GameObject.FindObjectOfType<LoseCollider>();
		Ball.ballCount = 0;
	}
	
	void Update(){
	
		if (Application.loadedLevel == 0){
			Invoke ("SplashLoadNextLevel", loadNextLevel);
		}
		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (levelForPlaying) {
				Instantiate(summaryDialog, this.transform.position, Quaternion.identity);
			} else if (startScene) {
				Application.Quit();
			} else {
				Application.LoadLevel("Start");
			}
		}
		
		if (Brick.brickCount == 0){
			PlayerPrefsManager.UnlockedLevel(levelNumber);
		}
	}
		
	public void LoadLevel(string name){
		Brick.brickCount = 0;
		Application.LoadLevel (name);
	}

	public void LoadLevelWithTwoBalls(string name){
		Brick.brickCount = 0;
		Application.LoadLevel (name);
		isTwoBalls = true;
	}

	public void LoadLevelWithFireBall(string name){
		Brick.brickCount = 0;
		Application.LoadLevel (name);
		isFireBall = true;
	}
	
	public void QuitRequest(){
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		Brick.brickCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed() {
	
		if (Brick.brickCount <= 0) {
			loseCollider.collider2D.isTrigger = false;
			Instantiate(unbreakable, new Vector3(0.326f, -5.94f, 0f), Quaternion.identity);
			Instantiate(unbreakable_collider, new Vector3(0f, -7.74f, 0f), Quaternion.identity);
			
			if (isLastLevel) {
				PlayerPrefsManager.SetHighestScore(Score.scoreSum);
				Instantiate(summaryWinningCanvas, this.transform.position, Quaternion.identity);
			} else {
				Instantiate(summaryCanvas, this.transform.position, Quaternion.identity);
			}
		}
	}
	
	public void quitPlaying(bool quit) {
	
		if (quit) {
			Brick.brickCount = 0;
			Score.scoreSum = 0;
			LevelMeneger.isTwoBalls = false;
			LevelMeneger.isFireBall = false;
			Lives.lives = 5;
			Application.LoadLevel("start");
		} else {
			GameObject dialog = GameObject.Find("CanvasDialog(Clone)");
			DestroyImmediate(dialog, true);
		}
	}
	
	public void SplashLoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
