using UnityEngine;
using System.Collections;

public class FireBallFormation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Invoke("Destroy", 5.0f);
	}
	
	void Destroy(){
		Destroy(gameObject);
	}
}
