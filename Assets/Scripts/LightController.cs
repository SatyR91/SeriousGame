using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    GameController gController;
    float energyConsumption;

	// Use this for initialization
	void Start () {
        //GetComponent<Light>().enabled = false;
        gController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        energyConsumption = 0.06f;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Light>().enabled == true)
        {
            gController.EnergyLoss(energyConsumption);
            gController.data.LightConsumption += energyConsumption;
        }
	}
}
