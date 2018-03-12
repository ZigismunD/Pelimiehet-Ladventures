using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Class used to control the buttons in the main menu
/// </summary>
public class ButtonController : MonoBehaviour {
    private Button buttonStart;
    private Button buttonExit;

	/// <summary>
    /// Create the buttons and add listeners to them
    /// </summary>
	void Start () {
        buttonStart = GameObject.Find("ButtonStart").GetComponent<Button>();
        buttonStart.onClick.AddListener(() => StartGame());

        buttonExit = GameObject.Find("ButtonExit").GetComponent<Button>();
        buttonExit.onClick.AddListener(() => ExitGame());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Start the game and load into the jungle scene
    private void StartGame()
        
    {
        SceneManager.LoadScene("main");
    }

    //Exit game
    private void ExitGame()
    {
        Application.Quit();
    }
}
