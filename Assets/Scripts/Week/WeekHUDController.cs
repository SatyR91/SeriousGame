using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeekHUDController : MonoBehaviour {
    public WeekController gameController;

  
    public Transform moralPanelFm1;
    public Transform moralPanelFm2;
    public Transform moralPanelFm3;
    public Transform moralPanelFm4;

    public Transform surnameFm1;
    public Transform surnameFm2;
    public Transform surnameFm3;
    public Transform surnameFm4;

    public Text moneyText;

    private FamilyMember fm1;
    private FamilyMember fm2;
    private FamilyMember fm3;
    private FamilyMember fm4;

    // Use this for initialization
    void Start () {
        fm1 = gameController.fm1;
        fm2 = gameController.fm2;
        fm3 = gameController.fm3;
        fm4 = gameController.fm4;
        surnameFm1.GetComponent<Text>().text = fm1.surname;
        surnameFm2.GetComponent<Text>().text = fm2.surname;
        surnameFm3.GetComponent<Text>().text = fm3.surname;
        surnameFm4.GetComponent<Text>().text = fm4.surname;
        BarsUpdate();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void BarsUpdate()
    {
        BarUpdate(moralPanelFm1, fm1.moral, 100);
        BarUpdate(moralPanelFm2, fm2.moral, 100);
        BarUpdate(moralPanelFm3, fm3.moral, 100);
        BarUpdate(moralPanelFm4, fm4.moral, 100);
        moneyText.text = gameController.money.ToString();
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



}
