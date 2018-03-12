using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        // Meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        // If the player has clicked the interactabe object with right mouse button and hasn't yet interacted with that object
        if (isFocus && !hasInteracted)
        {
            // Observes the distance between the player and the interactable object
            // If distance becomes small enough player will interact with it
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    // Player clicks on the object with right mouse button to set it on focus
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    // Clicking left mouse button will clear the focus
    // Will set all variables back to their original state
    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
	
}
