using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float shootSpeed = 10.0f;
	public float fireRate = 2.0f;
	public GameObject shoot;
	public Paddle paddle;
	
	private float nextFire;
	private float paddlePosX;
	private float paddlePosY;
	private Vector3 paddleToGunVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddlePosX = - 0.8f;
		paddlePosY =  0.45f;
		paddleToGunVector = new Vector3(paddlePosX, paddlePosY, 0);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = paddle.transform.position + paddleToGunVector;
		if (Time.time > nextFire){
			nextFire = Time.time + fireRate; 
			float posY = this.transform.position.y + 0.7f;
			Vector3 pos1 = new Vector3 (this.transform.position.x, posY, 0f);
			Vector3 pos2 = new Vector3 (this.transform.position.x + 1.55f, posY, 0f);
			GameObject shootMoving_1 = Instantiate(shoot, pos1, Quaternion.identity) as GameObject;
			GameObject shootMoving_2 = Instantiate(shoot, pos2, Quaternion.identity) as GameObject;
			shootMoving_1.rigidbody2D.velocity = new Vector2 (0f, shootSpeed);
			shootMoving_2.rigidbody2D.velocity = new Vector2 (0f, shootSpeed);
		}
		
		Invoke("Destroy", 10.0f);
	}
	
	void Destroy(){
		Destroy(gameObject);
	}
}
