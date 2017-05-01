﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecapManager : MonoBehaviour {

    public Text LightConsumptionNumberText;
    public Text DishwasherConsumptionNumberText;
    public Text StoveConsumptionNumberText;
    public Text RefrigeratorConsumptionNumberText;
    public Text WashingMachineConsumptionNumberText;
    public Text VacuumCleanerConsumptionNumberText;
    public Text CasualComputerConsumptionNumberText;
    public Text GamingComputerConsumptionNumberText;
    public Text TelevisionConsumptionNumberText;
    public Text MiscellanelousConsumptionNumberText;
    public Text ExpectedConsumptionNumberText;
    public Text EnergySavedNumberText;
    public Text TotalConsumptionNumberText;
    public Text PreviousBalanceText;
    public Text IncomesText;
    public Text EnergyBillText;
    public Text TotalSavingsText;
    public Text WeekText;
    public int Income;
    public int WattHourUnitPrice;

    public Data data;

	// Use this for initialization
	void Start () {
        data = GameObject.Find("Data").GetComponent<Data>();
        LightConsumptionNumberText.text = ((11 - data.LightBoostLevel)).ToString() + " kWh";
        DishwasherConsumptionNumberText.text = (data.DishwasherConsumption).ToString() + " kWh";
        StoveConsumptionNumberText.text = (data.StoveConsumption * 10.5f).ToString() + " kWh";
        RefrigeratorConsumptionNumberText.text = (( 3 - data.RefrigeratorLevel) * 10.5f).ToString() + " kWh";
        WashingMachineConsumptionNumberText.text = (data.WashingMachineConsumption).ToString() + " kWh";
        VacuumCleanerConsumptionNumberText.text = ((3 - data.VacuumCleanerLevel) * 5.25f).ToString() + " kWh";
        CasualComputerConsumptionNumberText.text = (data.CasualComputerConsumption * 10.5f).ToString() + " kWh";
        GamingComputerConsumptionNumberText.text = (data.GamingComputerConsumption * 10.5f).ToString() + " kWh";
        TelevisionConsumptionNumberText.text = (data.TelevisionConsumption * 10.5f).ToString() + " kWh";
        MiscellanelousConsumptionNumberText.text = data.MiscellanelousConsumption.ToString() + " kWh";

        PreviousBalanceText.text = "$ " + data.Money.ToString();
        IncomesText.text = "$ " + Income.ToString();


        WeekText.text = "Week " + data.CurrentWeek.ToString();
        

        float expectedConsumption = ((11 - data.LightBoostLevel) + (data.DishwasherConsumption/10.5f) + data.StoveConsumption +
            (3 -data.RefrigeratorLevel) + (data.WashingMachineConsumption / 10.5f) + (3 - data.VacuumCleanerLevel) / 2 +
            data.CasualComputerConsumption + data.GamingComputerConsumption + data.TelevisionConsumption +
            data.MiscellanelousConsumption/10.5f) * 10.5f;
        ExpectedConsumptionNumberText.text = expectedConsumption.ToString() + " kWh";
        float energySaved = expectedConsumption * ((float)data.ConsumptionBoostLevel * 0.02f);
        EnergySavedNumberText.text = energySaved.ToString() + " kWh";
        TotalConsumptionNumberText.text = (expectedConsumption - energySaved).ToString() + " kWh";

        EnergyBillText.text = "$ " + ((expectedConsumption - energySaved) * WattHourUnitPrice).ToString();
        TotalSavingsText.text = "$ " + ((data.Money - ((expectedConsumption - energySaved) * WattHourUnitPrice)) + Income).ToString();
        data.Money = (int)Mathf.Round(data.Money - ((expectedConsumption - energySaved) * WattHourUnitPrice)) + Income;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
