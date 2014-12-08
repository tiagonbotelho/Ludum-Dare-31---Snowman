using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	public int maxCarrotNumber = 5;
	//public Key key;
	public GameObject key;


	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "Player") {
			if(Cena.CarrotsCollected >= maxCarrotNumber){
				animator.SetInteger("AnimState", 1);
				Cena.CarrotsCollected = 0;
				Instantiate (key, transform.position, Quaternion.identity);
			}
		}
	}
}
