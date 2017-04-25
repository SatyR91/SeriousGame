using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecapManager : MonoBehaviour {

    public Text LightConsumptionNumberText;
    public Text NecessitiesConsumptionNumberText;
    public Text EntertainmentConsumptionNumberText;
    public Text ExpectedConsumption;
    public Text EnergySavedText;
    public Text TotalConsumptionNumberText;
    public Data data;

	// Use this for initialization
	void Start () {
        data = GameObject.Find("Data").GetComponent<Data>();
        LightConsumptionNumberText.text = data.LightConsumption.ToString() + " W";
        NecessitiesConsumptionNumberText.text = data.NecessitiesConsumption.ToString() + " W";
        EntertainmentConsumptionNumberText.text = data.EntertainmentConsumption.ToString() + " W";
        float TotalConsumption = data.EntertainmentConsumption + data.NecessitiesConsumption + data.LightConsumption;
        float EnergySaved = TotalConsumption * (((float)data.ConsumptionBoostLevel * 2) / 100);
        Debug.Log(data.ConsumptionBoostLevel);
        Debug.Log(EnergySaved);
        float TrueTotalConsumption = TotalConsumption - EnergySaved;
        EnergySavedText.text = EnergySaved.ToString() + " W";
        ExpectedConsumption.text = TotalConsumption.ToString() + " W";
        TotalConsumptionNumberText.text = TrueTotalConsumption.ToString() + " W";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
