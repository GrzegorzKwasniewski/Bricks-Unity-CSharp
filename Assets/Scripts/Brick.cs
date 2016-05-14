using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public GameObject smoke;
	public Texture2D texture;
	public static int score;
	public int howMuchPoints = 1;

	public static int brickCount = 0;
	
	private int maxHits;
	private int timesHit;
	private LevelMeneger levelMeneger;
	
	private bool isBreakable;
	
	
	// Use this for initialization
	void Start () { 
		isBreakable = (this.tag == "Breakable");
		//Keep track of braleable bricks
		if (isBreakable){
			brickCount++;
		}
		timesHit = 0;
		levelMeneger = GameObject.FindObjectOfType<LevelMeneger>();
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if (isBreakable){
			if (Ball.ballPower >= 200){
				if (PlayerPrefsManager.GetSoundEffects() == 1f) {
					AudioSource.PlayClipAtPoint(crack, this.transform.position, 0.3f);
				}
				brickCount--;
				levelMeneger.BrickDestroyed();
				PuffSmoke();
				Destroy(gameObject);
				Score.scoreSum += howMuchPoints;
			} else if (Ball.ballPower == 0){
			
				} else { 
				if (PlayerPrefsManager.GetSoundEffects() == 1f) {
					AudioSource.PlayClipAtPoint(crack, this.transform.position, 0.3f);
				}				
				HandleHits();
			}
		}
	}
		
	void OnTriggerEnter2D(Collider2D collider){
		if (isBreakable){
			AudioSource.PlayClipAtPoint(crack, this.transform.position);
			brickCount--;
			levelMeneger.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
			Score.scoreSum += howMuchPoints;
		}
	}
	
	void HandleHits(){
		timesHit++;
		maxHits = hitSprites.Length + 1;	 
		if (timesHit >= maxHits){ 
			brickCount--;
			levelMeneger.BrickDestroyed();
			PuffSmoke();		
			Destroy(gameObject);
			Score.scoreSum += howMuchPoints;
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		if (texture.name == "1"){
			smokePuff.particleSystem.startColor = new Color(0.9f, 0.5f, 0.2f, 0.8f);
		} else if (texture.name == "2"){
			smokePuff.particleSystem.startColor = new Color(0.9f, 0.9f, 0.05f, 0.8f);
		} else if (texture.name == "3"){
			smokePuff.particleSystem.startColor = new Color(0.2f, 0.75f, 0.95f, 0.8f);
		} else if (texture.name == "4"){
			smokePuff.particleSystem.startColor = new Color(0.9f, 0.2f, 0.4f, 0.8f);
		} else if (texture.name == "5"){
			smokePuff.particleSystem.startColor = new Color(0.1f, 0.9f, 0.45f, 0.8f);
		} else if (texture.name == "6"){
			smokePuff.particleSystem.startColor = new Color(0.95f, 0.15f, 0.8f, 0.8f);
		} else if (texture.name == "stone_g_01"){
			smokePuff.particleSystem.startColor = new Color(0.45f, 0.4f, 0.35f, 0.8f);
		} else if (texture.name == "ice_01"){
			smokePuff.particleSystem.startColor = new Color(0.65f, 0.75f, 0.85f, 0.8f);
		} else if (texture.name == "wooden_01"){
			smokePuff.particleSystem.startColor = new Color(0.85f, 0.55f, 0.15f, 0.8f);
		} else if (texture.name == "wooden_v_02"){
			smokePuff.particleSystem.startColor = new Color(0.6f, 0.3f, 0.3f, 0.8f);
		} else if (texture.name == "stone_01"){
			smokePuff.particleSystem.startColor = new Color(0.55f, 0.55f, 0.55f, 0.8f);
		} else {
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color; //pobiera z obiektu komponent SpriteRenderer
		// i pobiera z niego kolor
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null){ //jeżeli sprite z danym indexem istnieje
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("There is no sprite"); //sprawdza, czy pod danym indexem znjadziemy sprita
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
	
	}
}
