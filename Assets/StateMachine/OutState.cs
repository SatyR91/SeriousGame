using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class OutState : IState

{
    private readonly StatePattern fm;
    private bool arrived = false;

    public OutState(StatePattern statePatternGuy)
    {
        fm = statePatternGuy;
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

    //State - Functions

    public void GoOut()
    {
        if (Vector3.Distance(fm.outside.position, fm.transform.position) < 1)
        {
            fm.GetComponent<NavMeshAgent>().Stop();
            fm.curTime = Time.time;
            arrived = true;
        }
        else
        {
            fm.GetComponent<NavMeshAgent>().destination = fm.outside.position;
            fm.GetComponent<NavMeshAgent>().Resume();
        }
    }

    public void Out()
    {
        if (Time.time - fm.curTime >= 2)
        {
            arrived = false;
            fm.ToWanderState();
        }
    }
}