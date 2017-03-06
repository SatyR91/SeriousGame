using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLights : MonoBehaviour {

    public GameObject lightToControl;
    GameController gController;

    void Start()
    {
        gController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerExit(Collider other)
    {
        float randomresult = Random.Range(0, 1.0f);
        if (randomresult < gController.energyAwareness)
        {
            
            lightToControl.GetComponent<Light>().enabled = false;
        }
    }
}
