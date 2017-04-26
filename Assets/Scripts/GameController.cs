using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public FamilyMember fm1;
    public FamilyMember fm2;
    public FamilyMember fm3;
    public FamilyMember fm4;

    public float currentEnergyUsed;
    public float energy;
    public float energyMax = 100;
    public float money;
    public float moneyMax = 100;
    public float moralLossPerTick = 0.005f;
    public float EnergyConsumption;

    public float energyAwareness;

    private Data data;

    public DigitalGameTimeClock gameClock;
    // Use this for initialization
    void Start () {
        data = GameObject.Find("Data").GetComponent<Data>();
        fm1.moral = data.fm1Moral;
        fm2.moral = data.fm2Moral;
        fm3.moral = data.fm3Moral;
        fm4.moral = data.fm4Moral;
        currentEnergyUsed = 0;
        energy = 0;
        money = moneyMax;
        energyAwareness = (float)GameObject.Find("Data").GetComponent<Data>().LightBoostLevel;
        Debug.Log(energyAwareness);
	}
	
	// Update is called once per frame
	void Update () {
        MoralLossTick(moralLossPerTick);
        if (fm1.moral <= 0 && fm2.moral <= 0 && fm3.moral <= 0 && fm4.moral <= 0) SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        if (fm3.GetComponent<StatePattern>().currentState == fm3.GetComponent<StatePattern>().sleepState && gameClock.currentTime >= 90)
        {
            data.fm1Moral = fm1.moral;
            data.fm2Moral = fm2.moral;
            data.fm3Moral = fm3.moral;
            data.fm4Moral = fm4.moral;
            StartCoroutine(LoadNewScene("Week"));
        }
        
	}

    /// <summary>
    /// Moral loss per tick for each member of the family
    /// </summary>
    public void MoralLossTick(float value)
    {
        fm1.moralLoss(value);
        fm2.moralLoss(value);
        fm3.moralLoss(value);
        fm4.moralLoss(value);
    }

    public void EnergyLoss(float value)
    {
        if (energy - value >= 0)
        {
            energy -= value;
        }
        else
        {
            // the end
        }
    }

    public void EnergyGain(float value)
    {
        if (energy + value >= energyMax)
        {
            energy = energyMax;
        }
        else
        {
            energy += value;
        }
    }

    public void MoneyGain(float value)
    {
        if (money + value >= moneyMax)
        {
            money = moneyMax;
        }
        else
        {
            money += value;
        }
    }

    public void MoneyLoss(float value)
    {
        if (money - value >= 0)
        {
            money -= value;
        }
        else
        {
            // the end
        }
    }

    private IEnumerator LoadNewScene(string SceneName)
    {
        Fade fader = GameObject.Find("Fader").GetComponent<Fade>();
        fader.BeginFade(1);
        yield return new WaitForSeconds(fader.fadeSpeed);
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
    }
}
