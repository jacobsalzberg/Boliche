using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float strandingTreshold = 3f; // remember: anything done in the inspector OVERWRITES


   
	// Use this for initialization
	void Start () {
		
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

        return true;
    }
}
