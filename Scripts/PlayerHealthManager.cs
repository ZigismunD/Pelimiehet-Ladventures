using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public float playerCurrentHealth;
	private const float coef = 1.0f;

    Scene scene;
    string sceneName;

    // Check for active scene
    // set current health to max health
    void Start () {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        playerCurrentHealth = playerMaxHealth;

	}

	// Check what scene is active
    // If scene is house_inside set current health to maximun health
	void Update () {

		if(playerCurrentHealth < 0)
		{
			gameObject.SetActive (false);
		}

        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        if (sceneName == "house_inside")
        {
            SetMaxHealth();
        }

        if (!DialogueManager.dialogueActive)
        {
            playerCurrentHealth -= coef * Time.deltaTime;
        }
        




	}

    // Hurt the player
	public void HurtPlayer(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;
	}

    // set current health to maximum
	public void SetMaxHealth()

	{
		playerCurrentHealth = playerMaxHealth;
	}

    // Increase the current health
    // if heal amount goes above max health, set current health to maximum health
    public void Heal(float amount)
    {
        if (playerCurrentHealth + amount > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        } else
        {
            playerCurrentHealth += amount;
        }
        
    }
}