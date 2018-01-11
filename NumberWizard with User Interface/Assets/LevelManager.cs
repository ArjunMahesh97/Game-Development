using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public void LoadLevel(string name)
	{
		Debug.Log ("level load requested");
		Application.LoadLevel(name);
	}
	
	public void QuitLevel(string name)
	{
		Debug.Log ("Game Exited");
		Application.Quit();
	}
}
