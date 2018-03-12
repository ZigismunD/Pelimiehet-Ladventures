using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Controls where the player spawns after loading into a scene*/

public class PlayerStartPoint : MonoBehaviour {
    private PlayerController thePlayer;
    private CameraController theCamera;
    public string pointName;

	// There is only one camera that will not be destroyed between scenes
    // This will spawn the player in the correct spot and move the camera to the player
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();

        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;

            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
        
	}

}
