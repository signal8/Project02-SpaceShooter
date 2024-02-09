using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starScroll : MonoBehaviour
{
	public int starSize = 0;
	public float bigStarSpeed = 5.0f;
	public float medStarSpeed = 2.5f;
	public float smlStarSpeed = 1.25f;
	public float wrapPoint = -9.1f;

    	// Start is called before the first frame update
    	void Start()
    	{
        	
    	}

    	// Update is called once per frame
    	void Update()
    	{
        	switch (starSize)
		{
			case 1:
				transform.position += Vector3.left *
					smlStarSpeed * Time.deltaTime;
				if (transform.position.x <= wrapPoint)
					transform.position += new Vector3
					(transform.position.x * -2, 0, 0);
				break;
			case 2: 
				transform.position += Vector3.left *
					medStarSpeed * Time.deltaTime;
				if (transform.position.x <= wrapPoint)
					transform.position += new Vector3
					(transform.position.x * -2, 0, 0);
				break;
			case 3:
				transform.position += Vector3.left *
					bigStarSpeed * Time.deltaTime;
				if (transform.position.x <= wrapPoint)
					transform.position += new Vector3
					(transform.position.x * -2, 0, 0);
				break;
		}
    	}
}
