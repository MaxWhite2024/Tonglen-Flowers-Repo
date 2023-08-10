using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable_Behavior : MonoBehaviour
{
    //Gameobject vars
    private Transform player_trans;

    //number vars
    [SerializeField] private float interact_dist;
    [SerializeField] private float cur_dist;

    //Input vars
    private Player_Input_Actions player_input_actions;
    private InputAction interact;

    void Awake()
    {
        //get new input actions
        player_input_actions = new Player_Input_Actions();

        //find player_trans
        player_trans = GameObject.FindWithTag("Player_Tag").GetComponent<Transform>();
    }

    private void OnEnable()
    {
        //set interact (of type InputAction) to the "Interact" action of ExploreGameplayActions
        interact = player_input_actions.ExploreGameplayActions.Interact;
    }

    public void Interact_With_Object(InputAction.CallbackContext context)
    {
        //calculate cur_dist
        cur_dist = Vector3.Distance(player_trans.position, transform.position);

        //if player is in range of interactable and Interact button is pressed,...
        if(cur_dist <= interact_dist && context.performed)
        {
            Debug.Log("Interacted!");
        }
    }
}
