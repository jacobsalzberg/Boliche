﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;

    private Rigidbody rigidBody;
    private AudioSource audioSource;


	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        
        //Launch(launchVelocity);

    }

    public void Launch(Vector3 velocity)
    {
        rigidBody.useGravity = true;
        audioSource = GetComponent<AudioSource>();
        rigidBody.velocity = launchVelocity;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
