using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviteFriends : DailyEvent {

    public InviteFriends(List<FamilyMember> list)
    {
        id = 0;
        rarity = 1;
        description = "Some family friends are\n coming tonight";
        moralVariation = 10f;
        energyVariation = -10f;
        moneyVariation = -30f;
        targets = list;
    }
        

}
