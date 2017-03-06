using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public FamilyMember fm1;
    public FamilyMember fm2;
    public FamilyMember fm3;
    public FamilyMember fm4;

    public float energy;
    public float energyMax = 100;
    public float money;
    public float moneyMax = 100;

    public float moralLossPerTick = 0.005f;
    public float EnergyConsumption;

    public float energyAwareness;
    // Use this for initialization
    void Start () {
        energy = energyMax;
        money = moneyMax;
        EnergyLoss(20);
	}
	
	// Update is called once per frame
	void Update () {
        MoralLossTick(moralLossPerTick);
	}

    /// <summary>
    /// Moral loss per tick for each member of the family
    /// </summary>
    public void MoralLossTick(float value)
    {
        fm1.moralLoss(value);
        fm2.moralLoss(value);
        fm3.moralLoss(value);
        fm4.moralLoss(value);
    }

    public void EnergyLoss(float value)
    {
        if (energy - value >= 0)
        {
            energy -= value;
        }
        else
        {
            // the end
        }
    }

    public void EnergyGain(float value)
    {
        if (energy + value >= energyMax)
        {
            energy = energyMax;
        }
        else
        {
            energy += value;
        }
    }

    public void MoneyGain(float value)
    {
        if (money + value >= moneyMax)
        {
            money = moneyMax;
        }
        else
        {
            money += value;
        }
    }

    public void MoneyLoss(float value)
    {
        if (money - value >= 0)
        {
            money -= value;
        }
        else
        {
            // the end
        }
    }
}
