using UnityEngine;
using UnityEngine.AI;
using System;
using UnityEngine.UI;

public class StatePattern : MonoBehaviour
{
    public Activity activityToMake;
    public Transform bed;
    public Transform outside;
    public Activity[] activities;
    public Activity[] mandActivities;
    public float[] prefKeys;
    public Activity refusedActivity;
    public int timesRefused;
    public float wanderOff;
    public float wanderTime;
    public float wanderTick;
    public Transform[] wanderpoints;
    public Transform clock;
    public int sleepTime;
    public int workTime;
    public Slider workSlider;
    public Slider moralSlider;
    public Slider socialSlider;


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

        prefKeys = new float[activities.Length];
        SortPreferences();
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
        if (time >= sleepTime && time <= sleepTime +1)
        {
            currentState = sleepState;
        }
        if (time >= workTime && time <= workTime +1)
        {
            currentState = outState;
        }
        foreach (Activity a in mandActivities)
        {
            if (time >= a.MandStartTime && time <= a.MandStartTime + 1)
            {
                Clear();
                activityToMake = a;
                currentState = useState;
            }
        }
    }

    public void ChangeActivity()
    {
        if (timesRefused < 2 && currentState == useState && !activityToMake.MandatoryActivity)
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

    public void SortPreferences()
    {
        for(int i = 0; i< activities.Length; i++)
        {
            Activity tmp = activities[i];
            prefKeys[i] = 10000/(tmp.moralValue * moralSlider.value + tmp.workValue * workSlider.value + tmp.socialValue * socialSlider.value);
        }
        Array.Sort(prefKeys, activities);
    }
}
