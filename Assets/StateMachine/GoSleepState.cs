using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class GoSleepState : IState

{
    private readonly StatePattern guy;

    public GoSleepState(StatePattern statePatternGuy)
    {
        guy = statePatternGuy;
    }

    public void UpdateState()
    {
        GoSleep();
    }

    public void ToGoSleepState()
    { }

    public void ToSleepState()
    {
        guy.currentState = guy.sleepState;
    }

    public void ToGoOutState()
    { }

    public void ToOutState()
    { }

    public void ToGoUseState()
    { }

    public void ToUseState()
    { }

    public void GoSleep()
    {
        guy.GetComponent<NavMeshAgent>().destination = guy.bed.position;
        guy.GetComponent<NavMeshAgent>().Resume();
        if (Vector3.Distance(guy.bed.position, guy.transform.position) < 1)
        {
            guy.GetComponent<NavMeshAgent>().Stop();
            guy.curTime = Time.time;
            ToSleepState();
        }
    }
}