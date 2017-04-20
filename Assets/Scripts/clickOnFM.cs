using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickOnFM : MonoBehaviour
{
    public Canvas CancelActivityUI;
    public Transform ExclamationSprite;

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
                    fmHit.GetComponentInChildren<ParticleSystem>().Play();
                }
            }
        }
    }

    void SendCancelMessage(GameObject fmHit)
    {
        fmHit.SendMessage("ChangeActivity");
    }



}
