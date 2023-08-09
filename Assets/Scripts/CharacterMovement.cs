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
    [SerializeField] private float max_speed;
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
        move = player_input_actions.ExploreGameplayActions.Move;
        player_input_actions.ExploreGameplayActions.Enable();
    }

    private void OnDisable()
    {
        player_input_actions.ExploreGameplayActions.Disable();
    }

    void Update()
    {
        Handle_Movement();
    }

    private void Handle_Movement()
    {
        
    }
}
