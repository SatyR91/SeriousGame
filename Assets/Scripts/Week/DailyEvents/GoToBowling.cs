using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBowling : DailyEvent {

    public GoToBowling(List<FamilyMember> list)
    {
        id = 1;
        rarity = 0;
        description = "Bitch is u drunk";
        moralVariation = 40f;
        energyVariation = 0;
        moneyVariation = -50f;
        targets = list;
    }
}
