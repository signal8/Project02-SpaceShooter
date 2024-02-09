using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonHandler : MonoBehaviour
{
    	void Begin()
	{
		scoreManager.SetScore(0);
		scoreManager.SetLives(3);
		SceneManager.LoadScene(1);
	}
	void Quit()
	{
		Application.Quit();
	}
	void Restart()
	{
		SceneManager.LoadScene(0);
	}
}
