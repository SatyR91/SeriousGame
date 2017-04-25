using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCinema : DailyEvent {

    public GoToCinema(List<FamilyMember> list)
    {
        id = 1;
        rarity = 0;
        description = "The parents went to the cinema";
        moralVariation = 15f;
        energyVariation = 0;
        moneyVariation = -30f;
        targets = list;
    }
}
