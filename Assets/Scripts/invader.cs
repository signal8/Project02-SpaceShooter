using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invader : MonoBehaviour
{
	public float amplitude = 2.0f;
	public float speed = 0.1f;
	public GameObject invaderPrefab;
	public GameObject ship;
	public float invaderCooldown = 0.5f;
	public float invaderSpeed = 5.0f;
	public int hp = 50;

	private float timer = 0.0f;
	private float timer2;
	private int totalHP;
	private GameObject scoreDisplay;
	private float movementMultiplier;
	private float spawnMultiplier;

    	// Start is called before the first frame update
    	void Start()
    	{
		scoreDisplay = GameObject.Find("Score");
        	timer2 = invaderCooldown;
		totalHP = hp;
    	}

    	// Update is called once per frame
    	void Update()
    	{
		movementMultiplier = (totalHP - hp)/160;
		spawnMultiplier = (totalHP - hp)/600;

		float dt = Time.deltaTime;
		Vector3 pos = transform.position;
		timer += (speed + movementMultiplier) * dt;

		pos = new Vector3(Mathf.Cos(timer) *  amplitude * 2, 
				Mathf.Sin(timer) * amplitude, 0);

		if (timer2 > 0.0f) timer2 -= dt;
		else
		{
			timer2 = invaderCooldown - spawnMultiplier;
			GameObject i = Instantiate(invaderPrefab, pos,
					Quaternion.identity);
			Rigidbody2D irb = i.GetComponent<Rigidbody2D>();
			if (ship.transform.position.x < pos.x)
				irb.velocity = Vector3.left * invaderSpeed;	
			else irb.velocity = Vector3.right * invaderSpeed;
		}

		transform.position = pos;
    	}

	void Hit()
    	{
		hp--;
		scoreManager.AddScore(100);
		scoreDisplay.SendMessage("UpdateText");
		if (hp <= 0) 
		{
			ship.SendMessage("StartWinTimer");
			Destroy(gameObject);
		}
    	}
}
