using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {

	void Update () {
		Invoke("Destroy", 1.0f);
	}
	
	void Destroy(){
		Destroy(gameObject);
	}
}
