using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device : MonoBehaviour{
    private GameController gC;
    public GameObject light;
    public int id;
    public int level;
    public string deviceName;
    public float consumption;
    public bool used;
    public bool on;


    private void Start()
    {
        gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        light.SetActive(on);
        if (on)
        {
            gC.energy -= consumption;
        }
    }
}
