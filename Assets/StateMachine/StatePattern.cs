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
    public Activity boringActivity;
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
    public int workImportance;
    public int moralImportance;
    public int socialImportance;
    public GameObject otherGuy1;
    public GameObject otherGuy2;
    public GameObject otherGuy3;
    public float chatTime;

    public GameObject guyToTalkTo;
    public bool hasTalked;
    [HideInInspector]
    public float time;
    
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
    public ChatState chatState;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    private void Awake()
    {
        sleepState = new SleepState(this);
        outState = new OutState(this);
        useState = new UseState(this);
        wanderState = new WanderState(this);
        chatState = new ChatState(this);

        timesRefused = 1;
        navMeshAgent = GetComponent<NavMeshAgent>();
        time = clock.GetComponent<DigitalGameTimeClock>().currentTime;

        prefKeys = new float[activities.Length];
        
    }



    // Use this for initialization
    void Start()
    {
        currentState = wanderState;
        hasTalked = false;
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
            activityToMake.device.setOn(false);
        }
        activityToMake = null;
        useState.arrived = false;
    }

    public void ItsTime()
    {
        if (time >= sleepTime && time <= sleepTime +1)
        {
            /*if (currentState == useState && activityToMake.device.on)
            {
                activityToMake.device.timeOn += (time - curTime);
            }*/
            currentState = sleepState;
        }
        if (time >= workTime && time <= workTime +1)
        {
            /*if (currentState == useState && activityToMake.device.on)
            {
                activityToMake.device.timeOn += (time - curTime);
            }*/
            currentState = outState;
        }
        foreach (Activity a in mandActivities)
        {
            if (time >= a.MandStartTime && time <= a.MandStartTime + 1)
            {
               /* if (currentState == useState && activityToMake.device.on)
                {
                    activityToMake.device.timeOn += (time - curTime);
                }*/
                Clear();

                activityToMake = a;
                currentState = useState;
            }
        }
    }



    public void ChangeActivity()
    {
        if (timesRefused < 2 && currentState == useState && !activityToMake.MandatoryActivity && activityToMake!=boringActivity)
        {
            if (timesRefused == 1)
            {
                refusedActivity = activityToMake;
            }

            timesRefused += 1;
            
            activityToMake.device.used = false;
            if (activityToMake.device.on)
            {
                activityToMake.device.setOn(false);
                //activityToMake.device.timeOn += (time - curTime);
            }
            
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
            prefKeys[i] = 10000/(tmp.moralValue * moralImportance + tmp.workValue * workImportance + tmp.socialValue * socialImportance);
        }
        Array.Sort(prefKeys, activities);
    }
}
