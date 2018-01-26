using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Ball ball;

    private Vector3 offset; //between the ball and the camera, find at start and maintain it


	// Use this for initialization
	void Start () {
        //capture once in the start
        offset = transform.position - ball.transform.position;
	}

    // Update is called once per frame
    void Update() {
        if (transform.position.z <= 1829f) // in front of headpin
        {
            transform.position = ball.transform.position + offset;
        }
	}
}
