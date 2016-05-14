using UnityEngine;
using System.Collections;

public class MoveControll : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount == 1){
			
			Touch touch = Input.GetTouch(0);
			float x = -5.5f + 11 * touch.position.x / Screen.width;
			float y = -10.0f + 20 * touch.position.x / Screen.height;
			transform.position = new Vector3 (x, this.transform.position.y, 0);

		}	
	}
}
