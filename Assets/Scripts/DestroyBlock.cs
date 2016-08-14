using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour {

	public AudioClip crack;
	
	void Update () {
		this.transform.Rotate(0, 0, 0.5f);
		
		if (this.transform.position.y < -12.0f){
			Destroy(gameObject);
		}
	}
}