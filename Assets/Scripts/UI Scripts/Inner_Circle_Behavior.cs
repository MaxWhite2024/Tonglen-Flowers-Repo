using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Inner_Circle_Behavior handles the behavior of the growing and shrinking circle
public class Inner_Circle_Behavior : MonoBehaviour
{
    //GameObject vars
    private RectTransform rt;
    private Image image;

    //number vars
    private Vector3 trough_size = new Vector3(0.1f, 0.1f, 1f);
    private Vector3 peak_size = new Vector3(1f, 1f, 1f);
    [SerializeField] private float timer = 0f;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        rt.localScale = trough_size;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //increment timer
        timer += Time.deltaTime;

        Rhythm_State cur_rhythm_state = Rhythm_Behavior.cur_rhythm_state;

        if(cur_rhythm_state == Rhythm_State.IN)
            rt.localScale = Vector3.Lerp(trough_size, peak_size, timer / Rhythm_Behavior.in_time);
        else if(cur_rhythm_state == Rhythm_State.PEAK_HOLD)
        {
            rt.localScale = peak_size;
            timer = 0f;
        }
        else if(cur_rhythm_state == Rhythm_State.OUT)        
            rt.localScale = Vector3.Lerp(peak_size, trough_size, timer / Rhythm_Behavior.out_time);
        else if(cur_rhythm_state == Rhythm_State.TROUGH_HOLD)
        {
            rt.localScale = trough_size;
            timer = 0f;
        }


    }

    public void Reset_Inner_Circle()
    {
        //reset scale
        rt.localScale = trough_size;

        //reset timer
        timer = 0f;
    }

    public void Color_Inner_Circle(Color new_color)
    {
        image.color = new_color;
    }
}
