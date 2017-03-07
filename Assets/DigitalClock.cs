using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitalClock : MonoBehaviour {

    private string text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var date = System.DateTime.Now;
        text = date.ToString("HH:mm:ss");
        GetComponent<TextMesh>().text = text;
	}
     
}

