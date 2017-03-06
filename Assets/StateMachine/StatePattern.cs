using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StatePattern: MonoBehaviour
{
    public Transform activityToMake;
    public Transform bed;
    public Transform outside;
    public Activity[] preferences;
    public Activity refusedActivity;
    public int timesRefused;

    [HideInInspector]
    public float curTime;
    [HideInInspector]
    public IState currentState;
    [HideInInspector]
    public GoSleepState goSleepState;
    [HideInInspector]
    public SleepState sleepState;
    [HideInInspector]
    public GoOutState goOutState;
    [HideInInspector]
    public OutState outState;
    [HideInInspector]
    public GoUseState goUseState;
    [HideInInspector]
    public UseState useState;

    public NavMeshAgent navMeshAgent;

    private void Awake()
    {
        goSleepState = new GoSleepState(this);
        sleepState = new SleepState(this);
        goOutState = new GoOutState(this);
        outState = new OutState(this);
        goUseState = new GoUseState(this);
        useState = new UseState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void ChooseActivity()
    {
        int i = 0;
        activityToMake = null;
        while (i < preferences.Length && activityToMake == null)
        {
            if (!preferences[i].used && preferences[i] != refusedActivity)
            {
                activityToMake = preferences[i].transform ;
            }
            i += 1;
        }
    }

    // Use this for initialization
    void Start()
    {
        currentState = goOutState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }
}
