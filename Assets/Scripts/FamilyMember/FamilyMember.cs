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
}
