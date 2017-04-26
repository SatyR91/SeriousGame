using System.Collections;
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
        LightConsumptionNumberText.text = (data.LightConsumption * 10.5f).ToString() + " W";
        DishwasherConsumptionNumberText.text = (data.DishwasherConsumption * 10.5f).ToString() + " W";
        StoveConsumptionNumberText.text = (data.StoveConsumption * 10.5f).ToString() + " W";
        RefrigeratorConsumptionNumberText.text = (data.RefrigeratorConsumption * 10.5f).ToString() + " W";
        WashingMachineConsumptionNumberText.text = (data.WashingMachineConsumption * 10.5f).ToString() + " W";
        VacuumCleanerConsumptionNumberText.text = (data.VacuumCleanerConsumption * 10.5f).ToString() + " W";
        CasualComputerConsumptionNumberText.text = (data.CasualComputerConsumption * 10.5f).ToString() + " W";
        GamingComputerConsumptionNumberText.text = (data.GamingComputerConsumption * 10.5f).ToString() + " W";
        TelevisionConsumptionNumberText.text = (data.TelevisionConsumption * 10.5f).ToString() + " W";
        MiscellanelousConsumptionNumberText.text = data.MiscellanelousConsumption.ToString() + " W";

        PreviousBalanceText.text = "$ " + data.Money.ToString();
        IncomesText.text = "$ " + Income.ToString();
        //EnergyBillText.text = "$ " + TODO;
        //TotalSavingsText.text = "$ " + TODO;


        WeekText.text = "Week " + data.CurrentWeek.ToString();
        

        float expectedConsumption = data.LightConsumption + data.DishwasherConsumption + data.StoveConsumption +
            data.RefrigeratorConsumption + data.WashingMachineConsumption + data.VacuumCleanerConsumption +
            data.CasualComputerConsumption + data.GamingComputerConsumption + data.TelevisionConsumption +
            data.MiscellanelousConsumption;
        ExpectedConsumptionNumberText.text = expectedConsumption.ToString() + " W";
        float energySaved = expectedConsumption * ((float)data.ConsumptionBoostLevel * 0.02f);
        EnergySavedNumberText.text = energySaved.ToString() + " W";
        TotalConsumptionNumberText.text = (expectedConsumption - energySaved).ToString() + " W";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
