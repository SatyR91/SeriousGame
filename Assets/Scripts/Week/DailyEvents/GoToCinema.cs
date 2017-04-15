using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCinema : DailyEvent {

    public GoToCinema(List<FamilyMember> list)
    {
        id = 1;
        rarity = 0;
        description = "Lapin est ped";
        moralVariation = 20f;
        energyVariation = 0;
        moneyVariation = -10f;
        targets = list;
    }
}
