using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoy_Light_Behavior : MonoBehaviour
{
    //Gameobject Vars
    //the following vars must be set from the inspector
    //[SerializeField] private Material white_mat;
    [SerializeField] private Material[] light_materials;

    //the following vars DO NOT need to be set from the inspector
    private MeshRenderer buoy_mesh_renderer;

    void Awake()
    {
        //find buoy_mesh_renderer
        buoy_mesh_renderer = GameObject.Find("v1_buoy").GetComponent<MeshRenderer>();
    }

    public void Change_Buoy_Light_To_Yellow()
    {
        //make buoy light color yellow
        buoy_mesh_renderer.materials = light_materials;
    }
}
