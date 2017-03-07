using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitalGameTimeClock : MonoBehaviour
{

    float nextSecond = 12.5f/60f;
    int second;
    float minute = 0.0f;
    float hour = 0.0f;
    float day = 0.0f;
    float month = 0.0f;
    float year = 0.0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (nextSecond > 0)
        {
            nextSecond -= Time.deltaTime;
        }
        else
        {
            nextSecond = 12.5f/60f;
            minute += 1;
        }
        if(minute >= 60)
        {
            minute = 0;
            hour += 1;
        }
        if (hour >= 24)
        {

            hour = 0;

            day += 1;

        }

        if (day >= 30)
        {

            day = 0;

            month += 1;

        }

        if (month >= 12)
        {

            month = 0;

            year += 1;

        }

        GetComponent<TextMesh>().text =  String.Format("{0:00}:{1:00}", hour,minute);

    }
}
