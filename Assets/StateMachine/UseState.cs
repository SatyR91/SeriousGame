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
        if (!fm.activityToMake.MandatoryActivity) {
            fm.ItsTime();
        }
        
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
            fm.activityToMake.device.setOn(true);
            arrived = true;
            fm.activityToMake.device.tmpConsumption = 0;
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
            //fm.activityToMake.device.timeOn += fm.activityToMake.timeOfExec;
            fm.Clear();
            fm.hasTalked = false;
            fm.ToWanderState();
        }
    }
}