using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    //Character controller var
    private CharacterController char_cont;

    //Input vars
    private Player_Input_Actions player_input_actions;
    private InputAction move;

    //movement vars
    [SerializeField] private float move_speed;
    private Vector3 move_dir = Vector3.zero;

    void Awake()
    {
        //get new input actions
        player_input_actions = new Player_Input_Actions();

        //find character controller
        char_cont = gameObject.GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        //set move (of type InputAction) to the "Move" action of ExploreGameplayActions
        move = player_input_actions.ExploreGameplayActions.Move;

        //enable ExploreGameplayActions 
        player_input_actions.ExploreGameplayActions.Enable();
    }

    private void OnDisable()
    {
        //disable ExploreGameplayActions
        player_input_actions.ExploreGameplayActions.Disable();
    }

    void Update()
    {
        Handle_Movement();
    }

    private void Handle_Movement()
    {
        //add x direction inputs to move_dir.x
        move_dir.x = move.ReadValue<Vector2>().x;

        //add y direction inputs to move_dir.z
        move_dir.z = move.ReadValue<Vector2>().y;

        //move character controller
        char_cont.SimpleMove(move_dir * move_speed);
    }
}