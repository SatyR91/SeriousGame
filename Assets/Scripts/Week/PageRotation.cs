using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageRotation : MonoBehaviour {
    private bool rotationDone = false;
    private bool textDestructionDone = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RotatePage();


    } 

    void RotatePage()
    {
        if (!rotationDone) {
            if (transform.rotation.eulerAngles.y < 140)
            {
                if (transform.rotation.eulerAngles.y > 70 && !textDestructionDone)
                {
                    DestroyTextMeshes();
                }
                gameObject.transform.Rotate(gameObject.transform.up, 1f);
            }
            else
            {
                rotationDone = true;
            }
        }
    }

    void DestroyTextMeshes()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; ++i)
        {
            Destroy(transform.GetChild(0).GetChild(i).gameObject);
        }
        textDestructionDone = true;
    }
}
