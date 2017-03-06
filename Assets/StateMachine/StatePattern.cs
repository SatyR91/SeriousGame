using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StatePattern: MonoBehaviour
{
    public Transform deviceToUse;
    public Transform bed;
    public Transform outside;

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
