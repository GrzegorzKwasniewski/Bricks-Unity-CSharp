using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelNumber : MonoBehaviour {

	public Text text;
	
	// Use this for initialization
	void Start () {
		text.text = "Lv " + Application.loadedLevel.ToString();
	}
}
