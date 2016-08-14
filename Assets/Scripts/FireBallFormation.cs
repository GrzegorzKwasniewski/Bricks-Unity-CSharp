using UnityEngine;
using System.Collections;

public class FireBallFormation : MonoBehaviour {

	void Update () {
		Invoke("Destroy", 5.0f);
	}
	
	void Destroy(){
		Destroy(gameObject);
	}
}
