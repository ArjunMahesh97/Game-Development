using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour 
{

	// Use this for initialization

	int max;
	int min;
	int guess;
	
	int maxGuess = 15;	
	
	public Text text;
				
	void Start () 
	{
		StartGame();		
	}
	void StartGame()
	{
		max = 1000;
		min = 1;
		NextGuess();
	}
	
	public void GuessHigher()
	{
		min = guess;
		NextGuess();
	}	
	
	public void GuessLower()
	{
		max = guess;
		NextGuess();
	}
	
	public void NextGuess()
	{
		guess = Random.Range (min,max+1);
		text.text = guess.ToString();
		maxGuess = maxGuess - 1;
		if(maxGuess<=0)
		{
			Application.LoadLevel("Win");
		}	
	}	
}