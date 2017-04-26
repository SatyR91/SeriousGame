using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {
    public GameController gameController;

    public Transform globalMoralPanel;
    public Transform globalEnergyPanel;
    public Transform globalMoneyPanel;
    
    bool barsUpdateTime = true;
    
    public Transform moralPanelFm1;
    public Transform moralPanelFm2;
    public Transform moralPanelFm3;
    public Transform moralPanelFm4;

    public Text activityTextFm1;
    public Text activityTextFm2;
    public Text activityTextFm3;
    public Text activityTextFm4;

    public Image socialImageFm1;
    public Image socialImageFm2;
    public Image socialImageFm3;
    public Image socialImageFm4;

    public Image workImageFm1;
    public Image workImageFm2;
    public Image workImageFm3;
    public Image workImageFm4;
    
    public Transform surnameFm1;
    public Transform surnameFm2;
    public Transform surnameFm3;
    public Transform surnameFm4;

    private FamilyMember fm1;
    private FamilyMember fm2;
    private FamilyMember fm3;
    private FamilyMember fm4;

    private Data data;
    // Use this for initialization
    void Start () {
        data = GameObject.Find("Data").GetComponent<Data>();
        fm1 = gameController.fm1;
        fm2 = gameController.fm2;
        fm3 = gameController.fm3;
        fm4 = gameController.fm4;
        surnameFm1.GetComponent<Text>().text = fm1.surname;
        surnameFm2.GetComponent<Text>().text = fm2.surname;
        surnameFm3.GetComponent<Text>().text = fm3.surname;
        surnameFm4.GetComponent<Text>().text = fm4.surname;
        globalMoneyPanel.GetComponentInChildren<Text>().text = data.Money.ToString();
        BarsUpdate();
    }
	
	// Update is called once per frame
	void Update () {
        if (barsUpdateTime)
           StartCoroutine(FinishFirst(3.0f, BarsUpdate));
        ActivityUpdate(activityTextFm1, fm1);
        ActivityUpdate(activityTextFm2, fm2);
        ActivityUpdate(activityTextFm3, fm3);
        ActivityUpdate(activityTextFm4, fm4);
        currentEnergyUsedUpdate();
    }

    IEnumerator FinishFirst(float waitTime, System.Action doLast)
    {
        barsUpdateTime = false;
        yield return new WaitForSeconds(waitTime);
        doLast();
    }

    void BarsUpdate()
    {
        BarUpdate(moralPanelFm1, fm1.moral, 100);
        BarUpdate(moralPanelFm2, fm2.moral, 100);
        BarUpdate(moralPanelFm3, fm3.moral, 100);
        BarUpdate(moralPanelFm4, fm4.moral, 100);
        SocialValueUpdate(socialImageFm1, fm1);
        SocialValueUpdate(socialImageFm2, fm2);
        SocialValueUpdate(socialImageFm3, fm3);
        SocialValueUpdate(socialImageFm4, fm4);
        WorkValueUpdate(workImageFm1, fm1);
        WorkValueUpdate(workImageFm2, fm2);
        WorkValueUpdate(workImageFm3, fm3);
        WorkValueUpdate(workImageFm4, fm4);

        GlobalMoralUpdate(globalMoralPanel, fm1, fm2, fm3, fm4);
        barsUpdateTime = true;
    }

    void currentEnergyUsedUpdate()
    {
        BarUpdate(globalEnergyPanel, gameController.currentEnergyUsed, gameController.energyMax);
    }

    /// <summary>
    /// Update a specific bar
    /// </summary>
    /// <param name="barPanel"></param>
    /// <param name="value"></param>
    /// <param name="maxValue"></param>
    public void BarUpdate(Transform barPanel, float value, float maxValue)
    {
        Transform full = barPanel.FindChild("Full");
        float scale = (float) value / maxValue;
        full.GetComponent<Image>().rectTransform.localScale = new Vector3(scale, 1, 1);
    }


    public void GlobalMoralUpdate (Transform barPanel, FamilyMember fm1, FamilyMember fm2, FamilyMember fm3, FamilyMember fm4)
    {
        float globalMoral = (fm1.moral + fm2.moral + fm3.moral + fm4.moral) / 4;
        BarUpdate(barPanel, globalMoral, 100);
    }

    public void ActivityUpdate(Text activityText, FamilyMember fm)
    {
        if (fm.GetComponent<StatePattern>().currentState == fm.GetComponent<StatePattern>().wanderState)
        {
            activityText.text = "Wandering";
        }
        else if (fm.GetComponent<StatePattern>().currentState == fm.GetComponent<StatePattern>().sleepState)
        {
            activityText.text = "Sleeping";
        }
        else if (fm.GetComponent<StatePattern>().currentState == fm.GetComponent<StatePattern>().outState)
        {
            activityText.text = "Working";
        }
        else if (fm.GetComponent<StatePattern>().currentState == fm.GetComponent<StatePattern>().chatState)
        {
            activityText.text = "Discussing";
        }
        else if (fm.GetComponent<StatePattern>().activityToMake != null)
        {
            activityText.text = fm.GetComponent<StatePattern>().activityToMake.activityName;
        }
        else {
            Debug.Log("No activity");
        }
       
    }

    public void SocialValueUpdate(Image socialImage, FamilyMember fm)
    {
        if (fm.socialValue >= 75)
        {
            socialImage.color = Color.green;
        }
        else if (fm.socialValue >= 25)
        {
            socialImage.color = Color.yellow;
        }
        else if (fm.socialValue <= 25)
        {
            socialImage.color = Color.red;
        }
    }

    public void WorkValueUpdate(Image workImage, FamilyMember fm)
    {
        if (fm.workValue >= 75)
        {
            workImage.color = Color.green;
        }
        else if (fm.workValue >= 50)
        {
            workImage.color = Color.yellow;
        }
        else if (fm.workValue <= 25)
        {
            workImage.color = Color.red;
        }
    }

}
