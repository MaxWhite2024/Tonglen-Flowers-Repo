using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Param_Cube handles the behavior of the MIC TEST CUBES to give a visualization of what frequencies the player is detected by the microphone
public class Param_Cube : MonoBehaviour
{
    [SerializeField] private int band;
    [SerializeField] private float start_scale;
    [SerializeField] private float scale_multiplier;

    // Update is called once per frame
    void Update()
    {
        //change transform based on the band of the cube and volume level of the frequency associated with the band
        transform.localScale = new Vector3(transform.localScale.x, (Microphone_Behavior.freq_band[band] * scale_multiplier) + start_scale, transform.localScale.z);
    }
}
