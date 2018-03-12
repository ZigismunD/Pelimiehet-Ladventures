using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;

	// Set health to animal
	void Start () {
		CurrentHealth = MaxHealth;
		
	}
	
	// Update the enemy's health
	void Update () {
		if(CurrentHealth <= 0)
		{
			Destroy (gameObject);
		
	}
}

    // Take away health from enemy
	public void HurtEnemy(int damageToGive)
	{
		CurrentHealth -= damageToGive;
	}

    // set current health to full health
	public void SetMaxHealth()
	{
		CurrentHealth = MaxHealth;
	}
}
