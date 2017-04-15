using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripToDisneyLand : DailyEvent {

    public TripToDisneyLand(List<FamilyMember> list)
    {
        id = 0;
        rarity = 2;
        description = "All the family suck";
        moralVariation = 70f;
        energyVariation = 0f;
        moneyVariation = -300f;
        targets = list;
    }
        

}
