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
    
    //The following GameObject vars do NOT need to be set from inspector
    private MeshRenderer ocean_renderer;
    private Light dir_light;
    private ParticleSystem rain_particles;

    void Awake()
    {
        //find ocean_renderer
        ocean_renderer = GameObject.FindWithTag("Ocean_Tag").GetComponent<MeshRenderer>();

        //find directional light
        dir_light = GameObject.FindWithTag("Dir_Light_Tag").GetComponent<Light>();

        //find rain_particles
        rain_particles = GameObject.FindWithTag("Rain_Particles_Tag").GetComponent<ParticleSystem>();
    }

    void Start()
    {
        //Set skybox to peace_skybox
        RenderSettings.skybox = peace_skybox;

        //set ocean_renderer to peace_blue
        ocean_renderer.material = peace_blue;

        //set dir_light intensity to 1f
        dir_light.intensity = 1f;

        //in regards to rain_particles, stop all child particle systems and stop emitting 
        rain_particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void Skybox_To_Peace()
    {
        //Set skybox to peace_skybox
        RenderSettings.skybox = peace_skybox;

        //set ocean_renderer to peace_blue
        ocean_renderer.material = peace_blue;

        //set dir_light intensity to 1f
        dir_light.intensity = 1f;

        //in regards to rain_particles, stop all child particle systems and stop emitting 
        rain_particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void Skybox_To_Stress()
    {
        //Set skybox to stress_skybox
        RenderSettings.skybox = stress_skybox;

        //set ocean_renderer to peace_blue
        ocean_renderer.material = stress_blue;

        //set dir_light intensity to 1f
        dir_light.intensity = 0.25f;

        //start playing rain_particles and play all child particle systems
        rain_particles.Play(true);
    }
}
