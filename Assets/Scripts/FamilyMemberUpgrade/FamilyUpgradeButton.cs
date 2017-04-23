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
    public GameObject Upgrades;
	// Use this for initialization
	void Start () {
        data = GameObject.Find("Data").GetComponent<Data>();
        switch (UpgradeName)
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
        foreach(Transform child in Upgrades.transform)
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
        switch(UpgradeName)
        {
            case ("Light"):
                UpgradeDescriptionText.text = "The easiest way to spend less on electricity is to be cautious : turning the lights off when you go out of a room can decrease your energy expenditure drastically. \nInvesting points in this upgrade will reduce the chance that family members forget to turn off the light when going out of a room.";
                break;
            case ("Moral"):
                UpgradeDescriptionText.text = "Most of the time, people don't use their entertainment devices to their full extent. By educating the family about all the possibility of their devices, it will become easier for them to have fun with them. \nInvesting points in this upgrade will cause family members to gain more moral when using entertainment devices.";
                break;
            case ("Energy"):
                UpgradeDescriptionText.text = "Being mindful of small things, like truly turning off each device after use, or unplugging them after we finished working with them, can help save a bit of energy. \nInvesting points in this upgrade will cause home appliances to be used in a more responsible manner, thus using less energy.";
                break;
            default:
                break;
        }
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
