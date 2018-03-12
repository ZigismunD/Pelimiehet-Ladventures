using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// DialogueManager is used to control what dialogues happen at different stages of the game
/// </summary>
public class DialogueManager : MonoBehaviour {
    public GameObject dBox;
    public Text dText;

    public static bool dialogueActive;

    // Dialogues for different phases of the game
    public string[] dialogueLines;
    public string[] dialogueAfterFirstMeet;
    public string[] dialogueAfterHouse;
    public string[] unmetReqToBuildHouse;
    public string[] finalDialogue;

    public int currentLine;

    // Variables used to determine what has been done to invoke the right dialogue
    public static bool houseBuilt = false;
    public static bool firstMeeting = true;
    public bool finalLevelDone = false;
    public bool dialogueAfterHouseHad = false;
    public bool finalDialogueHad = false;
    public bool gameDone;

  
	// Use this for initialization
	void Start () {
       
		
	}

    // Check what the player has done already and set the dialogue accordingly
    void Update()
    {
        if (gameDone)
        {
            SceneManager.LoadScene("TheEnd");
        }

        if (finalLevelDone)
        {
            dialogueLines = finalDialogue;
            // Increases currentLine variable and prints the next line in the chat box
            if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
            {
                currentLine++;
            }

            //If the current line in chat box is the last line in the dialogue
            //this will trigger and hide the dialogue and its components
            if (currentLine >= dialogueLines.Length)
            {
                dBox.SetActive(false);
                dialogueActive = false;
                finalDialogueHad = true;
                gameDone = true;
                currentLine = 0;
            }

            // Fetches the desired line from the dialogue to be presented
            dText.text = dialogueLines[currentLine];

            // If player has already spoken to wizard but don't yet have the required materials to build the house
        }

        //Here is the first dialogue after the player wakes up in the shore and talks to the wizard.
        if (!houseBuilt && firstMeeting)
        {
            // Increases currentLine variable and prints the next line in the chat box
            if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
            {
                currentLine++;
            }

            //If the current line in chat box is the last line in the dialogue
            //this will trigger and hide the dialogue and its components
            if (currentLine >= dialogueLines.Length)
            {
                dBox.SetActive(false);
                dialogueActive = false;
                firstMeeting = false;
                currentLine = 0;
            }
             
            // Fetches the desired line from the dialogue to be presented
            dText.text = dialogueLines[currentLine];

            // If player has already spoken to wizard but don't yet have the required materials to build the house
        } else if (!houseBuilt && !firstMeeting  && !Inventory.houseCanBeBuilt)
        {
            // Sets the dialogue to be the one that tells player to find the materials to build the house
            dialogueLines = unmetReqToBuildHouse;
            // Increases currentLine variable and prints the next line in the chat box
            if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
            {
                currentLine++;
            }

            //If the current line in chat box is the last line in the dialogue
            //this will trigger and hide the dialogue and its components
            // Sets the currentLine back to 0 so that next dialogue will start from beginning
            if (currentLine >= dialogueLines.Length)
            {
                dBox.SetActive(false);
                dialogueActive = false;

                currentLine = 0;
            }

            // Fetches the desired line from the dialogue to be presented
            dText.text = dialogueLines[currentLine];

            // Will trigger if the player has gathered the materials and built the house
        }

        if (houseBuilt && !finalLevelDone)
        {
            dialogueLines = dialogueAfterHouse;
            if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
            {
                currentLine++;
            }

            if (currentLine >= dialogueLines.Length)
            {
                dBox.SetActive(false);
                dialogueActive = false;
                dialogueAfterHouseHad = true;
                currentLine = 0;
            }

            dText.text = dialogueLines[currentLine];
        }
    }
  
    //Method that is used to set dialogue to active
    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);

    }
}
