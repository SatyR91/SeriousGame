﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeValidation : MonoBehaviour {


    public Data data;
    public GameObject Necessities;
    public GameObject Entertainment;
    private void Start()
    {
        data = GameObject.Find("Data").GetComponent<Data>();
    }
    public void OnClick()
    {
        GetComponent<AudioSource>().Play();
        foreach (Transform child in Necessities.transform)
        {
            UpgradeButton currentdevice = child.gameObject.GetComponent<UpgradeButton>();
            if (currentdevice.isActive)
            {
                switch(currentdevice.DeviceName)
                {
                    case ("Dishwasher"):
                        data.Money -= currentdevice.UpgradeCost[currentdevice.DeviceLevel];
                        data.DishwasherLevel++;
                        currentdevice.DeviceLevel++;
                        currentdevice.CheckForUpgrade();
                        currentdevice.UpdateFromData();
                        break;
                    case ("Stove"):
                        data.Money -= currentdevice.UpgradeCost[currentdevice.DeviceLevel];
                        data.StoveLevel++;
                        currentdevice.DeviceLevel++;
                        currentdevice.CheckForUpgrade();
                        currentdevice.UpdateFromData();
                        break;
                    case ("Refrigerator"):
                        data.Money -= currentdevice.UpgradeCost[currentdevice.DeviceLevel];
                        data.RefrigeratorLevel++;
                        currentdevice.DeviceLevel++;
                        currentdevice.CheckForUpgrade();
                        currentdevice.UpdateFromData();
                        break;
                    case ("Washing Machine"):
                        data.Money -= currentdevice.UpgradeCost[currentdevice.DeviceLevel];
                        data.WashingMachineLevel++;
                        currentdevice.DeviceLevel++;
                        currentdevice.CheckForUpgrade();
                        currentdevice.UpdateFromData();
                        break;
                    case ("Vacuum Cleaner"):
                        data.Money -= currentdevice.UpgradeCost[currentdevice.DeviceLevel];
                        data.VacuumCleanerLevel++;
                        currentdevice.DeviceLevel++;
                        currentdevice.CheckForUpgrade();
                        currentdevice.UpdateFromData();
                        break;
                    default:
                        Debug.Log("Erreur : Device non trouve");
                        break;
                }
            }
        }
        foreach(Transform child in Entertainment.transform)
        {
            UpgradeButton currentdevice = child.gameObject.GetComponent<UpgradeButton>();
            if(currentdevice.isActive)
            {
                switch(currentdevice.DeviceName)
                {
                    case ("Casual Computer"):
                        data.Money -= currentdevice.UpgradeCost[currentdevice.DeviceLevel];
                        data.CasualComputerLevel++;
                        currentdevice.DeviceLevel++;
                        currentdevice.CheckForUpgrade();
                        currentdevice.UpdateFromData();
                        break;
                    case ("Gaming Computer"):
                        data.Money -= currentdevice.UpgradeCost[currentdevice.DeviceLevel];
                        data.GamingComputerLevel++;
                        currentdevice.DeviceLevel++;
                        currentdevice.CheckForUpgrade();
                        currentdevice.UpdateFromData();
                        break;
                    case ("Television"):
                        data.Money -= currentdevice.UpgradeCost[currentdevice.DeviceLevel];
                        data.TelevisionLevel++;
                        currentdevice.DeviceLevel++;
                        currentdevice.CheckForUpgrade();
                        currentdevice.UpdateFromData();
                        break;
                    default:
                        Debug.Log("Erreur : Device non trouve");
                        break;
                }
            }
        }
    }


}
