using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Microphone_Behavior handles input from the microphone and converts it into an array of float values representing 
// the volumnes of 8 different ranges of frequencies as long as a microphone is available to be used and 
// use_microphone is true. The object that the Microphone_Behavior component is attatched to must also have an AudioSource
// Component attatched.
[RequireComponent (typeof (AudioSource))]
public class Microphone_Behavior : MonoBehaviour
{
    /*** Audio Source vars ***/
    //audio_src: holds the AudioSource component attatched to the same object that Microphone_Behavior is attatched to
    private AudioSource audio_src;

    //samples: An array of floats containing 512 samples of audio that the microphone picks up
    private static float[] samples = new float[512];

    //freq_band: An array of floats containing the volumes of 8 frequency ranged that the microphone picks up.
    //Every frame, freq_band will be updated with the volumes of the most recent noise
    public static float[] freq_band = new float[8];

    //NOTE: the following var must be set from the inspector!:

    //noise_threshold: holds the minimum volume level that at least one of the frequency bands must reach to be registered as a noise
    //NOTE: for better results, try making this value something between 0.01 and 0.001
    [SerializeField] private float noise_threshold; 


    /*** Microphone input vars ***/
    //selected_device: holds the name of the microphone device to be used
    private string selected_device;

    //NOTE: the following vars must be set from the inspector!:

    //use_microphone: holds whether or not a microphone will be used. 
    //Via the Inspector, set use_microphone to true if you want to use a microphone and false if not
    [SerializeField] private bool use_microphone;

    //microphone_mixer_group: holds the mixer group labeled "Microphone" whose Volume is set to -80 dB.
    //Via the Inspector and "Audio Mixer" Tab, drag and drop the "Microphone" mixer group to this vairable
    [SerializeField] private AudioMixerGroup microphone_mixer_group;

    //master_mixer_group: holds the mixer group labeled "Master" whose Volume is set to 0 dB.
    //Via the Inspector and "Audio Mixer" Tab, drag and drop the "Master" mixer group to this vairable
    [SerializeField] private AudioMixerGroup master_mixer_group;

    //Awake is valled before Start
    void Awake()
    {
        //find audio source
        audio_src = GetComponent<AudioSource>();
    }

    //Start is called before the first frame update
    void Start()
    {
        //if you will use a microphone then
        if(use_microphone)
        {
            //if there is more than no microphones detected
            if(Microphone.devices.Length > 0)
            {
                //make selected device the first detected microphone
                selected_device = Microphone.devices[0].ToString();

                //set audio source mixer group to the microphone mixer group
                audio_src.outputAudioMixerGroup = microphone_mixer_group;

                //set audio source as microphone input of selected microphone
                audio_src.clip = Microphone.Start(selected_device, true, 1, AudioSettings.outputSampleRate);
            }
            //else do not use a microphone by setting use_microphone to false
            else
            {
                use_microphone = false;
            }
        }

        //if you will not use a microphone then
        if(!use_microphone)
        {
            //set audio source mixer group to the master mixer group
            audio_src.outputAudioMixerGroup = master_mixer_group;
        }

        //play audio source
        audio_src.Play();
    }

    //Update is called once per frame
    void Update()
    {
        //if microphone will be used:
        if(use_microphone)
        {
            //get the audio source spectrum
            Get_Spectrum_Audio_Source();

            //Make 8 frequency bands from spectrum
            Make_Frequency_Bands();

            /* Helpful Debugging Code: */
            // if(Is_Noise_Heard())
            // {
            //     //Debug.Log("NOISE HEARD!");
            // }
            //
            // Debug.Log("0: " + freq_band[0] + "\n" + "1: " + freq_band[1] + "\n" + "2: " + freq_band[2] + "\n" + "3: " + freq_band[3] + "\n" + "4: " + freq_band[4] + "\n" + "5: " + freq_band[5] + "\n" + "6: " + freq_band[6] + "\n" + "7: " + freq_band[7]);
        } 
    }

    //Get_Spectrum_Audio_Source gets the spectrum data from the microphone
    void Get_Spectrum_Audio_Source()
    {
        //get spectrum data from the audio_src component
        audio_src.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    // Make_Frequency_Bands converts the spectrum data into 8 frequency bands
    void Make_Frequency_Bands()
    {
        //initialize count
        int count = 0;
    
        //for all 8 frequency bands,...
        for(int i = 0; i < 8; i++)
        {
            //initialize average
            float average = 0;

            //initialize sample_count as (2^i) * 2
            int sample_count = (int)Mathf.Pow(2, i) * 2;

            //round up to complete the spectrum
            if(i == 7)
            {
                sample_count += 2;
            }

            //for every sample,...
            for(int j = 0; j < sample_count; j++)
            {
                //add to average for this frequency
                average += samples[count] * (count + 1);
                
                //increment count
                count++;
            }

            //calculate average for this frequency
            average /= count;

            //apply average to frequency band
            freq_band[i] = average * 10;
        }
    }

    // Noise_Heard returns true if the microphone detected a noise greater than the threshold value (noise_threshold)/
    // It does so by iterating through each value of freq_band and seeing if a noise louder than noise_threshold was 
    // made in that frequency band. 
    public bool Is_Noise_Heard()
    {
        //if microphone will be used,...
        if(use_microphone)
        {
            //for the length of freq_band,...
            for(int i = 0; i < freq_band.Length; i++)
            {
                //if freq_band[i] is greater than or equal to the noise_threshold,...
                if(freq_band[i] >= noise_threshold)
                {
                    //return true
                    return true;
                }
            }

            //if the freq_band was less than the noise_threshold, then return false
            return false;
        }
        //else microphone will NOT be used return false
        else
        {
            return false;
        }
    }

    //Get_Use_Microphone returns the value of use_microphone
    public bool Get_Use_Microphone()
    {
        return use_microphone;
    }
}
