using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

	public void onClick(string SceneName)
    {
        if (SceneName == "Level") GameObject.Find("Data").GetComponent<Data>().CurrentWeek++;

        if (SceneName == "Upgrade" && GameObject.Find("Data").GetComponent<Data>().Money < 0) SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        else if (SceneName == "Upgrade" && GameObject.Find("Data").GetComponent<Data>().Money >= 0 && GameObject.Find("Data").GetComponent<Data>().CurrentWeek >= 10) SceneManager.LoadSceneAsync("Victory", LoadSceneMode.Single);
        else
        {
            StartCoroutine(LoadNewScene(SceneName));

        }
    }

    public IEnumerator LoadNewScene(string SceneName)
    {
        Fade fader = GameObject.Find("Fader").GetComponent<Fade>();
        fader.BeginFade(1);
        yield return new WaitForSeconds(fader.fadeSpeed);
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
    }
}
