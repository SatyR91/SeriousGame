using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour {

    public GameObject[] Tutorial;
    private int tutorialIndex;
	// Use this for initialization
	void Start () {
        tutorialIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick() {
        if (tutorialIndex < Tutorial.Length-1)
        {
            Tutorial[tutorialIndex].SetActive(false);
            tutorialIndex++;
            Tutorial[tutorialIndex].SetActive(true);

        }
        else {
            SceneManager.LoadScene("Main Menu");
        }

        

    }

}
