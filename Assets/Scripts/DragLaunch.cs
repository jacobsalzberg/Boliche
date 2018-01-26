using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]

public class DragLaunch : MonoBehaviour
{

    private Ball ball;
    // Use this for initialization
    void Start()
    {
        ball = GetComponent<Ball>();

    }

    public void DragStart()
    {
        //capture time & position of drag start
    }
    public void DragEnd()
    {
        //launch the ball
    }

}
