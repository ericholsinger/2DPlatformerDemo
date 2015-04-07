#pragma strict

public var jumpHeight = 0;
public var moveSpeed = 0;
public var maxJumps = 0; // maximum number of jumps

private var numJumps = 0; // number of current jumps
private var facingRight = true; // initially sprite faces to the right

function Start () {

}

function Update () {
	var x;
	var y;
	
	if (Input.GetKeyDown(KeyCode.Space) && CanJump()) {
		x = GetComponent(Rigidbody2D).velocity.x;
		
		GetComponent(Rigidbody2D).velocity = new Vector2(x, jumpHeight);
		
		++numJumps;
	}
	
	if (Input.GetKey (KeyCode.LeftArrow)) {
		y = GetComponent(Rigidbody2D).velocity.y;
		
		GetComponent(Rigidbody2D).velocity = new Vector2(-moveSpeed, y);
		
		if (facingRight) {
			Flip();
		}
	}
	
	if (Input.GetKey (KeyCode.RightArrow)) {
		y = GetComponent(Rigidbody2D).velocity.y;
		
		GetComponent(Rigidbody2D).velocity = new Vector2(moveSpeed, y);
		
		if (!facingRight) {
			Flip();
		}
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

// flip sprite along x-axis
function Flip() {
	var flipScale : Vector3;
	var rigidbody : Rigidbody2D;
	
	rigidbody = GetComponent(Rigidbody2D);
	
	flipScale = rigidbody.transform.localScale;
	flipScale.x *= -1; // flip horizontally
	
	rigidbody.transform.localScale = flipScale;
	
	facingRight = !facingRight; // facing opposite direction
}