using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowParty : DailyEvent {

    public ThrowParty(List<FamilyMember> list)
    {
        id = 0;
        rarity = 1;
        description = "Josh wants to invite a few \n friends tonight";
        moralVariation = 20f;
        energyVariation = -20f;
        moneyVariation = -50f;
        targets = list;
    }
        

}
