using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickOnFM : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "FamilyMember")
                {
                    GameObject fmHit = hit.collider.gameObject;
                    SendCancelMessage(fmHit);
                    Debug.Log("Les Seufs");
                }
            }
        }
    }

    void SendCancelMessage(GameObject fmHit)
    {
        fmHit.SendMessage("ChangeActivity");
    }



}
