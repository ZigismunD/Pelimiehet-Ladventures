using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*This object controls the movement of the player*/

public class PlayerController : MonoBehaviour {
   
	public float moveSpeed; // Players movement speed
	private Animator anim; // Walk animations
	private Rigidbody2D myRigidbody;

    Scene scene;
    string sceneName;


	private bool playerMoving;
	private Vector2 lastMove;

    public string startPoint;
    

	private static bool playerExists;
    Camera cam;
    public Interactable focus;
    

	// Get references for the objects
    // Keep it so camera and player objects are not destroyed 
    // when loading into a different scene
	void Start () {
        cam = Camera.main;
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        
		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
        
        if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
        
        // If the player dies, exit the game
        if (FindObjectOfType<PlayerHealthManager>().playerCurrentHealth <= 0)
        {
            Application.Quit();
        }

        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        playerMoving = false;


        // if left mouse button is pressed the players focus is cleared
        if (Input.GetMouseButtonDown(0))
        {
            if (focus != null)
            {
                RemoveFocus();
            }
            
        }

        // if right mouse button is pressed and it hits and interactable object
        // it is set to players focus
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

        // if the currently active scene is any of the topdown scenes this if statement will be active
        if (sceneName == "main" || sceneName == "house_inside" || sceneName == "finalBattle")
        {
            myRigidbody.gravityScale = 0; // sets the gravity to 0

            // This controls the horizontal movement of the player
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            // This controls the vertical movement of the player
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }
        } 
		
        // Export the values of the variables to animator
        // Will control which way the player is facing and triggers the walking animations
		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX",lastMove.x);
		anim.SetFloat ("LastMoveY",lastMove.y);
		}

    // Set a focus for the player
    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            // If there already is a focus, remove that focus first
            if (focus != null)
                focus.OnDeFocused();

            focus = newFocus;
        }
        
        newFocus.OnFocused(transform);
    }

    // Remove the focus from the player
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDeFocused();

        focus.OnDeFocused();
        focus = null;
    }
}
