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
            case ("Refrigerator"):
                DeviceLevel = data.RefrigeratorLevel;
                break;
            case ("Washing Machine"):
                DeviceLevel = data.WashingMachineLevel;
                break;
            case ("Vacuum cleaner"):
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
        switch(DeviceName)
        {
            case ("Dishwasher"):
                DeviceDescriptionText.text = "Dishwashers nowadays are pretty energy-efficient. However, most dishwashers cosume the same amount of electrical energy, regardless of the load size of the dishwasher. \nBuying a bigger dishwasher will allow the family to save more energy each time they are doing the dishes." +
                    "\n\nPower required : between 700 and 3600 Watts";
                break;
            case ("Stove"):
                DeviceDescriptionText.text = "Electrical stoves are cheaper than gas stoves, but they will cost more to operate in the long run (assuming gas prices don't vary that much). \nBuying a new stove with a smaller Energystar rating will allow the family to decrease their overall energy consumption." +
                    "\n\nPower required : between 750 and 1500 Watts";
                break;
            case ("Refrigerator"):
                DeviceDescriptionText.text = "Since it has to always use power to keep food fresh, a refregirator might be one of the best devices to save energy on. \nBuying a fridge with a smaller energy rating might lead to tremendous energy savings." +
                    "\n\nPower required : between 100 and 500 Watts";
                break;
            case ("Washing Machine"):
                DeviceDescriptionText.text = "The newer your washing machine is, the more energy-efficient it will be. \nUpgrading this will change the family's washing machine for a recent model of front-load machine, then for a brand-new top-load machine, which use less electricity." +
                    "\n\nPower required : between 500 and 3000 Watts";
                break;
            case ("Vacuum Cleaner"):
                DeviceDescriptionText.text = "Interestingly enough, it is possible to be fined for an outdated vacuum-cleaner that is not power-efficient. Buying a new vacuum cleaner will help reduce energy expenditure. Moreover, it will quiet the house a bit, since most new vacuum cleaners are energy-efficient as well as quiet." +
                    "\n\nPower required : between 700 and 2000 Watts";
                break;
            case ("Casual Computer"):
                DeviceDescriptionText.text = "This computer is tailored for casual use, like social media checking or light media work. Changing some components like the processor will allow for a better user experience, at the cost of energy expenditure." +
                    "\n\nPower required : between 80 and 360 Watts";
                break;
            case ("Gaming Computer"):
                DeviceDescriptionText.text = "Although manufacturers are working as hard as they can to produce more energy-efficient equipment, most gaming computers still represent a big spending energy-wise. \nUpgrading the gaming computer will make it more of an energy-guzzler, but will tremendosuly increase its entertainment potential." +
                    "\n\nPower required : between 80 and 700 Watts";
                break;
            case ("Television"):
                DeviceDescriptionText.text = "Improvments in screen technologies, like the coming of the LCD, made television a cleanier entertainment device. Upgrading it will make it use more electricity, but will also increase visual comfort and entertainment for the family." +
                    "\n\nPower required : between 20 and 380 Watts";
                break;
            default:
                break;
        }
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
