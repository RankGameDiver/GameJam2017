using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeinout : MonoBehaviour
{
    public Image fade;
    float fades = 1.0f;
    float time = 0;
    bool fadeinout = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeinout)
        {
            fadeout();
        }
        if (!fadeinout)
        {
            fadein();
        }
    }
    void fadein()
    {
        time += Time.deltaTime;
        if (fades >= 0.0f && time >= 0.1f)
        {
            fades -= 0.1f;
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fades);
            time = 0;
        }
        else if (fades <= 0.0f)
        {
            fadeinout = !fadeinout;
        }
    }
    void fadeout()
    {
        time += Time.deltaTime;
        if (fades < 1.0f && time >= 0.1f)
        {
            fades += 0.1f;
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fades);
            time = 0;
        }
        else if (fades >= 1.0f)
        {
            fadeinout = !fadeinout;
        }
    }
}