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
        guy.ItsTime();
        GoUse();
    }

    //Change state functions

    public void ToGoUseState()
    { }

    public void ToUseState()
    {
        guy.currentState = guy.useState;
    }

    public void ToWanderState()
    { }

    //State - Functions

    public void GoUse()
    {
        guy.GetComponent<NavMeshAgent>().destination = guy.activityToMake.device.transform.position;
        guy.GetComponent<NavMeshAgent>().Resume();
        if (Vector3.Distance(guy.activityToMake.device.transform.position, guy.transform.position) < 1)
        {
            guy.activityToMake.device.used = true;
            guy.GetComponent<NavMeshAgent>().Stop();
            guy.curTime = Time.time;
            ToUseState();
        }
    }
}