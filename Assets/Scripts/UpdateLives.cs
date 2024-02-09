using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateLives : MonoBehaviour
{
	private TMP_Text text;
    	// Start is called before the first frame update
    	void Start()
    	{
        	text = GetComponent<TMP_Text>();
    	}

    	void UpdateText()
	{
		int num = scoreManager.GetLives();
		text.text = "x" + num.ToString();
	}
}
