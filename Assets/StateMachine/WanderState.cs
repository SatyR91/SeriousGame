using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class WanderState : IState

{
    private readonly StatePattern guy;

    public WanderState(StatePattern statePatternGuy)
    {
        guy = statePatternGuy;
    }

    public void UpdateState()
    {
        guy.ItsTime();
        Wander();
    }

    //Change state functions

    public void ToGoUseState()
    {
        guy.currentState = guy.goUseState;
    }

    public void ToUseState()
    { }

    public void ToWanderState()
    { }

    //State - Functions

    public void Wander()
    {

    }
}