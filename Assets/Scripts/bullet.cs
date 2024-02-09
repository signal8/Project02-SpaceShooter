using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	public float destroyPoint = 9.1f;
	public GameObject explosion;

	void Update()
	{
		if (transform.position.x > destroyPoint)
			Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player")) return;
		
		Instantiate(explosion, transform.position, 
				Quaternion.identity);
		col.gameObject.SendMessage("Hit");
		Destroy(gameObject);
	}
}
