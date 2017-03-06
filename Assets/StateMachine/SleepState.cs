using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class SleepState : IState

{
    private readonly StatePattern guy;

    public SleepState(StatePattern statePatternGuy)
    {
        guy = statePatternGuy;
    }

    public void UpdateState()
    {
        Sleep();
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

    public void Sleep()
    {
        if (Time.time - guy.curTime >= 2)
        {
            ToGoUseState();
        }
    }
}