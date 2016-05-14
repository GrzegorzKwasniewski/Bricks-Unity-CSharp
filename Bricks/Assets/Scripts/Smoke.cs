using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Invoke("DestroySmoke", 1.0f);
	}
	
	void DestroySmoke(){
		Destroy(gameObject);
	}
}
