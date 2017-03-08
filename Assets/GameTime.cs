using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public Transform Sun;
    public float dayCycleInMinutes = 4;

    public const float SECOND = 1;
    public const float MINUTE = 60 * SECOND;
    public const float HOUR = 60 * MINUTE;
    public const float DAY = 24 * HOUR;
    public const float MONTH = 30 * DAY;
    public const float YEAR = 12 * MONTH;

    private const float DEGREES_PER_SECOND = 360 / DAY;

    private float _degreeRotation;

    private float _timeofDay;

    // Use this for initialization
    void Start()
    {
        _timeofDay = 0;
        _degreeRotation = DEGREES_PER_SECOND * DAY / (dayCycleInMinutes * MINUTE);
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        Sun.Rotate(new Vector3(_degreeRotation, 0, 0) * Time.deltaTime);



        _timeofDay += Time.deltaTime;
        Debug.Log(_timeofDay);


    }
}