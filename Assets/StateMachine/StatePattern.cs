using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StatePattern : MonoBehaviour
{
    public Activity activityToMake;
    public Transform bed;
    public Transform outside;
    public Activity[] preferences;
    public Activity refusedActivity;
    public int timesRefused;
    public float wanderOff;
    public float wanderTime;
    public float wanderTick;
    public Transform[] wanderpoints;


    [HideInInspector]
    public float curTime;
    [HideInInspector]
    public IState currentState;
    [HideInInspector]
    public SleepState sleepState;
    [HideInInspector]
    public OutState outState;
    [HideInInspector]
    public UseState useState;
    [HideInInspector]
    public WanderState wanderState;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    private void Awake()
    {
        sleepState = new SleepState(this);
        outState = new OutState(this);
        useState = new UseState(this);
        wanderState = new WanderState(this);

        timesRefused = 1;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }



    // Use this for initialization
    void Start()
    {
        currentState = wanderState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }

    // Functions used in several States

    public void Clear()
    {
        timesRefused = 1;
        refusedActivity = null;
        if (activityToMake != null)
        {
            activityToMake.device.used = false;
            activityToMake.device.on = false;
        }
        activityToMake = null;
        useState.arrived = false;
    }

    public void ItsTime()
    {
        if (Time.time >= 30 && Time.time <= 31)
        {
            currentState = sleepState;
        }
        if (Time.time >= 10 && Time.time <= 11)
        {
            currentState = outState;
        }
    }

    public void ChangeActivity()
    {
        if (timesRefused < 2 && currentState == useState)
        {
            if (timesRefused == 1)
            {
                refusedActivity = activityToMake;
            }
            timesRefused += 1;
            activityToMake.device.used = false;
            activityToMake.device.on = false;
            activityToMake = null;
            useState.arrived = false;
            wanderTime = Time.time;
            currentState = wanderState;
        }
        else
        {
            Debug.Log("go fuck yourself");
        }
    }

    public void ToWanderState()
    {
        currentState = wanderState;
        wanderTime = Time.time;
        wanderTick = Time.time;
    }
}
