using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public DoorTrigger[] doorTriggers;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "Player")
			animator.SetInteger ("AnimState", 1);

		foreach (DoorTrigger trigger in doorTriggers) {
			if(trigger != null)
				trigger.Toggle(true);
		}
	}

	void OnTriggerExit2D(Collider2D target){
		if(target.gameObject.tag == "Player")
			animator.SetInteger ("AnimState", 0);
		
		foreach (DoorTrigger trigger in doorTriggers) {
			if(trigger != null)
				trigger.Toggle(false);
		}
	}

}
