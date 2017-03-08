using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextPage : MonoBehaviour {

    WeekController wC;
	// Use this for initialization
	void Start () {
        wC = GameObject.FindGameObjectWithTag("WeekController").GetComponent<WeekController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Next")
                {
                    wC.SendMessage("NextPage");
                }
            }
        }
    }
}
