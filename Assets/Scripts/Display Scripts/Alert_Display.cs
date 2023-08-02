using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Alert_Display : MonoBehaviour
{
    //Gameobject vars
    private TMPro.TextMeshProUGUI alert_text;
    
    void Awake()
    {
        //get TMPro.TextMeshProUGUI
        alert_text = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void Display_Alert(string alert)
    {
        //set opacity to 100%
        alert_text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        //change alert_text text
        alert_text.text = alert;

        //begin fade coroutine
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        //keep text at 100% opacity for 1 seconds
        yield return new WaitForSeconds(1f);

        //fade to clear over the course of 1 second
        Color c = alert_text.color;
        for (float alpha = 1f; alpha >= 0f; alpha -= 0.1f)
        {
            c.a = alpha;
            alert_text.color = c;
            yield return new WaitForSeconds(.1f);
        }

        //make text clear
        alert_text.color = Color.clear;
    }
}
