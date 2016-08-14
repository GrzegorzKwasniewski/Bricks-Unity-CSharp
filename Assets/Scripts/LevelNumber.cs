using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelNumber : MonoBehaviour {

	public Text text;
	
	void Start () {
		text.text = "Lv " + Application.loadedLevel.ToString();
	}
}
