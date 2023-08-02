using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Microphone_Toggle_Behavior : MonoBehaviour
{
    private Toggle my_toggle;
    private Microphone_Behavior microphone_behavior;

    void Awake()
    {
        //find my_toggle
        my_toggle = GetComponent<Toggle>();

        //find microphone_behavior
        microphone_behavior = GameObject.FindWithTag("Microphone_Tag").GetComponent<Microphone_Behavior>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //set my_toggle to on
        my_toggle.isOn = true;

        //make microphone on
        microphone_behavior.Set_Use_Microphone(true);
    }

    public void Update_Use_Microphone()
    {
        microphone_behavior.Set_Use_Microphone(my_toggle.isOn);
    }
}
