using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyMember : MonoBehaviour {

    public string surname;
    public float moral;
    public float social;
    public float socialValue;
    public float workValue;
    public Mesh mesh;
    public List<float> envies;

    private GameController gC;

    void Start()
    {
        gC = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private float tmpTime;

    public void moralLoss (float value)
    {
        if (System.Math.Abs(moral) + System.Math.Abs(value) >= 100)
        { }
        moral -= value;
    }

    public void moralGain(float value)
    {
        if (System.Math.Abs(moral) + System.Math.Abs(value) >= 100)
        { }
        else
        {
            moral += value;
        }       
    }

    public void workGain(float value)
    {
        if (System.Math.Abs(moral) + System.Math.Abs(value) >= 100)
        { }
        else
        {
            workValue += value;
        }
    }

    public void socialGain(float value)
    {
        if (System.Math.Abs(moral) + System.Math.Abs(value) >= 100)
        { }
        else
        {
            socialValue += value;
        }
    }

    public void Update()
    {
        StatePattern sp = GetComponentInParent<StatePattern>();

        if (sp.activityToMake != null)
        {
            Device device = sp.activityToMake.device;
            if (device.on) {
                if (sp.time - tmpTime >= 1)
                {
                    moralGain(sp.activityToMake.moralValue*gC.moralBoost / sp.activityToMake.timeOfExec);
                    socialGain(sp.activityToMake.socialValue / sp.activityToMake.timeOfExec);
                    workGain(sp.activityToMake.workValue / sp.activityToMake.timeOfExec);
                    tmpTime = sp.time;
                }
            }
        }
        else if (sp.currentState == sp.chatState)
        {
            if (sp.time - tmpTime >= 1)
            {
                socialGain(3f);
                tmpTime = sp.time;
            }
        }
    }
}
