using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

	public void onClick(string SceneName)
    {
        if (SceneName == "Level") GameObject.Find("Data").GetComponent<Data>().CurrentWeek++;
        if (SceneName == "Upgrade" && GameObject.Find("Data").GetComponent<Data>().Money < 0) SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
    }
}
