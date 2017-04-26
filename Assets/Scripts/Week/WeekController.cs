using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeekController : MonoBehaviour {

    int currentDay;
    DailyEvent currentEvent;
    public Transform days;
    DailyEventsController dailyEventsController;
    public WeekHUDController weekHUDController;

    public FamilyMember fm1;
    public FamilyMember fm2;
    public FamilyMember fm3;
    public FamilyMember fm4;

    public float money;
    public float energy;



    List<GameObject> daysTransform = new List<GameObject>();
    List<DailyEvent> daysEvents = new List<DailyEvent>();

    // Use this for initialization
    void Start() {
        dailyEventsController = GetComponent<DailyEventsController>();
        currentDay = 0; // Mardi
        
        daysEvents.Add(dailyEventsController.SelectRandomEvent(dailyEventsController.RandomRarity()));
        daysEvents.Add(dailyEventsController.SelectRandomEvent(dailyEventsController.RandomRarity()));
        daysEvents.Add(dailyEventsController.SelectRandomEvent(dailyEventsController.RandomRarity()));
        daysEvents.Add(dailyEventsController.SelectRandomEvent(dailyEventsController.RandomRarity()));
        daysEvents.Add(dailyEventsController.SelectRandomEvent(dailyEventsController.RandomRarity()));
        daysEvents.Add(dailyEventsController.SelectRandomEvent(dailyEventsController.RandomRarity()));

        currentEvent = daysEvents[currentDay];
        daysTransform.Add(days.GetChild(0).gameObject);
        daysTransform.Add(days.GetChild(1).gameObject);
        daysTransform[1].SetActive(false);
        daysTransform.Add(days.GetChild(2).gameObject);
        daysTransform[2].SetActive(false);
        daysTransform.Add(days.GetChild(3).gameObject);
        daysTransform[3].SetActive(false);
        daysTransform.Add(days.GetChild(4).gameObject);
        daysTransform[4].SetActive(false);
        daysTransform.Add(days.GetChild(5).gameObject);
        daysTransform[5].SetActive(false);


        WriteDailyEvent();
       
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Next")
                {
                    NextPage();
                }
            }
        }
    }

    void NextPage()
    {
        daysTransform[currentDay].GetComponent<PageRotation>().enabled = true;
        currentDay++;
        if (currentDay >= 6)
        {
            StartCoroutine(LoadNewScene("Recap"));
        }
        currentEvent = daysEvents[currentDay];
        daysTransform[currentDay].SetActive(true);
        WriteDailyEvent();
    }

    void AcceptButtonPressed() {
        List<FamilyMember> targets = currentEvent.targets;
        foreach(var target in targets)
        {
            if (target.moral + currentEvent.moralVariation >= 100)
            {
                target.moral = 100;
            }
            else if (target.moral + currentEvent.moralVariation <= 0)
            {
                target.moral = 0;
            }
            else
            {
                target.moral += currentEvent.moralVariation;
            }
            
            
        }
        money += currentEvent.moneyVariation;
        energy += currentEvent.energyVariation;
        weekHUDController.BarsUpdate();
        NextPage();
    }

    void DeclineButtonPressed() {
        NextPage();
    }

    void WriteDailyEvent()
    {
        Transform page = daysTransform[currentDay].transform.GetChild(0);
        page.FindChild("Description").GetComponent<TextMesh>().text = currentEvent.description;
        page.FindChild("MoralCost").GetComponent<TextMesh>().text = currentEvent.moralVariation.ToString();
        page.FindChild("EnergyCost").GetComponent<TextMesh>().text = currentEvent.energyVariation.ToString();
        page.FindChild("MoneyCost").GetComponent<TextMesh>().text = currentEvent.moneyVariation.ToString();

        if (currentEvent.targets.Count == 0)
        {
            page.FindChild("Accept").gameObject.SetActive(false);
            page.FindChild("Decline").gameObject.SetActive(false);
            page.FindChild("Next").gameObject.SetActive(true);
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
