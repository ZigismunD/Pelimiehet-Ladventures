using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	public int damageToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// If the enemy collides with player, hurt the player
	void Update () {
		
	}
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.name == "Player") {
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive);
		}
	}
}
