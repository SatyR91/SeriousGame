using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour, IPointerEnterHandler {

    public AudioClip hoverSoundFX;
    public AudioClip clickSoundFX;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<AudioSource>().clip = hoverSoundFX;
        GetComponent<AudioSource>().Play();
    }

    public IEnumerator LoadNewScene(string SceneName)
    {
        GetComponent<AudioSource>().clip = clickSoundFX;
        GetComponent<AudioSource>().Play();

        Fade fader = GameObject.Find("Fader").GetComponent<Fade>();
        fader.BeginFade(1);
        yield return new WaitForSeconds(fader.fadeSpeed);
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
    }
}
