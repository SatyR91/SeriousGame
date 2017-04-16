using UnityEngine;
using UnityEngine.AI;

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
        fm.Uptime();
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
        if (Vector3.Distance(fm.activityToMake.device.transform.position, fm.transform.position) < 2 )
        {
            fm.GetComponent<NavMeshAgent>().Stop();
            fm.curTime = fm.time;
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
        if (fm.time >= fm.curTime + fm.activityToMake.timeOfExec)
        {
            //fm.Uptime();
            //fm.curTime = fm.time;
            fm.Clear();
            fm.ToWanderState();
        }
    }
}