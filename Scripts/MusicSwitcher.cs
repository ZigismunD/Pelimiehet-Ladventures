using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{

	private MusicController theMC;

	public int newTrack;

	public bool switchOnStart;

    // Initialize the music switcher
    void Start()
    {
        theMC = FindObjectOfType<MusicController>();

        if (switchOnStart)
        {
            theMC.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }

    }

}
