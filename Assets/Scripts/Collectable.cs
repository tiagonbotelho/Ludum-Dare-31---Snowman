﻿using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target) {

		if (target.gameObject.tag == "Player") {
			if(gameObject.tag == "Carrot")
				Cena.CarrotsCollected++;
			else if(gameObject.tag == "Coin")
				Cena.CoinsCollected++;
			Destroy (gameObject);
		}
	}
}