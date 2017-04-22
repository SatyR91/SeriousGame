using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyUpgradeButton : MonoBehaviour {

    public string UpgradeName;
    public int UpgradeLevel;
    public Text UpgradeLevelText;
    public Text UpgradeDescriptionText;
    public bool isActive;
    public Data data;
    public Button ValidationButton;
    public Text SkillPointText;

	// Use this for initialization
	void Start () {
	    switch(UpgradeName)
        {
            case ("Light"):
                UpgradeLevel = data.LightBoostLevel;
                break;
            case ("Moral"):
                UpgradeLevel = data.MoralBoostLevel;
                break;
            case ("Energy"):
                UpgradeLevel = data.ConsumptionBoostLevel;
                break;
            default:
                break;
        }
        UpdateFromData();	
	}
	
	public void OnClick()
    {
        foreach(Transform child in GameObject.Find("Upgrades").transform)
        {
            if(child.gameObject == this.gameObject)
            {
                child.gameObject.GetComponent<FamilyUpgradeButton>().isActive = true;
            }
            else
            {
                child.gameObject.GetComponent<FamilyUpgradeButton>().isActive = false;
            }
        }
        UpgradeDescriptionText.text = UpgradeName;
        CheckForUpgrade();
    }

    public void CheckForUpgrade()
    {
        if (data.SkillPoints <= 0 || UpgradeLevel >= 10)
        {
            ValidationButton.interactable = false;
        }
        else
        {
            ValidationButton.interactable = true;
        }
    }

    public void UpdateFromData()
    {
        UpgradeLevelText.text = "LVL : " + UpgradeLevel;
        SkillPointText.text = "Skill points available : " + data.SkillPoints.ToString();
    }
}
