using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    //Character controller and rigidbody
    private CharacterController char_cont;
    private Rigidbody rb;

    //Input vars
    private Player_Input_Actions player_input_actions;
    private InputAction move;

    //movement vars
    [SerializeField] private float move_speed;
    [SerializeField] private float player_gravity;
    private Vector3 move_dir = Vector3.zero;

    void Awake()
    {
        //get new input actions
        player_input_actions = new Player_Input_Actions();

        //find character controller
        char_cont = gameObject.GetComponent<CharacterController>();

        //find rigidbody
        rb = gameObject.GetComponent<Rigidbody>();
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

        Look_At();
    }

    private void Handle_Movement()
    {
        //make x direction inputs equal move_dir.x
        move_dir.x = move.ReadValue<Vector2>().x;

        //make y direction inputs equal move_dir.z
        move_dir.z = move.ReadValue<Vector2>().y;

        //add player_gravity to move_dir.y
        move_dir.y += player_gravity * Time.deltaTime;

        //move character controller
        char_cont.SimpleMove(move_dir * move_speed);
    }

    private void Look_At()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if(move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }
}
