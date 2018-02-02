using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Display : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text myText = GetComponent<Text>();
		myText.text = "Score : " + ScoreKeeper.score;
		ScoreKeeper.reset();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
