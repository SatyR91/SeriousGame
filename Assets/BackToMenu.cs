using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip hoverSoundFX;
    public AudioClip clickSoundFX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick() {
        StartCoroutine(PlaySoundBeforeLoadScene());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<AudioSource>().clip = hoverSoundFX;
        GetComponent<AudioSource>().Play();
    }

    IEnumerator PlaySoundBeforeLoadScene()
    {
        GetComponent<AudioSource>().clip = clickSoundFX;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
       
        SceneManager.LoadScene("Main Menu");
      
    }
}
