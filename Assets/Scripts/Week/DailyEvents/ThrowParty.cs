using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowParty : DailyEvent {

    public ThrowParty(List<FamilyMember> list)
    {
        id = 0;
        rarity = 1;
        description = "Les bonnes seufs de la maman\n de Ruf";
        moralVariation = 20f;
        energyVariation = -10f;
        moneyVariation = -20f;
        targets = list;
    }
        

}
