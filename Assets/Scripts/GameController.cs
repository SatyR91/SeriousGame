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

    public Data data;

    public DigitalGameTimeClock gameClock;

    public Device DishWasher;
    public Device Stove;
    public Device Refrigerator;
    public Device WashingMachine;
    public Device VacuumCleaner;
    public Device CasualComputer;
    public Device GamingComputer;
    public Device Television;

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

        #region Electric devices level initialization
        DishWasher.level = data.DishwasherLevel;
        Stove.level = data.StoveLevel;
        Refrigerator.level = data.RefrigeratorLevel;
        VacuumCleaner.level = data.VacuumCleanerLevel;
        WashingMachine.level = data.WashingMachineLevel;
        CasualComputer.level = data.CasualComputerLevel;
        GamingComputer.level = data.GamingComputerLevel;
        Television.level = data.TelevisionLevel;
        #endregion
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
            stockDevicesConsumption();
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

    public float RetrieveDeviceConsumption(string name)
    {
        switch (name)
        {
            case ("Washing Machine"):
                return WashingMachine.tmpConsumption;
            case ("Television"):
                return Television.tmpConsumption;
            case ("Dish Washer"):
                return DishWasher.tmpConsumption;
            case ("Casual Computer"):
                return CasualComputer.tmpConsumption;
            case ("Gaming Computer"):
                return WashingMachine.tmpConsumption;
            case ("Vacuum Cleaner"):
                return VacuumCleaner.tmpConsumption;
            case ("Refrigerator"):
                return Refrigerator.tmpConsumption;
            case ("Stove"):
                return Stove.tmpConsumption;
            default:
                return 0;
        }
    }

    public void stockDevicesConsumption()
    {
        data.DishwasherConsumption = RetrieveDeviceConsumption("Dish Washer");
        data.WashingMachineConsumption = RetrieveDeviceConsumption("Washing Machine");
        data.CasualComputerConsumption = RetrieveDeviceConsumption("Casual Computer");
        data.GamingComputerConsumption = RetrieveDeviceConsumption("Gaming Computer");
        data.StoveConsumption = RetrieveDeviceConsumption("Stove");
        data.TelevisionConsumption = RetrieveDeviceConsumption("Television");
        data.RefrigeratorConsumption = RetrieveDeviceConsumption("Refrigerator");
        data.VacuumCleanerConsumption = RetrieveDeviceConsumption("Vacuum Cleaner");

    }
}
