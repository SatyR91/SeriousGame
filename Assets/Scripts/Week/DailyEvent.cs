using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DailyEvent  { 

    public int id;
    public int rarity;
    public string description;
    public float moralVariation;
    public float energyVariation;
    public float moneyVariation;
    public List<FamilyMember> targets;

}
