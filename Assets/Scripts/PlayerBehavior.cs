using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

	public int jumpHeight;
	public int maxJumps; // maximum number of jumps
	
	private int numJumps; // number of jumps

	// Use this for initialization
	void Start () {
		numJumps = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && CanJump ())
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);

			++numJumps;
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
}
