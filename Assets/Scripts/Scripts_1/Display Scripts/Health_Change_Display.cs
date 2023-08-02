using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health_Change_Display : MonoBehaviour
{
    //Gameobject vars
    [SerializeField] private TMPro.TextMeshProUGUI health_text;
    [SerializeField] private Image background_image;
    [SerializeField] private Image fill_image;

    void Awake()
    {
        //get TMPro.TextMeshProUGUI
        health_text = gameObject.transform.Find("Text (Health:)").GetComponent<TMPro.TextMeshProUGUI>();

        //get background_image
        background_image = gameObject.transform.Find("Background").GetComponent<Image>();

        //get fill_image
        fill_image = gameObject.transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>();
    }

    public void Display_Health_Up()
    {
        //set text color to green 
        health_text.color = Color.green;

        //set background_image color to green
        background_image.color = Color.green;

        //set fill_image color to green
        fill_image.color = Color.green;

        //Fade from green to white
        StartCoroutine(Fade_Green_To_White());
    }

    public void Display_Health_Down()
    {
        //set text color to red
        health_text.color = Color.red;

        //set background_image color to red
        background_image.color = Color.red;

        //set fill_image color to red
        fill_image.color = Color.red;

        //Fade from red to white
        StartCoroutine(Fade_Red_To_White());
    }

    IEnumerator Fade_Green_To_White()
    {
        //keep text and slider colors at green for 0.5 seconds
        yield return new WaitForSeconds(0.5f);

        //fade to white over the course of 1 second
        for (float index_white = 0f; index_white <= 1f; index_white += 0.1f)
        {
            //make new transitional color
            Color c = new Color(index_white, 1f, index_white, 1f); 

            //change health_text color
            health_text.color = c;

            //change background_image color
            background_image.color = c;

            //change fill_image color
            fill_image.color = c;

            //wait 0.1 seconds
            yield return new WaitForSeconds(0.1f);
        }

        //make text white
        health_text.color = Color.white;
    }

    IEnumerator Fade_Red_To_White()
    {
        //keep text and slider colors at red for 0.5 seconds
        yield return new WaitForSeconds(0.5f);

        //fade to white over the course of 1 second
        for (float index_white = 0f; index_white <= 1f; index_white += 0.1f)
        {
            //make new transitional color
            Color c = new Color(1f, index_white, index_white, 1f);

            //change health_text color
            health_text.color = c;

            //change background_image color
            background_image.color = c;

            //change fill_image color
            fill_image.color = c;

            //wait 0.1 seconds
            yield return new WaitForSeconds(0.1f);
        }

        //make text white
        health_text.color = Color.white;
    }
}
