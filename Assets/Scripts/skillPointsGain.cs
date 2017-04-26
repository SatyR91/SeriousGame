using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillPointsGain : MonoBehaviour {
    public Data data;
	// Use this for initialization
	void Start () {
        data = GameObject.Find("Data").GetComponent<Data>();
        float totalMoral = data.fm1Moral + data.fm2Moral + data.fm3Moral + data.fm4Moral;
        if (totalMoral >= 300 && data.totalSocial >= 75)
        {
            data.SkillPoints++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
