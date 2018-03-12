using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBuilder : MonoBehaviour {
    private DialogueManager dialogueManager;
    public string[] unsuccesful;
   

	// Use this for initialization
	void Start () {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // This method will check if the player is standing near to the house base
    // Also checks for the variable in Inventory object to see if the house can be built
    // If house can be built and space bar is pressed, the house will appear
    // If there are not enough materias in Inventory, a prompt to seek them appears
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (Inventory.houseCanBeBuilt)
                {
                    BuildHouse();
                }
                else
                {
                    if (!DialogueManager.dialogueActive)
                    {
                        dialogueManager.dialogueLines = unsuccesful;
                        dialogueManager.currentLine = 0;
                        dialogueManager.ShowDialogue();
                    }
                }

            }
        }
    }

    // This method is responsible to change the variables that make the house appear
    // HouseBuilt variable is for the DialogueManager so that the materials seeking message won't appear anymore
    public static void BuildHouse()
    {
        HouseContoller.visible = true;
        DialogueManager.houseBuilt = true;
    }
}
