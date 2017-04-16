using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityDescription : MonoBehaviour {

    public GameObject SpeechBubble;

    public void TellActivity(string ActivityName)
    {
        StartCoroutine(ExpandSpeechBubble(ActivityName));
    }

    private IEnumerator ExpandSpeechBubble(string ActivityName)
    {
        float StartTime = Time.time;
        SpeechBubble.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Time.time - StartTime);
        StartCoroutine(DisplayText(ActivityName));
        yield return null;
    }

    private IEnumerator DisplayText(string ActivityName)
    {
        int i = 0;
        string TexttoDisplay = "";
        switch(ActivityName)
        {
            case ("Test"):
                TexttoDisplay = "J'ai envie de seufs.";
                break;
            default:
                break;
        }
        string str = "";
        float timeToDisplay = 1.5f / TexttoDisplay.Length;
        while (i < TexttoDisplay.Length)
        {
            str += TexttoDisplay[i++];
            SpeechBubble.GetComponentInChildren<Text>().text = str;
            yield return new WaitForSeconds(timeToDisplay);
        }
        yield return new WaitForSeconds(4.0f);
        StartCoroutine(DestroySpeechBubble());
    }

    private IEnumerator DestroySpeechBubble()
    {
        float StartTime = Time.time;
        SpeechBubble.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(0, 0, 0), Time.time - StartTime);
        SpeechBubble.GetComponentInChildren<Text>().text = "";
        yield return null;
    }

}
