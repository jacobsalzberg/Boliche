using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

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


}
