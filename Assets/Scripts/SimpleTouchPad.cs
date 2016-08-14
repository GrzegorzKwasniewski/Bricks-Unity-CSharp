using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
	
	public Background background;
	public float smoothing;
	public float MovementRange = 3.5f;
	
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
	
	public void OnPointerDown (PointerEventData data) {
	
		if (!touched) {
			touched = true;
			pointerID = data.pointerId;
			Time.timeScale = 1.0F;
 			background.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}	
	}
	
	public void OnDrag (PointerEventData data) {}
	
	public void OnPointerUp (PointerEventData data) {
	
		if (data.pointerId == pointerID) {
			direction = Vector2.zero;
			touched = false;

			if (Time.timeScale == 1.0F){
				Time.timeScale = 0.1F;
				background.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
			}
		}
	}
	
	public Vector2 GetDirection () {
		smoothDirection = Vector2.MoveTowards (smoothDirection, direction, smoothing); // sprawdź sobie co dokładnie robi ta funkcja
		return smoothDirection;
	}
}
