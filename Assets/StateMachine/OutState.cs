using UnityEngine;
using UnityEngine.AI;

public class OutState : IState

{
    private readonly StatePattern fm;
    private bool arrived = false;
    private bool cleared = false;

    public OutState(StatePattern statePatternGuy)
    {
        fm = statePatternGuy;
    }

    public void UpdateState()
    {
        fm.Uptime();
        if (!cleared)
        {
            fm.Clear();
            cleared = true;
        }
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
            fm.curTime = fm.time;
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
        if (fm.time - fm.curTime >= 15)
        {
            arrived = false;
            cleared = false;
            fm.ToWanderState();
        }
    }
}