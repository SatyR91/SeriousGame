using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecapManager : MonoBehaviour {

    public Text LightConsumptionNumberText;
    public Text NecessitiesConsumptionNumberText;
    public Text EntertainmentConsumptionNumberText;
    public Text TotalConsumptionNumberText;
    public Data data;

	// Use this for initialization
	void Start () {
        data = GameObject.Find("Data").GetComponent<Data>();
        LightConsumptionNumberText.text = data.LightConsumption.ToString() + " W";
        NecessitiesConsumptionNumberText.text = data.NecessitiesConsumption.ToString() + " W";
        EntertainmentConsumptionNumberText.text = data.EntertainmentConsumption.ToString() + " W";
        TotalConsumptionNumberText.text = (data.EntertainmentConsumption + data.NecessitiesConsumption + data.EntertainmentConsumption).ToString() + " W";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
