using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Boat_Behavior handles the movements of the boat based on the Input_Handler's calculations
public class Boat_Behavior : MonoBehaviour
{   
    //Gameobject vars
    private Rigidbody rb;
    private Accuracy_Display accuracy_display;

    //number vars
    [SerializeField] private float dst_multiplier; 

    void Awake()
    {
        //get rigidbody
        rb = GetComponent<Rigidbody>();

        //find Accuracy_Display
        accuracy_display = GameObject.FindWithTag("Percent_Tag").GetComponent<Accuracy_Display>();
    }

    public void Move_Boat(float dst)
    {
        //Make sure dst is not less than zero
        if(dst < 0f)
            dst = 0f;
        
        //Move boat forward by dst
        //Debug.Log((int)(dst * 100) + "% accurate!");
        rb.AddForce(transform.forward * dst * dst_multiplier);

        //Display percentage
        accuracy_display.Display_Percent(dst);
    }
}