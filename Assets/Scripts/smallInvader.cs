using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallInvader : MonoBehaviour
{
	private GameObject scoreDisplay;
	private float flyDirection;

	public float offLeftScreen = -9.5f;
	public float amplitude = 0.5f;

	void Awake()
	{
		scoreDisplay = GameObject.Find("Score");
		flyDirection = Mathf.Round(Random.value);
		if (flyDirection == 0.0f) flyDirection = -1.0f;
	}

	void Update()
	{
		if (transform.position.x < offLeftScreen
				|| transform.position.x > -offLeftScreen)
			Destroy(gameObject);

		Vector3 pos = transform.position;
		pos.y += Mathf.Sin(pos.x/100) * amplitude * flyDirection;
		transform.position = pos;
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.gameObject.CompareTag("Player")) return;
		else
		{
			Destroy(gameObject);
		}
	}

	void Hit()
	{
		scoreManager.AddScore(50);
		scoreDisplay.SendMessage("UpdateText");
		Destroy(gameObject);
	}
}
