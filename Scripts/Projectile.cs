using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public int damage;

	
	// Update is called once per frame
	void Update () {
	
	}


    // If the projectile hits player, deal damage and destroy projectile object
    // If projectile hits stones, destroy projectile
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            FindObjectOfType<PlayerHealthManager>().HurtPlayer(damage);
            Destroy(gameObject);
        } else if (other.name == "Stones")
        {
            Destroy(gameObject);
        }
    }

}
