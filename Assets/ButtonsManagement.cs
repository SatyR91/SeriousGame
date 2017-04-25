using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManagement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick(string sceneName) {
        if (sceneName == "Quit")
        {
            Application.Quit();
        }
        else {
            SceneManager.LoadScene(sceneName);
        }

    }

}
