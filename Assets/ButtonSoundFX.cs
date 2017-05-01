using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundFX : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip hoverSoundFX;
    public AudioClip clickSoundFX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        GetComponent<AudioSource>().clip = clickSoundFX;
        GetComponent<AudioSource>().Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<AudioSource>().clip = hoverSoundFX;
        GetComponent<AudioSource>().Play();
    }
    

    
}
