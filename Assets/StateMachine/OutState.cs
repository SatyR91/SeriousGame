using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class OutState : IState

{
    private readonly StatePattern guy;
    private bool arrived = false;

    public OutState(StatePattern statePatternGuy)
    {
        guy = statePatternGuy;
    }

    public void UpdateState()
    {
        if (arrived)
        {
            Out();
        }
        else
        {
            GoOut();
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

    public void GoOut()
    {
        guy.GetComponent<NavMeshAgent>().destination = guy.outside.position;
        guy.GetComponent<NavMeshAgent>().Resume();
        if (Vector3.Distance(guy.outside.position, guy.transform.position) < 1)
        {
            guy.GetComponent<NavMeshAgent>().Stop();
            guy.curTime = Time.time;
            arrived = true;
        }
    }

    public void Out()
    {
        if (Time.time - guy.curTime >= 2)
        {
            arrived = false;
            ToWanderState();
        }
    }
}