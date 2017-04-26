using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device : MonoBehaviour{
    private GameController gC;
    public DigitalGameTimeClock gameTimeClock;
    public GameObject light;
    public int id;
    public int level;
    public string deviceName;
    public float consumption;
    private float consumptionTick;
    public List<float> consumptionList;
    public bool used;
    public bool on;
    public float tmpConsumption;
    public float timerStart;
    public float timerEnd;
    public float tick;

   // public float timeOn;

    private void Start()
    {
        gameTimeClock = GameObject.Find("GameTimeClock").GetComponent<DigitalGameTimeClock>();
        gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        consumption = consumptionList[level];
        light.SetActive(false);
        //coroutineActive = false;
        consumptionTick = consumption * 0.25f / 1000;
    }

    private void Update()
    {
        
    }

    public void setOn(bool b)
    {

        if (b)
        {
            light.SetActive(true);
            on = true;
            timerStart = gameTimeClock.currentTime;
            gC.currentEnergyUsed += consumption;
        }
        else
        {
            timerEnd = gameTimeClock.currentTime;
            light.SetActive(false);
            on = false;
            gC.currentEnergyUsed -= consumption;
            //Debug.Log("seuf : " + name);
            ConsumptionCalcul();
        }
    }

    public void ConsumptionCalcul()
    {

        float timeElapsed;
        if (timerEnd<16*60 && timerStart > 16 * 60)
        {

            timeElapsed = 24 * 60 - timerStart + timerEnd;
        }
        else {
            timeElapsed = timerEnd - timerStart;
        }
        
        tmpConsumption += timeElapsed * consumptionTick;
        gC.energyMax -= tmpConsumption;
    }


}
