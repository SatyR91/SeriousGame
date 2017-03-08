using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class UseState : IState

{
    private readonly StatePattern fm;
    public bool arrived = false;

    public UseState(StatePattern statePatternGuy)
    {
        fm = statePatternGuy;
    }

    public void UpdateState()
    {
        fm.ItsTime();
        if (arrived)
        {
            Use();
        }
        else
        {
            GoUse();
        }
    }

    //State - Functions

    public void GoUse()
    {
        if (Vector3.Distance(fm.activityToMake.device.transform.position, fm.transform.position) < 0.5 )
        {
            fm.GetComponent<NavMeshAgent>().Stop();
            fm.curTime = Time.time;
            fm.activityToMake.device.on = true;
            arrived = true;
        }
        else
        {
            fm.GetComponent<NavMeshAgent>().destination = fm.activityToMake.device.transform.position;
            fm.GetComponent<NavMeshAgent>().Resume();
        }
    }

    public void Use()
    {
        if (Time.time >= fm.curTime + fm.activityToMake.timeOfExec)
        {
            fm.Clear();
            fm.ToWanderState();
        }
    }
}