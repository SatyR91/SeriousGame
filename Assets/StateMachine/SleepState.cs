using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class SleepState : IState

{
    private readonly StatePattern fm;
    private bool arrived = false;
    private bool cleared = false;

    public SleepState(StatePattern statePatternGuy)
    {
        fm = statePatternGuy;
    }

    public void UpdateState()
    {
        if(!cleared)
        {
            fm.Clear();
            cleared = true;
        }
        if (arrived)
        {
            Sleep();
        }
        else
        {
            GoSleep();
        }
    }

    //State - Functions

    public void GoSleep()
    {
        if (Vector3.Distance(fm.bed.position, fm.transform.position) < 1)
        {
            fm.GetComponent<NavMeshAgent>().Stop();
            fm.curTime = Time.time;
            arrived = true;
        }
        else
        {
            fm.GetComponent<NavMeshAgent>().destination = fm.bed.position;
            fm.GetComponent<NavMeshAgent>().Resume();
        }
    }

    public void Sleep()
    {
        if (Time.time - fm.curTime >= 2)
        {
            arrived = false;
            cleared = false;
            fm.ToWanderState();
        }
    }
}