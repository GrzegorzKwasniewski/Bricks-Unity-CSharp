using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	public AudioClip crack;
	public GameObject smoke;

	void OnCollisionEnter2D(Collision2D collision) {
	
		if (PlayerPrefsManager.GetSoundEffects() == 1f) {
			AudioSource.PlayClipAtPoint(crack, this.transform.position);
		}		
		PuffSmoke();
		Destroy(gameObject);
		Score.scoreSum += 10;
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
	
		if (PlayerPrefsManager.GetSoundEffects() == 1f) {
			AudioSource.PlayClipAtPoint(crack, this.transform.position, 0.3f);
		}
		PuffSmoke();
		Destroy(gameObject);
		Score.scoreSum += 10;
	}
	
	void PuffSmoke() {
		GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = new Color(0.8f, 0.4f, 0.3f, 1f);
	}
}
