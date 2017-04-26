using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenFriendBirthday : DailyEvent {

    public TeenFriendBirthday(List<FamilyMember> list)
    {
        id = 1;
        rarity = 1;
        description = "Josh is visiting a \n friend for his birthday";
        moralVariation = 10f;
        energyVariation = 0;
        moneyVariation = 0f;
        targets = list;
    }
}
