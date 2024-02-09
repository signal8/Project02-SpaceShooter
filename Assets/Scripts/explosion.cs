using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
	private int spriteFrame = 1;
	private SpriteRenderer sr;
	private float timer;
	private bool waiting = false;

	public float animationSpeed = 1;
	public Sprite[] sprites;
	public AudioSource boom;

    	void Awake()
    	{
		timer = animationSpeed;
        	sr = gameObject.GetComponent<SpriteRenderer>();
    	}

    	void Update()
    	{
        	if (timer >= 0) 
		{
			timer -= Time.deltaTime;
			return;
		}
		if (spriteFrame >= 3) 
		{
			sr.enabled = false;
			waiting = true;
		}
		if (waiting == false)
		{
			timer = animationSpeed;
			sr.sprite = sprites[spriteFrame];
			spriteFrame++;
		}
		else if (!boom.isPlaying)
		{
			Destroy(gameObject);
		}
    	}
}
