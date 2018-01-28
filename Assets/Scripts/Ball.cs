using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


    private Vector3 ballStartPos;
    private Rigidbody rigidBody;
    private AudioSource audioSource;
    public bool inPlay = false;
    


	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;

        ballStartPos = transform.position;

        //Launch(launchVelocity);

    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
       

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    public void Reset()
    {
        Debug.Log("resetting ball");
        inPlay = false;
        transform.position = ballStartPos;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;

    }
    // Update is called once per frame
    void Update () {
		
	}
}
