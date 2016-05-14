using UnityEngine;
using System.Collections;

public class Power_up : MonoBehaviour {

	public AudioClip crack;
	public GameObject smoke;
	public GameObject powerUp;
	public Texture2D texture;
	
	void OnCollisionEnter2D(Collision2D collision){
		if (PlayerPrefsManager.GetSoundEffects() == 1f) {
			AudioSource.PlayClipAtPoint(crack, this.transform.position);
		}		
		PuffSmoke();
		GameObject power_up = Instantiate(powerUp, this.transform.position, Quaternion.identity) as GameObject;
		Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if (PlayerPrefsManager.GetSoundEffects() == 1f) {
			AudioSource.PlayClipAtPoint(crack, this.transform.position, 0.3f);
		}		
		PuffSmoke();
		GameObject power_up = Instantiate(powerUp, this.transform.position, Quaternion.identity) as GameObject;
		Destroy(gameObject);
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		if (texture.name == "stone_g_08"){
			smokePuff.particleSystem.startColor = new Color(0.2f, 0.7f, 0.3f, 0.8f);
		} else if (texture.name == "wooden_07"){
			smokePuff.particleSystem.startColor = new Color(0.8f, 0.6f, 0.3f, 0.8f);
		} else if (texture.name == "wooden_v_07"){
			smokePuff.particleSystem.startColor = new Color(0.7f, 0.2f, 0.2f, 0.8f);
		} else if (texture.name == "stone_07"){
			smokePuff.particleSystem.startColor = new Color(0.5f, 0.55f, 0.6f, 0.8f);
		} else if (texture.name == "stone_13"){
			smokePuff.particleSystem.startColor = new Color(0.25f, 0.6f, 0.9f, 0.8f);
		} else if (texture.name == "stone_14"){
			smokePuff.particleSystem.startColor = new Color(0.7f, 0.45f, 0.85f, 0.8f);
		} else {
			smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color; //pobiera z obiektu komponent SpriteRenderer
			// i pobiera z niego kolor
		}
	}
}