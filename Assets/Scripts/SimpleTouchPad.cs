using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
	
	public Background background;
	
	public float smoothing;
	public float MovementRange = 3.5f;


//	public bool pauseButtonIsActiv;
	
	private Vector2 origin;
	private Vector2 direction;
	private Vector2 smoothDirection;
	private bool touched;
	private int pointerID;
	private Vector3 m_StartPos;
	private Canvas canvas;
	private Ball ball;
	private Animator animator;
	
	void Awake () {
		direction = Vector2.zero;
		touched = false;
	}
	
	void Start(){
		
		if (background == null){
		background = FindObjectOfType<Background>();
		}
		
		ball = FindObjectOfType<Ball>(); 
		animator = ball.GetComponent<Animator>();
		m_StartPos = transform.position;
	}


	void Update() {
//		Debug.Log (pauseButtonIsActiv);
//		if (pauseButtonIsActiv == true) {
//			Button pauseButtonInstance = Instantiate (pauseButton, pauseButton.transform.position, Quaternion.identity) as Button;
//			} 
//
//		if (pauseButtonIsActiv == false) {
//			DestroyImmediate(pauseButton, true);
//		}
	}

	
	public void OnPointerDown (PointerEventData data) {
	// set our start point
		if (!touched) {
//			pauseButtonIsActiv = false;
			touched = true;
			pointerID = data.pointerId;
			//origin = data.position; //!!!!

//			Debug.Log("Jest Palec");

			Time.timeScale = 1.0F;
			//Time.fixedDeltaTime = 0.02F * Time.timeScale;
 			background.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
 			
		}
		
		
	}
	
	public void OnDrag (PointerEventData data) {

	// compare the difference betwen our start point and current pointer pos
		
		//Vector3 newPos = Vector3.zero;
		
		//if (data.pointerId == pointerID) {
			//Vector2 currentPosition = data.position;
			//Vector2 directionRaw = currentPosition - origin;
			//direction = directionRaw.normalized;
			
			//float delta = (data.position.x * 0.01f - m_StartPos.x );
			//delta = Mathf.Clamp(delta, - MovementRange, MovementRange);
			//newPos.x = delta;
			//this.transform.position = new Vector3(m_StartPos.x + newPos.x, this.transform.position.y, 0.0f);
		}
	
	public void OnPointerUp (PointerEventData data) {
	// reset everything
		if (data.pointerId == pointerID) {
			direction = Vector2.zero;
//			pauseButtonIsActiv = true;
			touched = false;
			//this.transform.position = m_StartPos;

//			Debug.Log("Nie ma Palca");



//			Button pauseButtonInstance = Instantiate(pauseButton, pauseButton.transform.position, Quaternion.identity) as Button;
//			pauseButtonInstance.transform.parent = canvas.transform;
			
			if (Time.timeScale == 1.0F){
				Time.timeScale = 0.1F;
				background.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
				
			}
		}
	}
	
	public Vector2 GetDirection () {
	// ogólnie poniższe "wygładza" ruch obiektu
		smoothDirection = Vector2.MoveTowards (smoothDirection, direction, smoothing); // sprawdź sobie co dokładnie robi ta funkcja
		return smoothDirection;
	}
	
}
