using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

    public enum Action
    {
        Tidy, Reset, EndTurn, EndGame //cappital as a convention
    }
    //private int[] bowls = new int[21]; //array starts at 0
    private int bowl = 1;

    public Action Bowl (int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid pins");
        }

        //other behavior herem e.g. last frame
        if (pins == 10) //strike
        {
            bowl += 2;
            return Action.EndTurn;
            
        }

        //If first bowl of frame 
        // return Action.Tidy;
        if (bowl % 2 != 0) // mid frame (or last frame)
        {
            bowl += 1;
            return Action.Tidy;
        }




        //other behavior here
        
        throw new UnityException("Not sure what action to return"); // throw -> exceptions
    }
}
