using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class OutState : IState

{
    private readonly StatePattern guy;

    public OutState(StatePattern statePatternGuy)
    {
        guy = statePatternGuy;
    }

    public void UpdateState()
    {
        Out();
    }

    public void ToGoSleepState()
    { }

    public void ToSleepState()
    { }

    public void ToGoOutState()
    { }

    public void ToOutState()
    { }

    public void ToGoUseState()
    {
        guy.currentState = guy.goUseState;
    }

    public void ToUseState()
    { }

    public void Out()
    {
        if (Time.time - guy.curTime >= 2)
        {
            ToGoUseState();
        }
    }
}