using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    public GameObject Sliders;

    public GameObject dad;
    public GameObject mom;
    public GameObject teen;
    public GameObject kid;
    public Slider dadWorkSlider;
    public Slider dadMoralSlider;
    public Slider dadSocialSlider;
    public Slider momWorkSlider;
    public Slider momMoralSlider;
    public Slider momSocialSlider;
    public Slider teenWorkSlider;
    public Slider teenMoralSlider;
    public Slider teenSocialSlider;
    public Slider kidWorkSlider;
    public Slider kidMoralSlider;
    public Slider kidSocialSlider;

    [HideInInspector]
    public StatePattern dadPattern;
    [HideInInspector]
    public StatePattern momPattern;
    [HideInInspector]
    public StatePattern teenPattern;
    [HideInInspector]
    public StatePattern kidPattern;


    // Use this for initialization
    void Start () {
        dadPattern = dad.GetComponent<StatePattern>();
        momPattern = mom.GetComponent<StatePattern>();
        teenPattern = teen.GetComponent<StatePattern>();
        kidPattern = kid.GetComponent<StatePattern>();
        StartCoroutine(WaitForEndOfFade());

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnClick() {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame() {
        dadPattern.workImportance = (int)Mathf.Floor(dadWorkSlider.value);
        dadPattern.moralImportance = (int)Mathf.Floor(dadMoralSlider.value);
        dadPattern.socialImportance = (int)Mathf.Floor(dadSocialSlider.value);
        momPattern.workImportance = (int)Mathf.Floor(momWorkSlider.value);
        momPattern.moralImportance = (int)Mathf.Floor(momMoralSlider.value);
        momPattern.socialImportance = (int)Mathf.Floor(momSocialSlider.value);
        teenPattern.workImportance = (int)Mathf.Floor(teenWorkSlider.value);
        teenPattern.moralImportance = (int)Mathf.Floor(teenMoralSlider.value);
        teenPattern.socialImportance = (int)Mathf.Floor(teenSocialSlider.value);
        kidPattern.workImportance = (int)Mathf.Floor(kidWorkSlider.value);
        kidPattern.moralImportance = (int)Mathf.Floor(kidMoralSlider.value);
        kidPattern.socialImportance = (int)Mathf.Floor(kidSocialSlider.value);

        dadPattern.SortPreferences();
        momPattern.SortPreferences();
        teenPattern.SortPreferences();
        kidPattern.SortPreferences();

        Time.timeScale = 1;

        yield return new WaitForSeconds(0.5f);

        Sliders.SetActive(false);
    }

    IEnumerator WaitForEndOfFade()
    {
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0;
    }
}
