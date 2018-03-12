using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnter : MonoBehaviour {
    public GameObject bossEnter;
    public GameObject wizardOut;
    // Use this for initialization
    void Start () {
        bossEnter = GameObject.FindGameObjectWithTag("BossEntry");
	}
	
	// Control the visibiliy of the entry to boss level in the jungle
	void Update () {

        if (GameObject.FindObjectOfType<DialogueManager>().finalLevelDone || !GameObject.FindObjectOfType<DialogueManager>().dialogueAfterHouseHad)
        {
            bossEnter.SetActive(false);
        }
        else
        {
            bossEnter.SetActive(true);
        }
    }
}
