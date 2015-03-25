#pragma strict

public var jumpHeight = 0;
public var maxJumps = 0; // maximum number of jumps

private var numJumps = 0; // number of current jumps

function Start () {

}

function Update () {
	if (Input.GetKeyDown(KeyCode.Space) && CanJump()) {
		GetComponent(Rigidbody2D).velocity = new Vector2(0, jumpHeight);
		
		++numJumps;
	}
}

function OnCollisionEnter2D (coll : Collision2D) {
	if (coll.gameObject.CompareTag("Ground")) {
		numJumps = 0;
	}
}

function CanJump() {
	return numJumps < maxJumps;
}