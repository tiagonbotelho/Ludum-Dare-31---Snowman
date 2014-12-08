using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3,20);
	public float jumpspeed = 50f;
	public bool grounded = true;
	public bool subir = false;
	public float jumpnormal = 200;


	private Controller controller;
	private Animator animator;


	void Start(){
		controller = GetComponent<Controller> ();
		animator = GetComponent<Animator> ();
	}
	// Update is called once per frame

	void Update () {
		var forceX = 0f;
		var forceY = 0f;
		var absVelX = Mathf.Abs (rigidbody2D.velocity.x);
		var absVelY = Mathf.Abs (rigidbody2D.velocity.y);
		if (grounded && rigidbody2D.velocity.y < 0) {
			grounded = false;		
		}
		if (!grounded && absVelY == 0 && subir == false) {
			grounded = true;
		}
		if (absVelY == 0 && subir == true) {
			subir = false;
		}
		if (controller.moving.x != 0) {
			if (absVelX < maxVelocity.x) {
				forceX = controller.moving.x * speed;
			}
			transform.localScale = new Vector3 (controller.moving.x * Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);
			if(grounded)
				animator.SetInteger ("AnimState", 1);
		} else {
			animator.SetInteger("AnimState", 0);
		}
		if (controller.moving.y > 0) {
			if(grounded && !subir){
				forceY = jumpspeed*absVelX + jumpnormal;
				grounded = false;
				subir = true;
			}
		}
		rigidbody2D.AddForce (new Vector2 (forceX, forceY));
	}
}
