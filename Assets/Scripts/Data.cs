using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

#region
    private static Data _instance;

    public static Data instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("ForcedDataInitialisation");
                GameObject data = new GameObject("Data");
                data.AddComponent<Data>();
                _instance = data.GetComponent<Data>();
            }
            return _instance;
        }
    }

#endregion

    public int DishwasherLevel;
    public int StoveLevel;
    public int RefrigeratorLevel;
    public int WashingMachineLevel;
    public int DryingMachineLevel;
    public int CasualComputerLevel;
    public int GamingComputerLevel;
    public int TelevisionLevel;
    public int Money;
    public int MoralBoostLevel;
    public int LightBoostLevel;
    public int ConsumptionBoostLevel;
    public int SkillPoints;


    public float LightConsumption;
    public float DishwasherConsumption;
    public float StoveConsumption;
    public float RefrigeratorConsumption;
    public float WashingMachineConsumption;
    public float VacuumCleanerConsumption;
    public float CasualComputerConsumption;
    public float GamingComputerConsumption;
    public float TelevisionConsumption;
    public float MiscellanelousConsumption;


    public int CurrentWeek;

    private bool AlreadyPresent()
    {
        //Yeah datas ain't right but well, deal with it.

        return _instance != null;
    }
    private void Initialize()
    {
        //Conservation of the new gameObject on load
        GameObject.DontDestroyOnLoad(gameObject);
        CurrentWeek = 0;
    }

    public void Awake()
    {
        if (AlreadyPresent())
        {
            DestroyImmediate(this.gameObject, true);
        }
        else
        {
            _instance = this;
            Initialize();
        }
    }
}
