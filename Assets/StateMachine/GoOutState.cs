using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class GoOutState : IState

{
    private readonly StatePattern guy;

    public GoOutState(StatePattern statePatternGuy)
    {
        guy = statePatternGuy;
    }

    public void UpdateState()
    {
        GoOut();
    }

    public void ToGoSleepState()
    { }

    public void ToSleepState()
    { }

    public void ToGoOutState()
    { }

    public void ToOutState()
    {
        guy.currentState = guy.outState;
    }

    public void ToGoUseState()
    { }

    public void ToUseState()
    { }

    public void GoOut()
    {
        guy.GetComponent<NavMeshAgent>().destination = guy.outside.position;
        guy.GetComponent<NavMeshAgent>().Resume();
        if (Vector3.Distance(guy.outside.position, guy.transform.position) < 1)
        {
            guy.GetComponent<NavMeshAgent>().Stop();
            guy.curTime = Time.time;
            ToOutState();
        }
    }
}