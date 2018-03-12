using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {
    public string dialogue;
    private DialogueManager dMan;

    public string[] dialogueLines;

	// Get the reference to Dialogue Manager
	void Start () {
        dMan = FindObjectOfType<DialogueManager>();
	}

    // Used to check if the player is near the wizard and starts the dialogue when space is pressed
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (!DialogueManager.dialogueActive)
                {
                    dMan.dialogueLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }
            }
        }
    }
}
