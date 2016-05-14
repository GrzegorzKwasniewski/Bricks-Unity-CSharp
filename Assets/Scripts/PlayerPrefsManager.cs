using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	static PlayerPrefsManager instance = null;

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	const string BALL_SPEED = "ball_speed";
	const string SOUND_EFFECTS = "sound_effects";
	const string HIGH_SCORES = "highest_score";



	//const string HIGHEST_SCORES = "highest_score";
	
	
	void Awake(){

		//GameObject.DontDestroyOnLoad(gameObject);

	}
	
	public static void SetHighestScore(int score){
		
		int temp;
		
		for(int i=1; i<=10; i++) //for top 5 highscores
		{
			if(GetHighestScore(i)< score)     //if cuurent score is in top 5
			{
				temp = GetHighestScore(i);     //store the old highscore in temp varible to shift it down 
				PlayerPrefs.SetInt(HIGH_SCORES + i,score);     //store the currentscore to highscores
				if(i<10)                                        //do this for shifting scores down
				{
					int j=i+1;
					score = GetHighestScore(j); 
					PlayerPrefs.SetInt(HIGH_SCORES + j,temp);    
				}
			}
		}
	}
	
	public static int GetHighestScore(int position){
		return PlayerPrefs.GetInt(HIGH_SCORES + position);
	}
	
	public static void SetMasterVolume (float volume){
		if (volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Volume out of range");
		}
	}
	
	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void SetBallSpeed (float speed){
		if (speed >= 1f && speed <= 3f){
			PlayerPrefs.SetFloat (BALL_SPEED, speed);
		} else {
			Debug.LogError("Speed out of range");
		}
	}

	public static float GetBallSpeed(){
		return PlayerPrefs.GetFloat(BALL_SPEED);
	}

	public static void SetSoundEffects (float isOn){
		if (isOn >= 0f && isOn <= 1f){
			PlayerPrefs.SetFloat (SOUND_EFFECTS, isOn);
		} else {
			Debug.LogError("Number out of range");
		}
	}
	
	public static float GetSoundEffects(){
		return PlayerPrefs.GetFloat(SOUND_EFFECTS);
	}
	
	public static void UnlockedLevel(int level){
		if (level <= Application.levelCount - 1){
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
		} else {
			Debug.LogError("Level number is out of range of bulid");
		}
	}
	
	public static bool IsLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		
		if (level > Application.levelCount - 1){
			Debug.LogError("Level number is out of range of bulid");
			return false;
		} else {
			return isLevelUnlocked;
		}
	}
	
	public static void SetDifficultyValue (float difficulty){
		if (difficulty >= 0f && difficulty <= 1f){
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty out of range");
		}
	}
	
	public static float GetDifficultyValue(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}

	public void DeleteUnlockedLevels(){
		for (int i = 1; i < 10; i++) {
			PlayerPrefs.DeleteKey("level_unlocked_" + i.ToString());
			Application.LoadLevel("Options_Reset_Confirmation");
		}
	}

	public void DeleteHighScores(){
		for (int i = 1; i < 10; i++) {
			PlayerPrefs.DeleteKey("highest_score" + i.ToString());
			Application.LoadLevel("Options_Reset_Confirmation");
		}
	}
	
}