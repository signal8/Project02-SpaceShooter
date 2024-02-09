using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public static class scoreManager
{
	static int score = 0;
	static int lives = 3;
	
	public static int GetScore()
	{
		return score;
	}

	public static void SetScore(int p)
	{
		score = p;
	}

	public static void AddScore(int p)
	{
		score += p;
	}

	public static int GetLives()
	{
		return lives;
	}

	public static void SetLives(int l)
	{
		lives = l;
	}

	public static void SubLives()
	{
		lives--;
	}
}
