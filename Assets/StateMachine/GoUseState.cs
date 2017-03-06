using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class GoUseState : IState

{
    private readonly StatePattern guy;

    public GoUseState(StatePattern statePatternGuy)
    {
        guy = statePatternGuy;
    }

    public void UpdateState()
    {
        GoUse();
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
    { }

    public void ToUseState()
    {
        guy.currentState = guy.useState;
    }

    public void GoUse()
    {
        guy.GetComponent<NavMeshAgent>().destination = guy.deviceToUse.position;
        guy.GetComponent<NavMeshAgent>().Resume();
        if (Vector3.Distance(guy.deviceToUse.position, guy.transform.position) < 1)
        {
            guy.GetComponent<NavMeshAgent>().Stop();
            guy.curTime = Time.time;
            ToUseState();
        }
    }
}