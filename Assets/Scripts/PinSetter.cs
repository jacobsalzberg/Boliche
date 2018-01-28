using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {


    public int lastStandingCount = -1;
    public Text standingDisplay;
    public float distanceToRaise = 40f;
    public GameObject pinSet;

    private Ball ball;

    private float lastChangeTime;
    private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}

	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();

        //if ball has entered box
        if (ballEnteredBox)
        {
            CheckStanding();
        }
    }

    public void RaisePins()
    {
        //raise standing pins only by 
        Debug.Log("Raising pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }

    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Debug.Log("Renewing pins");
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position += new Vector3(0, 20, 0);
    }

    void CheckStanding()
    {
        //Update the last standing count
        //call pinshavesettled 
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; //how long to wait to consider pins settled
        if ((Time.time - lastChangeTime) > settleTime) //if last change >3s ago
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        ball.Reset();
        lastStandingCount = -1; //indicades pins have settled, and ball not back in box
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }


    int CountStanding()
    {
        int standing = 0; // good practice to initialize at zero

        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }

    private void OnTriggerExit(Collider collider)
    {
        // GameObject thingLeft = collider.gameObject;
        //if (thingLeft.GetComponentInParent<Pin>()) //do this because the collider is in the parent
        // {
        //     print (thingLeft + "pin left");
        //     Destroy(thingLeft.transform.parent.gameObject);
        //  }
        Pin pin = collider.GetComponentInParent<Pin>();
        if (pin)
        {
            Destroy(pin.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject thingHit = collider.gameObject; //assign gameobject to a variable called thinghit

        //Ball enters play box
        if (thingHit.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }

    }
}
