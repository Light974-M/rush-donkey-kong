using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public Transform view;
	public Vector2 speed = new Vector2(50, 50);

	public bool right = true;
	public bool left = true;

	private Vector2 movement;

	void Update()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);


		
		if (left == true)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				view.transform.Rotate(0.0f, 180f, 0.0f);


				right = true;
				left = false;
			}
		}
		else if (left == false) ;

		if (right == true)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				view.transform.Rotate(0.0f, -180f, 0.0f);


				left = true;
				right = false;
			}
		}
		else if (right == false) ;


	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}