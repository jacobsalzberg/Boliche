﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest
{

    private List<int> pinFalls;
    private ActionMasterOld.Action endTurn = ActionMasterOld.Action.EndTurn;
    private ActionMasterOld.Action tidy = ActionMasterOld.Action.Tidy;
    private ActionMasterOld.Action reset = ActionMasterOld.Action.Reset;
    private ActionMasterOld.Action endGame = ActionMasterOld.Action.EndGame;

    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMasterOld.NextAction(pinFalls));
    }

    [Test]
    public void T04Bowl28SpareReturnsEndTurn()
    {
        int[] rolls = { 2, 8 };
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T05CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        Assert.AreEqual(reset, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T06CheckResetAtSpareInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };
        Assert.AreEqual(reset, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07YouTubeRollsEndInEndGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
        Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08GameEndsAtBowl20()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T09DarylBowl20Test()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 };
        Assert.AreEqual(tidy, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T10BensBowl20Test()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };
        Assert.AreEqual(tidy, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T11NathanBowlIndexTest()
    {
        int[] rolls = { 0, 10, 5, 1 };
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T12Dondi10thFrameTurkey()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
        Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T13ZeroOneGivesEndTurn()
    {
        int[] rolls = { 0, 1 };
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(rolls.ToList()));
    }
}