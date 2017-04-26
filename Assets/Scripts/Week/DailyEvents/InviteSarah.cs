using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviteKidFriends : DailyEvent {

    public InviteKidFriends(List<FamilyMember> list)
    {
        id = 0;
        rarity = 0;
        description = "Lili invited her friends today";
        moralVariation = 10f;
        energyVariation = -15f;
        moneyVariation = -5f;
        targets = list;
    }
        

}
