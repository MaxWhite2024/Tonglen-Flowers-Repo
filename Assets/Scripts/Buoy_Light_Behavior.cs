using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoy_Light_Behavior : MonoBehaviour
{
    //Gameobject Vars
    //the following vars must be set from the inspector
    [SerializeField] private Material[] light_materials;
    [SerializeField] private GameObject Shimmer_Prefab;
    //the following vars do NOT need to be set from the inspector
    private Transform shimmer_spawn_trans;

    //the following vars DO NOT need to be set from the inspector
    [SerializeField] private MeshRenderer buoy_mesh_renderer;

    void Awake()
    {
        //find buoy_mesh_renderer
        buoy_mesh_renderer = gameObject.transform.Find("v1_buoy").GetComponent<MeshRenderer>();

        //find shimmer_spawn_trans
        shimmer_spawn_trans = gameObject.transform.Find("v1_buoy").Find("Shimmer Spawnpoint");
    }

    public void Change_Buoy_Light_To_Yellow()
    {
        //make buoy light color yellow
        buoy_mesh_renderer.materials = light_materials;

        //spawn shimmer
        StartCoroutine(Spawn_Shimmer());
    }

    IEnumerator Spawn_Shimmer()
    {
        //spawn shimmer
        GameObject clone = Instantiate(Shimmer_Prefab, shimmer_spawn_trans.position, shimmer_spawn_trans.rotation, shimmer_spawn_trans);

        //wait 2 seconds
        yield return new WaitForSeconds(2f);

        //destroy shimmer
        Destroy(clone);
    }
}
