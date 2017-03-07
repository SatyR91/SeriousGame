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
    public GoUseState goUseState;
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
        goUseState = new GoUseState(this);
        useState = new UseState(this);
        wanderState = new WanderState(this);

        timesRefused = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void ChooseActivity()
    {
        int i = 0;
        activityToMake = null;
        while (i < preferences.Length && activityToMake == null)
        {
            if (!preferences[i].device.used && preferences[i] != refusedActivity)
            {
                activityToMake = preferences[i];
                activityToMake.device.used = true;
            }
            i += 1;
        }
    }

    // Use this for initialization
    void Start()
    {
        currentState = outState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }

    // Functions used in several States

    public void Clear()
    {
        timesRefused = 0;
        refusedActivity = null;
        activityToMake.device.used = false;
        activityToMake = null;
    }

    public void ItsTime()
    {
        if (Time.time >= 8000)
        {
            Clear();
            currentState = sleepState;
        }
        if (Time.time >= 16000)
        {
            Clear();
            currentState = outState;
        }
    }

    public void ChangeActivity()
    {
        if (timesRefused < 2 && (currentState == useState || currentState == goUseState))
        {
            refusedActivity = activityToMake;
            timesRefused += 1;
            activityToMake.device.used = false;
            activityToMake = null;
            currentState = wanderState;
        }
        else
        {
            Debug.Log("go fuck yourself");
        }
    }
}
