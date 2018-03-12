using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*This object is used when loadin from scene to scene*/

public class LoadNewArea : MonoBehaviour {
    public string levelToLoad; // Level that is to be entered
    public string exitPoint;
    private PlayerController thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // When player collides into the object, this method is called
    // And the desired level is loaded
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            thePlayer.startPoint = exitPoint;
        }
    }
}
