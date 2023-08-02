using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_Handler : MonoBehaviour
{
    //GameObject vars
    //The following GameObject vars must be set from inspector!
    [SerializeField] private Material peace_skybox;
    [SerializeField] private Material stress_skybox;
    [SerializeField] private Material peace_blue;
    [SerializeField] private Material stress_blue;
    
    [SerializeField] private TMPro.TextMeshProUGUI debug_text; 
    [SerializeField] private TMPro.TextMeshProUGUI debug_text_2; 

    [SerializeField] private GameObject part_prefab;
    private GameObject part_clone;

    //The following GameObject vars do NOT need to be set from inspector
    private Light dir_light;
    private Transform spawn_loc;

    void Awake()
    {
        //find directional light
        dir_light = GameObject.FindWithTag("Dir_Light_Tag").GetComponent<Light>();

        //find particle spawn transform
        spawn_loc = GameObject.FindWithTag("Player_Boat_Tag").transform.Find("Particle System Spawn").GetComponent<Transform>();
    }

    void Start()
    {
        //Set skybox to peace_skybox
        RenderSettings.skybox = peace_skybox;

        //set dir_light intensity to 1f
        dir_light.intensity = 1f;
    }

    public void Skybox_To_Peace()
    {
        //Set skybox to peace_skybox
        RenderSettings.skybox = peace_skybox;

        //set dir_light intensity to 1f
        dir_light.intensity = 1f;

        //if it is raining, destroy the particle system clone
        if(part_clone != null)
            Destroy(part_clone);
    }

    public void Skybox_To_Stress()
    {
        //Set skybox to stress_skybox
        RenderSettings.skybox = stress_skybox;

        //set dir_light intensity to 1f
        dir_light.intensity = 0.25f;

        //create a paticle system
        part_clone = Instantiate(part_prefab, spawn_loc.position, spawn_loc.rotation, spawn_loc);
    }
}
