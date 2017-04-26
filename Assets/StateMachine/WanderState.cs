using UnityEngine;
using UnityEngine.AI;

public class WanderState : IState

{
    private readonly StatePattern fm;
    private float waitTime;
    private int nextWanderPoint;
    public bool arrived = false;
    private float chatTick;
    public StatePattern guy1;
    public StatePattern guy2;
    public StatePattern guy3;

    public WanderState(StatePattern statePatternGuy)
    {
        fm = statePatternGuy;
        guy1 = statePatternGuy.otherGuy1.GetComponent<StatePattern>();
        guy2 = statePatternGuy.otherGuy2.GetComponent<StatePattern>();
        guy3 = statePatternGuy.otherGuy3.GetComponent<StatePattern>();
    }

    public void UpdateState()
    {
        fm.Uptime();
        fm.ItsTime();
        TimeToDo();
        if (!fm.hasTalked && (fm.time - chatTick >= 10))
        {
            chatTick = fm.time;
            if (Random.Range(1,100) <= fm.socialImportance)
            {
                Chat();
            }
        }
        if (arrived)
        {
            if (fm.GetComponent<Animator>().GetBool("isWalking"))
            {
                fm.GetComponent<Animator>().SetBool("isWalking", false);
            }
            PassiveWander();
        }
        else
        {
            if (fm.GetComponent<Animator>().GetBool("isWalking"))
            {
                fm.GetComponent<Animator>().SetBool("isWalking", true);
            }
            ActiveWander();
        }
    }

    //Change state functions

    public void ToUseState()
    {
        fm.currentState = fm.useState;
    }

    //State - Functions

    public void Chat()
    {
        if (guy1.currentState == guy1.wanderState && !guy1.hasTalked)
        {
            fm.currentState = fm.chatState;
            fm.guyToTalkTo = fm.otherGuy1;
            arrived = false;
            fm.GetComponent<Animator>().SetBool("isWalking", true);
            fm.chatState.arrived = false;
            fm.hasTalked = true;
            guy1.currentState = guy1.chatState;
            guy1.guyToTalkTo = fm.gameObject;
            guy1.wanderState.arrived = false;
            guy1.GetComponent<Animator>().SetBool("isWalking", true);
            guy1.chatState.arrived = false;
            guy1.hasTalked = true;

        }
        else
        {
            if (guy2.currentState == guy2.wanderState && !guy2.hasTalked)
            {
                fm.currentState = fm.chatState;
                fm.guyToTalkTo = fm.otherGuy2;
                arrived = false;
                fm.GetComponent<Animator>().SetBool("isWalking", true);
                fm.chatState.arrived = false;
                fm.hasTalked = true;
                guy2.currentState = guy2.chatState;
                guy2.guyToTalkTo = fm.gameObject;
                guy2.wanderState.arrived = false;
                guy2.GetComponent<Animator>().SetBool("isWalking", true);
                guy2.chatState.arrived = false;
                guy2.hasTalked = true;

            }
            else
            {
                if (guy3.currentState == guy3.wanderState && !guy3.hasTalked)
                {
                    fm.currentState = fm.chatState;
                    fm.guyToTalkTo = fm.otherGuy3;
                    arrived = false;
                    fm.GetComponent<Animator>().SetBool("isWalking", true);
                    fm.chatState.arrived = false;
                    fm.hasTalked = true;
                    guy3.currentState = guy3.chatState;
                    guy3.guyToTalkTo = fm.gameObject;
                    guy3.wanderState.arrived = false;
                    guy3.GetComponent<Animator>().SetBool("isWalking", true);
                    guy3.chatState.arrived = false;
                    guy3.hasTalked = true;

                }
            }
        }
    }


    public void ChooseActivity()
    {
        int i = 0;
        fm.activityToMake = null;
        while (i < fm.activities.Length && fm.activityToMake == null)
        {
            if (!fm.activities[i].device.used && fm.activities[i] != fm.refusedActivity)
            {
                fm.activityToMake = fm.activities[i];
                fm.activityToMake.device.used = true;
            }
            i += 1;
        }
        if (fm.activityToMake == null) {
            fm.activityToMake = fm.boringActivity;
        }
    }

    public void TimeToDo()
    {
        if (fm.time - fm.wanderTime >= 30)
        {
            //Debug.Log(fm.GetComponent<Animator>().GetBool("isWalking"));
            ChooseActivity();
            fm.GetComponent<Animator>().SetBool("isWalking", true);
            //Debug.Log(fm.gameObject.name);
            ToUseState();
        }
        else
        {
            if (fm.time - fm.wanderTick >= 5)
            {
                if (Random.value <= fm.wanderOff)
                {
                    //Debug.Log(fm.GetComponent<Animator>().GetBool("isWalking"));
                    ChooseActivity();
                    fm.GetComponent<Animator>().SetBool("isWalking", true);
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