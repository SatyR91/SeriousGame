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
    public int MicrowaveLevel;
    public int RefrigeratorLevel;
    public int WashingMachineLevel;
    public int DryingMachineLevel;
    public int CasualComputerLevel;
    public int GamingComputerLevel;
    public int TelevisionLevel;
    public int Money;

    private bool AlreadyPresent()
    {
        //Yeah datas ain't right but well, deal with it.

        return _instance != null;
    }
    private void Initialize()
    {
        //Conservation of the new gameObject on load
        GameObject.DontDestroyOnLoad(gameObject);
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
