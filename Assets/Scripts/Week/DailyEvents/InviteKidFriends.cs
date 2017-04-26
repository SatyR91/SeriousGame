using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviteSarah : DailyEvent {

    public InviteSarah(List<FamilyMember> list)
    {
        id = 0;
        rarity = 0;
        description = "Lili invited her friend Sarah";
        moralVariation = 5f;
        energyVariation = -10f;
        moneyVariation = 0f;
        targets = list;
    }
        

}
