using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float strandingTreshold = 5f; // remember: anything done in the inspector OVERWRITES
    public float distToRaise = 40f;

    private Rigidbody rigidBody;

   
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public bool IsStanding() {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(rotationInEuler.x);
        float tiltInY = Mathf.Abs(rotationInEuler.z);

        if (tiltInX <strandingTreshold && tiltInY<strandingTreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RaiseIfStanding()
    {
        if (IsStanding())
        {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, distToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    } 
    public void Lower()
    {
        transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);
        rigidBody.useGravity = true;
    }
}

