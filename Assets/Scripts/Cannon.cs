using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	public float attackDelay = 3f;
	public Projectile projectile;

	Animator animator;

	// Use this for initialization
	void Start () {
		if (attackDelay > 0)
			StartCoroutine (OnAttack());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnAttack(){
		yield return new WaitForSeconds(attackDelay);
		OnShoot ();
		StartCoroutine (OnAttack());
	}

	void OnShoot(){
		if (projectile) {
			Projectile clone = Instantiate (projectile, transform.position, Quaternion.identity) as Projectile;		
		}
	}
}
