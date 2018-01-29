using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn; // feito pra mudar o nome
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy; // feito pra mudar o nome
    private ActionMaster actionMaster;

    [SetUp] //runs every time a test runs
    public void Setup ()
    {

        //create instante of ActionMaster
        ActionMaster actionMaster = new ActionMaster();
    }


    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn ()
    {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }
    
    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T04Bowl28SpareReturnsEndTurn()
    {
        Assert.AreEqual(tidy , actionMaster.Bowl(8));
        Assert.AreEqual(endTurn, actionMaster.Bowl(2));
    }
}
