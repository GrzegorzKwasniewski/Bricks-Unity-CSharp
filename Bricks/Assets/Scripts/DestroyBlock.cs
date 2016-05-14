using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour {

	public AudioClip crack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(0, 0, 0.5f);
		if (this.transform.position.y < -12.0f){
			Destroy(gameObject);
		}
	}
}