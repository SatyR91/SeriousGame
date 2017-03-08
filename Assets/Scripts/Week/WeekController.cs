using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeekController : MonoBehaviour {

    int currentDay;
    public Transform days;

    Transform monday;
    Transform tuesday;
    Transform wednesday;
    Transform thursday;
    Transform friday;
    Transform saturday;
    Transform sunday;

	// Use this for initialization
	void Start () {
        currentDay = 1; // Mardi
        monday = days.GetChild(0);
        tuesday = days.GetChild(1);
        wednesday = days.GetChild(2);
        thursday = days.GetChild(3);
        friday = days.GetChild(4);
        saturday = days.GetChild(5);
        sunday = days.GetChild(6);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void NextPage()
    {
        currentDay++;
    }
}
