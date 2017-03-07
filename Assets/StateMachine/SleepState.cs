using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class SleepState : IState

{
    private readonly StatePattern guy;
    private bool arrived = false;

    public SleepState(StatePattern statePatternGuy)
    {
        guy = statePatternGuy;
    }

    public void UpdateState()
    {
        if (arrived)
        {
            Sleep();
        }
        else
        {
            GoSleep();
        }
    }

    //Change state functions

    public void ToGoUseState()
    { }

    public void ToUseState()
    { }

    public void ToWanderState()
    {
        guy.currentState = guy.wanderState;
    }

    //State - Functions

    public void GoSleep()
    {
        guy.GetComponent<NavMeshAgent>().destination = guy.bed.position;
        guy.GetComponent<NavMeshAgent>().Resume();
        if (Vector3.Distance(guy.bed.position, guy.transform.position) < 1)
        {
            guy.GetComponent<NavMeshAgent>().Stop();
            guy.curTime = Time.time;
            arrived = true;
        }
    }

    public void Sleep()
    {
        if (Time.time - guy.curTime >= 2)
        {
            arrived = false;
            ToWanderState();
        }
    }
}