﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D myRigidbody;

	private bool moving;

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;

	private Vector3 moveDirection;


	// Set the movement parameters to the animal
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

		timeBetweenMoveCounter = timeBetweenMove;
		timeToMoveCounter = timeToMove;
		
	}
	
	// Move the enemies
	void Update () {

		if (moving) {
			
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;

			if (timeToMoveCounter < 0f)
			{
				moving = false;
				timeBetweenMoveCounter = timeBetweenMove;
			}
		
			} else {
			timeBetweenMoveCounter -= Time.deltaTime;
				myRigidbody.velocity = Vector2.zero;
			
				if (timeBetweenMoveCounter < 0f)
			{
				moving = true;
			timeToMoveCounter = timeToMove;

					moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f), 0f);
				

		}
		
	}
	}
						}
						
