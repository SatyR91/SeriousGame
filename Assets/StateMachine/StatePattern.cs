using UnityEngine;
using UnityEngine.AI;
using System;

public class StatePattern : MonoBehaviour
{
    public Activity activityToMake;
    public Transform bed;
    public Transform outside;
    public Activity[] preferences;
    public float[] prefKeys;
    public Activity refusedActivity;
    public int timesRefused;
    public float wanderOff;
    public float wanderTime;
    public float wanderTick;
    public Transform[] wanderpoints;
    public Transform clock;
    public float workImportance;
    public float moralImportance;
    public float socialImportance; 


    [HideInInspector]
    public float time;
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
        time = clock.GetComponent<DigitalGameTimeClock>().currentTime;

        prefKeys = new float[preferences.Length];
        UpdatePrefKeys();
        UpdatePreferences();
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
        if (time >= 150 && time <= 151)
        {
            currentState = sleepState;
        }
        if (time >= 50 && time <= 51)
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
            wanderTime = time;
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
        wanderTime = time;
        wanderTick = time;
    }

    public void Uptime()
    {
        time = clock.GetComponent<DigitalGameTimeClock>().currentTime;
    }

    public void UpdatePrefKeys()
    {
        for(int i = 0; i< preferences.Length; i++)
        {
            Activity tmp = preferences[i];
            prefKeys[i] = 10000/(tmp.moralValue * moralImportance + tmp.workValue * workImportance + tmp.socialValue * socialImportance);
        }
    }

    public void UpdatePreferences()
    {
        Array.Sort(prefKeys,preferences);
    }
}
