using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	public static bool mcExists;

	public AudioSource[] musicTracks;

	public int currentTrack;

	public bool musicCanPlay;

	// Initializes the music controller
	void Start () {
		if (!mcExists) {
			mcExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
    // Starts the track if nothing is playing
    // and stops the current one if something is playing
	void Update () {
		if (musicCanPlay) {
				if(!musicTracks[currentTrack].isPlaying){
					musicTracks[currentTrack].Play();
				}
		} else {
			musicTracks [currentTrack].Stop ();
		}

	}

    // Switches music track to the next
	public void SwitchTrack(int newTrack) {
		musicTracks [currentTrack].Stop ();
		currentTrack = newTrack;
		musicTracks[currentTrack].Play();
		
	}


}
