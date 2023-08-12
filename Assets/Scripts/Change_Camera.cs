using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Camera : MonoBehaviour
{
    //Gameobject vars
    [SerializeField] private GameObject old_camera;
    [SerializeField] private GameObject new_camera;

    void OnTriggerEnter(Collider other_collider)
    {
        //if the collider that touched this trigger is the player,...
        if(other_collider.CompareTag("Player_Tag"))
        {
            //turn off old_camera
            old_camera.SetActive(false);

            //turn on new_camera
            new_camera.SetActive(true);
        }
    } 
}
