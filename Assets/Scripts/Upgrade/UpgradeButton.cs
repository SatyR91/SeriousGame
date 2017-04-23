using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {

    public string DeviceName;
    public int DeviceLevel;
    public Text DeviceLevelText;
    public Text DeviceNameText;
    public Text DeviceDescriptionText;
    public Text UpgradeCostText;
    public bool isActive;
    public int[] UpgradeCost;
    public Data data;
    public Button ValidationButton;
    public Text MoneyText;
    public GameObject Necessities;
    public GameObject Entertainment;
    public void Start()
    {
        data = GameObject.Find("Data").GetComponent<Data>();
        switch (DeviceName)
        {
            case ("Dishwasher"):
                DeviceLevel = data.DishwasherLevel;
                break;
            case ("Stove"):
                DeviceLevel = data.StoveLevel;
                break;
            case ("Microwave"):
                DeviceLevel = data.MicrowaveLevel;
                break;
            case ("Refrigerator"):
                DeviceLevel = data.RefrigeratorLevel;
                break;
            case ("Washing Machine"):
                DeviceLevel = data.WashingMachineLevel;
                break;
            case ("Drying Machine"):
                DeviceLevel = data.DryingMachineLevel;
                break;
            case ("Casual Computer"):
                DeviceLevel = data.CasualComputerLevel;
                break;
            case ("Gaming Computer"):
                DeviceLevel = data.GamingComputerLevel;
                break;
            case ("Television"):
                DeviceLevel = data.TelevisionLevel;
                break;
            default:
                break;
        }
        UpdateFromData();
    }
    
	public void OnClick()
    {
        foreach(Transform child in Necessities.transform)
        {
            if(child.gameObject == this.gameObject)
            {
                child.gameObject.GetComponent<UpgradeButton>().isActive = true;
            }
            else
            {
                child.gameObject.GetComponent<UpgradeButton>().isActive = false;
            }
        }
        foreach (Transform child in Entertainment.transform)
        {
            if (child.gameObject == this.gameObject)
            {
                child.gameObject.GetComponent<UpgradeButton>().isActive = true;
            }
            else
            {
                child.gameObject.GetComponent<UpgradeButton>().isActive = false;
            }
        }
        DeviceNameText.text = DeviceName;
        DeviceDescriptionText.text = "This device is named : " + DeviceName + " and it's the best at what it does";
        UpgradeCostText.text = "Cost for upgrade : " + UpgradeCost[DeviceLevel];
        CheckForUpgrade();
    }

    public void CheckForUpgrade()
    {
        if (UpgradeCost[DeviceLevel] > data.Money || DeviceLevel >= 2)
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
        DeviceLevelText.text = "LVL " + DeviceLevel;
        MoneyText.text = data.Money.ToString();
    }
}
