using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shipMovement : MonoBehaviour
{
	public float speed = 10.0f;
	public float horizontalBarrier = 8.0f;
	public float verticalBarrier = 4.0f;
	public GameObject bulletPrefab;
	public GameObject backShotPrefab;
	public GameObject explosion;
	public AudioSource zap;
	public float bulletCooldown = 1.0f;
	public float firingSpeed = 20.0f;
	public float invincibilityDuration = 4.0f;
	public float deathDuration = 1.0f;

	private float bulTimer, bsTimer, invTimer, dTimer = 0.0f;
	private float wTimer = -1.0f;
	private Vector3 pos = Vector3.zero;
	private GameObject bp, bsp;
	private GameObject livesDisplay;
	private BoxCollider2D b2d;
	private SpriteRenderer sr;
	private bool respawning = false;
	private bool dying = false;

	// Start is called before the first frame update
	void Start()
	{
        	bp = GameObject.Find("BulletPoint");
		bsp = GameObject.Find("BackShotPoint");
		livesDisplay = GameObject.Find("Lives");
		b2d = gameObject.GetComponent<BoxCollider2D>();
		sr = gameObject.GetComponent<SpriteRenderer>();
	}

    	// Update is called once per frame
    	void Update()
    	{
		float dt = Time.deltaTime;
		if (dying)
		{
			dTimer -= dt;
			if (dTimer <= 0.0f)
			{
				if (scoreManager.GetLives() < 0) Die();
				livesDisplay.SendMessage("UpdateText");
				respawning = true;
				invTimer = invincibilityDuration;
				sr.color = Color.white;
				dying = false;
			}
			return;
		}
		if (respawning)
		{
			invTimer -= dt;
			bool oddeven = Mathf.FloorToInt(Time.time * 8) % 2 == 0;
			sr.enabled = oddeven;			

			if (invTimer <= 0.0f)
			{
				b2d.enabled = true;
				sr.enabled = true;
				respawning = false;
			}
		}

		if (wTimer > 0) wTimer -= dt;
		else if (wTimer > -1.0f) Die();

		pos = Vector3.zero;

    	    	if (Input.GetKey("up") &&
			transform.position.y <= verticalBarrier) 
				pos += Vector3.up * speed * dt;
		else if (Input.GetKey("down") &&
			transform.position.y >= -verticalBarrier) 
				pos += Vector3.down * speed * dt;

    	    	if (Input.GetKey("left") && 
			transform.position.x >= -horizontalBarrier) 
				pos += Vector3.left * speed * dt;
		else if (Input.GetKey("right") &&
			transform.position.x <= horizontalBarrier)
				pos += Vector3.right * speed * dt;

		transform.position += pos;

		if (Input.GetKey("z") && bulTimer <= 0.0f)
		{
			bulTimer = bulletCooldown;
			GameObject b = Instantiate(bulletPrefab, 
					bp.transform.position,
					Quaternion.identity);
			Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
			brb.velocity = Vector3.right * firingSpeed;
			zap.Play();
		}
		else if (Input.GetKey("x") && bsTimer <= 0.0f)
		{
			bsTimer = bulletCooldown * 2;
			GameObject b = Instantiate(backShotPrefab, 
					bsp.transform.position,
					Quaternion.identity);
			Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
			brb.velocity = Vector3.left * firingSpeed;
			zap.Play();
		} 
		else if (bulTimer > 0.0f || bsTimer > 0.0f)
		{
			bulTimer -= dt;
			bsTimer -= dt;
		}
		
    	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.CompareTag("Enemy")) return;
	
		Instantiate(explosion, transform.position, Quaternion.identity);

		b2d.enabled = false;
		sr.enabled = false;
		scoreManager.SubLives();
		dying = true;
		dTimer = deathDuration;
	}

	void Die()
	{
		SceneManager.LoadScene(2);
	}
	void StartWinTimer()
	{
		wTimer = 4.0f;
	}
}
