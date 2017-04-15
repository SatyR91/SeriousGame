using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageOnClick : MonoBehaviour {

    public GameObject receiver;
    public string message;

    public void OnMouseDown()
    {
        receiver.SendMessage(message);
    }
}
