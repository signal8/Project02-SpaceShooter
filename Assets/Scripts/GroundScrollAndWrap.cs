using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScrollAndWrap : MonoBehaviour
{
	private Vector3 pos;

	public float scrollSpeed = 2.0f;
	public float wrapPoint = -12.0f;

    	// Update is called once per frame
    	void Update()
    	{
		pos = transform.position;
        	pos += Vector3.left * 
			(scrollSpeed * Time.deltaTime);

		if (pos.x <= wrapPoint)
			pos += new Vector3(-pos.x * 2, 0, 0);

		transform.position = pos;
    	}
}
