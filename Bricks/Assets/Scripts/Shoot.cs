using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision){
	 Destroy(gameObject);
	}
}
