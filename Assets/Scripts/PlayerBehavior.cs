using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

	public int jumpHeight;
	public int moveSpeed;
	public int maxJumps; // maximum number of jumps
	
	private int numJumps; // number of jumps

	private bool facingRight; // is our character facing right?

	// Use this for initialization
	void Start () {
		numJumps = 0;
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && CanJump ())
		{
			float x = GetComponent<Rigidbody2D>().velocity.x;

			GetComponent<Rigidbody2D>().velocity = new Vector2(x, jumpHeight);

			++numJumps;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			float y = GetComponent<Rigidbody2D>().velocity.y;

			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, y);

			// if facing to the right, flip to face left
			if (facingRight) {
				Flip ();
			}
		}

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			float y = GetComponent<Rigidbody2D>().velocity.y;
			
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, y);

			// if not facing to the right, flip to face right
			if (!facingRight) {
				Flip ();
			}
		}
	}

	void OnCollisionEnter2D (Collision2D coll) 
	{
		if (coll.gameObject.CompareTag("Ground")) 
		{
			numJumps = 0;
		}
	}

	bool CanJump()
	{
		return numJumps < maxJumps;
	}

	// flips the sprite to face the opposite direction on the x-axis
	void Flip()
	{
		Vector3 flipScale; 

		Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

		flipScale = rigidBody.transform.localScale; // current scale vector
		flipScale.x *= -1; // flip horizontally, along x-axis

		rigidBody.transform.localScale = flipScale;

		facingRight = !facingRight; // facing opposite direction, now
	}
}
