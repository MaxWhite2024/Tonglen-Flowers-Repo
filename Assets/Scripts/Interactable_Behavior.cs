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
    private PlayerInput player_input;
    private InputAction interact;

    void Awake()
    {
        //get new input actions
        player_input = GameObject.FindWithTag("Manager_Tag").GetComponent<PlayerInput>();

        //find player_trans
        player_trans = GameObject.FindWithTag("Player_Tag").GetComponent<Transform>();
    }

    private void OnEnable()
    {
        //set interact (of type InputAction) to the "Interact" action of player_input
        interact = player_input.actions["Interact"];
    }

    void Update()
    {
        //if interact button is pressed,...
        if(interact.triggered)
        {
            //calculate cur_dist
            cur_dist = Vector3.Distance(player_trans.position, transform.position);

            //if player is in range of interactable,...
            if(cur_dist <= interact_dist)
            {
                Debug.Log("Interacted!");
            }
        }
    }

    // public void Interact_With_Object(InputAction.CallbackContext context)
    // {
    //     //calculate cur_dist
    //     cur_dist = Vector3.Distance(player_trans.position, transform.position);

    //     //if player is in range of interactable and Interact button is pressed,...
    //     if(cur_dist <= interact_dist && context.performed)
    //     {
    //         Debug.Log("Interacted!");
    //     }
    // }
}
