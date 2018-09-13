using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void GoToGithub()
	{
    Process.Start("https://github.com/Kawarimi/openstone");
	}
	void ChangeToMatch()
	{
    SceneManager.LoadScene("Game");
	}
	void ChangeToDecks()
	{
    SceneManager.LoadScene("DeckManager");
	}
}
