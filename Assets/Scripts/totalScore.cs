using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class totalScore : MonoBehaviour
{
	private TMP_Text text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TMP_Text>();
	int score = scoreManager.GetScore();
	text.text = "Total Score: " + score.ToString();
    }
}
