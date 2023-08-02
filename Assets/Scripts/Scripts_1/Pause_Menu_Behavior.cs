using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Pause_Menu_Behavior handles the player inputs in regards to pausing and unpausing
public class Pause_Menu_Behavior : MonoBehaviour
{
    //GameObject vars
    private GameObject pause_menu_obj;
    private GameObject pause_button_obj;
    private GameObject fail_menu_obj;
    private Rhythm_Behavior rhythm_behavior;
    private Inner_Circle_Behavior inner_circle_behavior;
    private Breath_Handler breath_handler;

    //number vars
    [HideInInspector] public static bool is_paused = false;

    void Awake()
    {
        //find and disable pause_menu_obj
        pause_menu_obj = GameObject.FindWithTag("Pause_Menu_Tag");

        //find pause_button_obj
        pause_button_obj = GameObject.FindWithTag("Pause_Button_Tag");

        //get and hide fail_menu obj
        fail_menu_obj = GameObject.FindWithTag("Fail_Menu_Tag");

        //find rhythm_behavior
        rhythm_behavior = GameObject.FindWithTag("Manager_Tag").GetComponent<Rhythm_Behavior>();

        //find inner_circle_behavior
        inner_circle_behavior = GameObject.FindWithTag("Inner_Circle_Tag").GetComponent<Inner_Circle_Behavior>();

        //find breath_handler
        breath_handler = GameObject.FindWithTag("Manager_Tag").GetComponent<Breath_Handler>();
        
        //Set timeScale to 1
        Time.timeScale = 1f;
    }

    void Start()
    {
        //hide pause_menu_obj
        pause_menu_obj.SetActive(false);

        //hide fail_menu_obj
        fail_menu_obj.SetActive(false);
    }

    public void Pause_Or_Resume(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(is_paused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        //set is_paused to true;
        is_paused = true;

        //enable pause menu
        pause_menu_obj.SetActive(true);

        //disable pause button object
        pause_button_obj.SetActive(false);

        //Set timeScale to zero
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        //set is_paused to false;
        is_paused = false;

        //disable pause menu
        pause_menu_obj.SetActive(false);

        //enable pause button object
        pause_button_obj.SetActive(true);

        //Set timeScale to 1
        Time.timeScale = 1f;

        //update amounts
        rhythm_behavior.Update_Amounts();

        //reset inner circle
        inner_circle_behavior.Reset_Inner_Circle();

        //reset breath_amount
        breath_handler.Reset_Breath_Amount();
    }
}
