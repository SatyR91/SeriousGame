using UnityEngine;
using UnityEngine.AI;

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
        fm.Uptime();
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
            fm.curTime = fm.time;
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
        if (fm.time - fm.curTime >= 15)
        {
            arrived = false;
            cleared = false;
            fm.ToWanderState();
        }
    }
}