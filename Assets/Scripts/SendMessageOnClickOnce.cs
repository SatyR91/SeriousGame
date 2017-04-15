using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageOnClickOnce : MonoBehaviour {

    public GameObject receiver;
    public string message;
    bool clicked = false;

    public void OnMouseDown()
    {
        if (!clicked) 
            receiver.SendMessage(message);
    }
}
