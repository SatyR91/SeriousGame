using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOff : MonoBehaviour {

    public GameController gameController;
    public List<Transform> lightsGO;
    private List<Light> lights;
    public float energyConsumption = 1;

    //number of person in the room
    int numberOfPerson = 0;

	// Use this for initialization
	void Start () {
        lights = new List<Light>();

		foreach(Transform lightGO in lightsGO) {
            lights.Add(lightGO.GetComponent<Light>());
        }
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "FamilyMember") {
            numberOfPerson++;
            Debug.Log("HERE COMES A NEW CHALLENGER : " + numberOfPerson);
            if (!lights[0].enabled) {
                foreach (Light l in lights) {
                    l.enabled = true;
                    gameController.currentEnergyUsed += energyConsumption;
                }
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "FamilyMember") {
            numberOfPerson--;

            if (numberOfPerson <= 0) {
                float randomFloat = Random.Range(0f, 1f) + gameController.energyAwareness;
                if (randomFloat > 1) {
                    Debug.Log("YEP : " + randomFloat);
                    foreach (Light l in lights) {
                        l.enabled = false;
                        gameController.currentEnergyUsed -= energyConsumption;
                    }
                }
                else {
                    Debug.Log("NOPE : " + randomFloat);
                }
            }
        }
    }
}
