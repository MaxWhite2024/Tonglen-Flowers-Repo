using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//global enumerator for player states
public enum Player_State
{
    //player is either in PEACE, STRESS, or FAIL states
    PEACE = 0, STRESS = 1, FAIL = 2
} 

//Player_State_Behavior handles when different player states are triggered and what results
//This script is on the Player_Boat object which has the Player_Boat_Tag
//Note that the Player_Boat object has a trigger collider
public class Player_State_Behavior : MonoBehaviour
{
    //Gameobject vars
    private GameObject healthbar_obj;
    private Slider healthbar_slider;
    private Vector3 last_checkpoint_position;
    private Rigidbody rb;
    private Pause_Menu_Behavior pause_menu_behavior;
    private GameObject fail_menu_obj;
    private Environment_Handler environment_handler;
    private Alert_Display alert_display;
    private GameObject demo_end_menu_obj;
    private Health_Change_Display health_change_display;
    private Accuracy_Display accuracy_display;

    //number vars
    [SerializeField] public static Player_State cur_player_state = Player_State.PEACE;
    [SerializeField] private int health = 500;
    private int checkpoint_layer;
    private int scenario_trigger_layer;
    private int demo_end_layer;

    void Awake()
    {
        //get Checkpoints layer
        checkpoint_layer = LayerMask.NameToLayer("Checkpoints");

        //get ScenarioTriggers layer
        scenario_trigger_layer = LayerMask.NameToLayer("ScenarioTriggers");

        //get healthbar obj
        healthbar_obj = GameObject.FindWithTag("Healthbar_Tag");
        
        //get slider of healthbar obj
        healthbar_slider = healthbar_obj.GetComponent<Slider>();

        //set last_checkpoint_position to current player position
        last_checkpoint_position = gameObject.transform.position;

        //get rigidbody
        rb = GetComponent<Rigidbody>();

        //get pause_menu_behavior
        pause_menu_behavior = GameObject.FindWithTag("Pause_Menu_Tag").GetComponent<Pause_Menu_Behavior>();

        //get fail_menu obj
        fail_menu_obj = GameObject.FindWithTag("Fail_Menu_Tag");

        //get environment_handler
        environment_handler = GameObject.FindWithTag("Manager_Tag").GetComponent<Environment_Handler>();

        //get alert_display
        alert_display = GameObject.FindWithTag("Checkpoint_Reach_Tag").GetComponent<Alert_Display>();

        //get demo_end_menu_obj
        demo_end_menu_obj = GameObject.FindWithTag("Demo_End_Tag");

        //get demo_end_layer
        demo_end_layer = LayerMask.NameToLayer("DemoEnd");

        //get health_change_display
        health_change_display = healthbar_obj.GetComponent<Health_Change_Display>();

        //get accuracy display
        accuracy_display = GameObject.FindWithTag("Percent_Tag").GetComponent<Accuracy_Display>();
    }

    void Start()
    {
        //turn off healthbar_obj
        healthbar_obj.SetActive(false);

        //turn off fail_menu_obj
        fail_menu_obj.SetActive(false);

        //turn off demo_end_menu_obj
        demo_end_menu_obj.SetActive(false);

        //spawn the player boat
        Spawn_Player();
    }

    //Update is called once per frame
    void Update()
    {
        /*** DEBUGGING STUFF ***/
        // if(cur_player_state == Player_State.PEACE)
        //     Debug.Log("Player state is: PEACE");
        // else if(cur_player_state == Player_State.STRESS)
        //     Debug.Log("Player state is: STRESS");
        // else if(cur_player_state == Player_State.FAIL)
        //     Debug.Log("Player state is: FAIL");
        // if(Input.GetKeyDown("k"))
        //     Fail();
    }

    public void Spawn_Player()
    {
        //Resume game
        pause_menu_behavior.Resume();

        //set cur_player_state to PEACE
        cur_player_state = Player_State.PEACE;

        //hide healthbar obj
        healthbar_obj.SetActive(false);

        //hide fail_menu_obj
        fail_menu_obj.SetActive(false);

        //move player boat to last checkpoint
        gameObject.transform.position = last_checkpoint_position;

        //zero player boat's velocity and angular velocity
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        //set skybox to peace
        environment_handler.Skybox_To_Peace();
    }

    void OnTriggerEnter(Collider other_collider)
    {
        //Debug.Log("Boat touched " + other.transform.gameObject.name);

        //Perform appropraite action based on the layer of the object that was touched
        //Note that the Player_Boat can only touch checkpoints and scenario-trigger layers
        if(other_collider.transform.gameObject.layer == checkpoint_layer)
        {
            Debug.Log("Checkpoint Touched!");

            //set cur_player_state to PEACE
            cur_player_state = Player_State.PEACE;

            //hide healthbar obj
            healthbar_obj.SetActive(false);

            //set last_checkpoint_position to checkpoint's position
            last_checkpoint_position = other_collider.transform.position;

            //change light color of checkpoint
            other_collider.gameObject.GetComponent<Buoy_Light_Behavior>().Change_Buoy_Light_To_Yellow();

            //set skybox to peace
            environment_handler.Skybox_To_Peace();

            //display message on alert_display
            alert_display.Display_Alert("Checkpoint Reached");
        }
        else if(other_collider.transform.gameObject.layer == scenario_trigger_layer)
        {
            Debug.Log("Scenario Trigger Touched!");

            //set health to 500
            health = 500;

            //set cur_player_state to STRESS
            cur_player_state = Player_State.STRESS;      

            //show healthbar obj
            healthbar_obj.SetActive(true);

            //set skybox to stress
            environment_handler.Skybox_To_Stress();
        }
        else if(other_collider.transform.gameObject.layer == demo_end_layer)
        {
            //show demo end menu
            demo_end_menu_obj.SetActive(true);

            //hide healthbar obj just in case :)
            healthbar_obj.SetActive(false);
        }
        else
            Debug.Log("ERROR! Player_Boat Touched: " + other_collider.transform.gameObject.name + "! Which is of layer: " + other_collider.transform.gameObject.layer.ToString());
    }

    public void Change_Health(float change_amount)
    {
        //calculate change amount
        int true_change_amount = (int)(change_amount * 100);
        
        //if true_change_amount < min_breath_percent...
        if(true_change_amount < accuracy_display.Get_Min_Breath_Percent())
        {
            //subtract 70 from health
            health -= 70;

            //change color of health
            health_change_display.Display_Health_Down();
        }
        else
        {
            //add true_change_amount to health
            health += (int) true_change_amount;

            //change color of health
            health_change_display.Display_Health_Up();
        }

        //make sure that health is not over 1000 (max health)
        if(health > 1000)
            health = 1000;

        //update healthbar slider
        healthbar_slider.value = health;
        
        //check if player should fail (health <= 0)
        if(health <= 0)
            Fail();
    }

    public void Fail()
    {
        Debug.Log("Player has Failed!");

        //change current state to FAIL
        cur_player_state = Player_State.FAIL;

        //zero player boat's velocity and angular velocity
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        //show fail menu
        fail_menu_obj.SetActive(true);

        //hide healthbar obj just in case :)
        healthbar_obj.SetActive(false);

        //set skybox to peace
        environment_handler.Skybox_To_Peace();
    }
}
