using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    //Character controller
    private CharacterController char_cont;

    //Input vars
    private PlayerInput player_input;
    private InputAction move;

    //movement vars
    [SerializeField] private float move_speed = 10f;
    private Vector3 move_dir = Vector3.zero;

    //rotation vars
    [SerializeField] private float smooth_time = 0.05f;
    private float rotation_velocity;

    //gravity vars
    [SerializeField] private float player_gravity = -10f;
    private float gravitational_velocity;

    //camera var
    public static Camera active_camera;

    void Awake()
    {
        //get new input actions
        player_input = GameObject.FindWithTag("Manager_Tag").GetComponent<PlayerInput>();

        //find character controller
        char_cont = gameObject.GetComponent<CharacterController>();
    }

    private void Start()
    {
        //set move (of type InputAction) to the "Move" action of player_input
        move = player_input.actions["Move"];

        //set active camera to 
        active_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        Handle_Rotation();

        Handle_Movement();

        Handle_Gravity();

        //Debug.Log("Active Camera is: " + active_camera.gameObject.name);
    }

    private void Handle_Movement()
    {
        //get input
        Vector2 input_dir = move.ReadValue<Vector2>();

        //determine vertical and horizontal inputs
        float vertical_input = input_dir.y;
        float horizontal_input = input_dir.x;

        //Get forward and right directions 
        Vector3 forward = active_camera.transform.forward;
        Vector3 right = active_camera.transform.right;

        //get rid of y values and re-normalize forward and right
        forward.y = 0f;
        right.y = 0f;
        forward = forward.normalized;
        right = right.normalized;

        //create direction relative input vectors
        Vector3 forward_relative_input = vertical_input * forward;
        Vector3 right_relative_input = horizontal_input * right;

        //apply direction relative movement vectors to move_dir
        move_dir.x = forward_relative_input.x + right_relative_input.x;
        move_dir.z = forward_relative_input.z + right_relative_input.z;

        //move character controller
        char_cont.Move(move_dir * move_speed * Time.deltaTime);
    }

    private void Handle_Rotation()
    {
        if(move.ReadValue<Vector2>().sqrMagnitude == 0)
            return;

        //calculate target angle
        var target_angle = Mathf.Atan2(move_dir.x, move_dir.z) * Mathf.Rad2Deg;
        // + active_camera.transform.eulerAngles.y;

        //calculate angle from target angle
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target_angle, ref rotation_velocity, smooth_time);

        //rotate player
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }

    private void Handle_Gravity()
    {
        //if player is grounded,...
        if(char_cont.isGrounded && gravitational_velocity < 0f)
        {
            //apply a little gravity
            gravitational_velocity = -1f;
        }
        //else, player is not grounded,...
        else
        {
            //calculate gravitational_velocity
            gravitational_velocity += player_gravity * Time.deltaTime;
        }
  
        //apply gravity 
        move_dir.y = gravitational_velocity;
    }
}
