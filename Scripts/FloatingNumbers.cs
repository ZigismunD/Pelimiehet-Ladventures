using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour {

	public float moveSpeed;
	public int damageNumber;
	public Text displayNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Display text and move it upwards
	void Update () {

		displayNumber.text = "Press space to interact!";
		transform.position = new Vector3 (transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
			
		
	}
}
