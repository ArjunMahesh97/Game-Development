using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	
	public static int score = 0;
	private Text myText;
	
	void Start()
	{
		myText = GetComponent<Text>();
		reset();
	}
	 
	public void Score(int point)
	{
		score += point;
		myText.text = "Score: " + score;
	}
	
	public static void reset()
	{
		score=0;
	}
}