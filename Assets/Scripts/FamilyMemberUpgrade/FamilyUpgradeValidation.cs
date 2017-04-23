using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyUpgradeValidation : MonoBehaviour {

    public Data data;
    public GameObject Upgrades;
    public void OnClick()
    {
        foreach(Transform child in Upgrades.transform)
        {
            FamilyUpgradeButton currentUpgrade = child.gameObject.GetComponent<FamilyUpgradeButton>();
            if (currentUpgrade.isActive)
            {
                Debug.Log("The skill " + currentUpgrade.UpgradeName + " is upgraded !");
                data.SkillPoints--;
                switch(currentUpgrade.UpgradeName)
                {
                    case ("Light"):
                        data.LightBoostLevel++;
                        currentUpgrade.UpgradeLevel++;
                        currentUpgrade.CheckForUpgrade();
                        currentUpgrade.UpdateFromData();
                        break;
                    case ("Moral"):
                        data.LightBoostLevel++;
                        currentUpgrade.UpgradeLevel++;
                        currentUpgrade.CheckForUpgrade();
                        currentUpgrade.UpdateFromData();
                        break;
                    case ("Energy"):
                        data.LightBoostLevel++;
                        currentUpgrade.UpgradeLevel++;
                        currentUpgrade.CheckForUpgrade();
                        currentUpgrade.UpdateFromData();
                        break;
                    default:
                        Debug.Log("Erreur : Device non trouve.");
                        break;
                }
            }
        }
    }
}
