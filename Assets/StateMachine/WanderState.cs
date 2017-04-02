using UnityEngine;
using UnityEngine.AI;

public class WanderState : IState

{
    private readonly StatePattern fm;
    private float waitTime;
    private int nextWanderPoint;
    public bool arrived = false;

    public WanderState(StatePattern statePatternGuy)
    {
        fm = statePatternGuy;
    }

    public void UpdateState()
    {
        fm.Uptime();
        fm.ItsTime();
        TimeToDo();
        if (arrived)
        {
            PassiveWander();
        }
        else
        {
            ActiveWander();
        }
    }

    //Change state functions

    public void ToUseState()
    {
        fm.currentState = fm.useState;
    }

    //State - Functions

    public void ChooseActivity()
    {
        int i = 0;
        fm.activityToMake = null;
        while (i < fm.preferences.Length && fm.activityToMake == null)
        {
            if (!fm.preferences[i].device.used && fm.preferences[i] != fm.refusedActivity)
            {
                fm.activityToMake = fm.preferences[i];
                fm.activityToMake.device.used = true;
            }
            i += 1;
        }
    }

    public void TimeToDo()
    {
        if (fm.time - fm.wanderTime >= 30)
        {
            ChooseActivity();
            ToUseState();
        }
        else
        {
            if (fm.time - fm.wanderTick >= 5)
            {
                if (Random.value <= fm.wanderOff)
                {
                    ChooseActivity();
                    ToUseState();
                }
                fm.wanderTick = fm.time;
            }
        }
    }

    public void ActiveWander()
    {
        fm.GetComponent<NavMeshAgent>().destination = fm.wanderpoints[nextWanderPoint].position;
        fm.GetComponent<NavMeshAgent>().Resume();
        if (Vector3.Distance(fm.wanderpoints[nextWanderPoint].position, fm.transform.position) < 1)
        {
            waitTime = Random.Range(1, 5);
            arrived = true;
            fm.curTime = fm.time;
        }
    }

    public void PassiveWander()
    {
        if (fm.time >= fm.curTime + waitTime)
        {
            nextWanderPoint =  (int) Random.Range(0, (fm.wanderpoints.Length-0.001f));
            arrived = false;
        }
    }
}