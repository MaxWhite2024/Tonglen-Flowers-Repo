using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Accuracy_Display : MonoBehaviour
{
    //Gameobject vars
    private TMPro.TextMeshProUGUI percent_text;

    //number vars
    //the following var must be set from the inspector
    [SerializeField] private float min_breath_percent;
    
    void Awake()
    {
        //get TMPro.TextMeshProUGUI
        percent_text = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void Display_Percent(float dst)
    {
        //get percentage value from dst
        int percentage = (int)(dst * 100);

        //set opacity to 100% and change color based on percentage
        if(percentage >= min_breath_percent)
        {
            percent_text.color = Color.green;
        }
        else 
        {
            percent_text.color = Color.red;
        }

        //change percentage_text text
        percent_text.text = percentage.ToString() + "% Accurate";

        //begin fade coroutine
        StartCoroutine(Fade());
    }

    public void Display_To_Early()
    {
        //change text color to white
        percent_text.color = Color.white;

        //change percentage_text to "Released too early"
        percent_text.text = "Released too early";

        //begin fade coroutine
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        //keep text at 100% opacity for 0.5 seconds
        yield return new WaitForSeconds(0.5f);

        //fade to clear over the course of 1 second
        Color c = percent_text.color;
        for (float alpha = 1f; alpha >= 0f; alpha -= 0.1f)
        {
            c.a = alpha;
            percent_text.color = c;
            yield return new WaitForSeconds(.1f);
        }

        //make text clear
        percent_text.color = Color.clear;
    }

    public float Get_Min_Breath_Percent()
    {
        return min_breath_percent;
    }
}
