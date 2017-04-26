using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    private static Fade _instance;

    public static Fade instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject data = new GameObject("Fader");
                data.AddComponent<Fade>();
                _instance = data.GetComponent<Fade>();
            }
            return _instance;
        }
    }

    public Texture2D fadeOutTexture;
    public float fadeSpeed;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private float fadeDirection = -1;

    private void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float  BeginFade(int direction)
    {
        fadeDirection = direction;
        return (fadeSpeed);
    }

    private void OnLevelWasLoaded(int level)
    {
        BeginFade(-1);
    }
    private bool AlreadyPresent()
    {
        //Yeah datas ain't right but well, deal with it.

        return _instance != null;
    }
    private void Initialize()
    {
        //Conservation of the new gameObject on load
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public void Awake()
    {
        if (AlreadyPresent())
        {
            DestroyImmediate(this.gameObject, true);
        }
        else
        {
            _instance = this;
            Initialize();
        }
    }

}
