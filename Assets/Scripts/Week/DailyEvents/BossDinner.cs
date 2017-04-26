using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDinner : DailyEvent {

    public BossDinner(List<FamilyMember> list)
    {
        id = 0;
        rarity = 1;
        description = "Dave's boss is coming home\n tonight for dinner";
        moralVariation = -20f;
        energyVariation = 0f;
        moneyVariation = 100f;
        targets = list;
    }
        

}
