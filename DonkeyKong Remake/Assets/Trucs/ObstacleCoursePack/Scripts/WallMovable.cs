using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovable : MonoBehaviour
{
	public bool isDown = true; 
	public bool isRandom = true; 
	public float speed = 2f;

	private float height; 
	private float posYDown; 
	private bool isWaiting = false; 
	private bool canChange = true;

	void Awake()
    {
		height = transform.localScale.y;
		if(isDown)
			posYDown = transform.position.y;
		else
			posYDown = transform.position.y - height;
	}

    // Update is called once per frame
    void Update()
    {
		if (isDown)
		{
			if (transform.position.y < posYDown + height)
			{
				transform.position += Vector3.up * Time.deltaTime * speed;
			}
			else if (!isWaiting)
				StartCoroutine(WaitToChange(0.25f));
		}
		else
		{
			if (!canChange)
				return;

			if (transform.position.y > posYDown)
			{
				transform.position -= Vector3.up * Time.deltaTime * speed;
			}
			else if (!isWaiting)
				StartCoroutine(WaitToChange(0.25f));
		}
	}

	//Function that wait before go down or up
	IEnumerator WaitToChange(float time)
	{
		isWaiting = true;
		yield return new WaitForSeconds(time);
		isWaiting = false;
		isDown = !isDown;

		if (isRandom && !isDown) //If is wall up and is random
		{
			int num = Random.Range(0, 2);
			//Debug.Log(num);
			if (num == 1)
				StartCoroutine(Retry(1.5f));
		}
	}

	//Function that checks every 1.25secs if can go down the wall
	IEnumerator Retry(float time)
	{
		canChange = false;
		yield return new WaitForSeconds(time);
		int num = Random.Range(0, 2);
		//Debug.Log("2-"+num);
		if (num == 1)
			StartCoroutine(Retry(1.25f));
		else
			canChange = true;
	}
}
