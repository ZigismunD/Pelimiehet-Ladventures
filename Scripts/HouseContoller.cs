using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseContoller : MonoBehaviour {
    public static bool visible = false;
    private GameObject house;
	// Use this for initialization
	void Start () {
        house = GameObject.Find("House");
	}
	
	// This method only checks if the house has been built in the HouseBuilder.
    // Will set it active
	void Update () {
        house.SetActive(visible);
	}
}
