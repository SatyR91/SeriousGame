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
        light.SetActive(false);
    }

    private void Update()
    {
        if (on)
        {
            gC.energy += consumption;
        }
    }

    public void setOn(bool b)
    {
        if (b)
        {
            light.SetActive(true);
            gC.currentEnergyUsed += consumption;
        }
        else
        {
            light.SetActive(false);
            gC.currentEnergyUsed -= consumption;
        }
    }
}
