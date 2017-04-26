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
    public Data data;

	// Use this for initialization
	void Start () {
        data = GameObject.Find("Data").GetComponent<Data>();
        LightConsumptionNumberText.text = data.LightConsumption.ToString() + " W";
        DishwasherConsumptionNumberText.text = data.DishwasherConsumption.ToString() + " W";
        StoveConsumptionNumberText.text = data.StoveConsumption.ToString() + " W";
        RefrigeratorConsumptionNumberText.text = data.RefrigeratorConsumption.ToString() + " W";
        WashingMachineConsumptionNumberText.text = data.WashingMachineConsumption.ToString() + " W";
        VacuumCleanerConsumptionNumberText.text = data.VacuumCleanerConsumption.ToString() + " W";
        CasualComputerConsumptionNumberText.text = data.CasualComputerConsumption.ToString() + " W";
        GamingComputerConsumptionNumberText.text = data.GamingComputerConsumption.ToString() + " W";
        TelevisionConsumptionNumberText.text = data.TelevisionConsumption.ToString() + " W";
        MiscellanelousConsumptionNumberText.text = data.MiscellanelousConsumption.ToString() + " W";

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
