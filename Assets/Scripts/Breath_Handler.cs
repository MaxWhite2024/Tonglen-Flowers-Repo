using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Breath_Handler handles the player inputs, and breathing
public class Breath_Handler : MonoBehaviour
{
    //GameObject vars
    private Rhythm_Behavior rhythm_behavior;
    private Boat_Behavior boat_behavior;
    private Player_State_Behavior player_state_behavior;
    private Inner_Circle_Behavior inner_circle_behavior;
    private Microphone_Behavior microphone_behavior;
    private Accuracy_Display accuracy_display;

    //number vars
    [SerializeField] private float breath_amount;
    [SerializeField] private bool is_breath_held_down = false;
    private float peak_hold_amount;
    [SerializeField] private bool has_prev_exhaled = false;

    void Awake()
    {
        //find rhythm_behavior
        rhythm_behavior = GetComponent<Rhythm_Behavior>();

        //find boat_behavior
        boat_behavior = GameObject.FindWithTag("Player_Boat_Tag").GetComponent<Boat_Behavior>();

        //find player_state_behavior
        player_state_behavior = GameObject.FindWithTag("Player_Boat_Tag").GetComponent<Player_State_Behavior>();

        //find inner_circle_behavior
        inner_circle_behavior = GameObject.FindWithTag("Inner_Circle_Tag").GetComponent<Inner_Circle_Behavior>();

        //find microphone_behavior
        microphone_behavior = GameObject.FindWithTag("Microphone_Tag").GetComponent<Microphone_Behavior>();

        //find microphone_behavior
        microphone_behavior = GameObject.FindWithTag("Microphone_Tag").GetComponent<Microphone_Behavior>();

        //find Accuracy_Display
        accuracy_display = GameObject.FindWithTag("Percent_Tag").GetComponent<Accuracy_Display>();
    }

    void Update()
    {
        //if game is NOT paused
        if(!Pause_Menu_Behavior.is_paused)
        {
            //if microphone is in use:
            if(microphone_behavior.Get_Use_Microphone())
            {
                //if microphone heard a noise and current state is NOT OUT
                if(microphone_behavior.Is_Noise_Heard()&& Rhythm_Behavior.cur_rhythm_state != Rhythm_State.OUT)
                {
                    Breath_In();
                }
                else
                {
                    No_Breath();
                }   

                //if player has not previously exhaled in the cycle:
                if(!has_prev_exhaled)
                {
                    //if microphone heard a noise and current state is OUT
                    if(microphone_behavior.Is_Noise_Heard() && Rhythm_Behavior.cur_rhythm_state == Rhythm_State.OUT)
                    {
                        Breath_Out();
                    }
                }
            }

            //if breath button is pressed then...
            if(is_breath_held_down)
            {
                //if current state is IN,...
                if(Rhythm_Behavior.cur_rhythm_state == Rhythm_State.IN)
                {
                    //increase breath ammount by time
                    breath_amount += Time.deltaTime;
                }
                //else if current state is OUT,...
                else if(Rhythm_Behavior.cur_rhythm_state == Rhythm_State.OUT)
                {
                    //decrease breath amount by half of time
                    breath_amount -= Time.deltaTime / 2f;
                }
                //else if current state is PEAK_HOLD
                else if(Rhythm_Behavior.cur_rhythm_state == Rhythm_State.PEAK_HOLD)
                {
                    //increase peak hold amount
                    peak_hold_amount += Time.deltaTime;
                }
            }

            if(Rhythm_Behavior.cur_rhythm_state == Rhythm_State.TROUGH_HOLD)
            {
                //reset breath_amount
                breath_amount = 0f;

                //reset peak_hold_amount
                peak_hold_amount = 0f;

                //set has_prev_exhaled to false
                has_prev_exhaled = false;
            }
        }
    }

    public void Breath(InputAction.CallbackContext context)
    {
        //if game is NOT puased and NOT using the microphone
        if(!Pause_Menu_Behavior.is_paused && !microphone_behavior.Get_Use_Microphone())
        {
            //If spacebar held down and current state is NOT OUT:
            if(context.performed && Rhythm_Behavior.cur_rhythm_state != Rhythm_State.OUT)
            {
                //Debug.Log("Spacebar held!");
                Breath_In();
            }
            //else spacebar NOT held down:
            else
            {
                No_Breath();
            }

            //if player has not previously exhaled in the cycle:
            if(!has_prev_exhaled)
            {
                //If spacebar released:
                if(context.canceled)
                {
                    Breath_Out();
                }  
            }
        }
    }

    public void Breath_In()
    {
        //Debug.Log("Breath In");

        //set is_breath_held_down to true
        is_breath_held_down = true;

        //make breathing curcle green
        inner_circle_behavior.Color_Inner_Circle(Color.green);
    }

    public void No_Breath()
    {
        //Debug.Log("No Breath");

        //set is_breath_held_down to false
        is_breath_held_down = false;

        //make breathing circle white
        inner_circle_behavior.Color_Inner_Circle(Color.white);
    }

    public void Breath_Out()
    {
        //Debug.Log("Breath Out");

        //if current state is OUT or past 75% of PEAK_HOLD then:
        float peak_percent = (peak_hold_amount / Rhythm_Behavior.peak_hold_time) * 100f;
        if(Rhythm_Behavior.cur_rhythm_state == Rhythm_State.OUT || (Rhythm_Behavior.cur_rhythm_state == Rhythm_State.PEAK_HOLD && peak_percent >= 75f))
        {
            //move boat by percentage of breath ammount divided by in_time
            boat_behavior.Move_Boat(breath_amount / Rhythm_Behavior.in_time);

            //if current state is STRESS then...
            if(Player_State_Behavior.cur_player_state == Player_State.STRESS)
            {
                //change health by percentage of breath ammount divided by in_time
                player_state_behavior.Change_Health(breath_amount / Rhythm_Behavior.in_time);
            }

            //set breath_amount to 0f
            breath_amount = 0f;

            //set peak_hold_amount to 0f
            peak_hold_amount = 0f;

            //set has_prev_exhaled to true
            has_prev_exhaled = true;
        }
        //else the current state is PEAK_TROUGH, IN, or before 75% of PEAK_HOLD:
        else
        {
            //if use_microphone is false
            if(!microphone_behavior.Get_Use_Microphone())
            {
                //Display "Realeased to early"
                accuracy_display.Display_To_Early();
            }
        }
    }

    //Reset_Breath_Amount sets breath_amount back to zero
    public void Reset_Breath_Amount()
    {
        breath_amount = 0f;
    }
}
