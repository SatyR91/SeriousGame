using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripToDisneyLand : DailyEvent {

    public TripToDisneyLand(List<FamilyMember> list)
    {
        id = 0;
        rarity = 2;
        description = "All the family goes to Disneyland !";
        moralVariation = 30f;
        energyVariation = 10f;
        moneyVariation = -150f;
        targets = list;
    }
        

}
