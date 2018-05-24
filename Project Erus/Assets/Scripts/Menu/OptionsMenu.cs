using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer Mixer;
    public AudioSource[] audioOutputs;
    public Slider masterVolumeSlider;
    public Text masterVolumeValue;
    public Toggle mute;
    public Image mainMute;

    private void Start()
    {
        #region Start Configure Graphics

        ChangedMasterVolume();
        ChangedMute();


        #endregion

        #region Start Configure Audio


        #endregion

        #region Start Configure Keyboard


        #endregion
    }

    #region Configure Graphics


    #endregion

    #region Configure Audio

    public void ChangedMasterVolume()
    {

        masterVolumeValue.text = masterVolumeSlider.value.ToString();

        //audioOutput.volume = masterVolumeSlider.value / 100;

        Mixer.SetFloat("MasterVolume", AudioPercentToDb(masterVolumeSlider.value));



    }

    public void ChangedMute()
    {
        if (mute.isOn)
        {
            foreach (AudioSource element in audioOutputs)
            {
                element.mute = true;
            }
        }
        else
        {
            foreach (AudioSource element in audioOutputs)
            {
                element.mute = false;
            }
        }

        mainMute.GetComponent<Mute>().ChangeImage();

    }

    #endregion

    #region Configure Keyboard


    #endregion

    // Rechnet die Prozent in db um.
    private float AudioPercentToDb(float percentage)
    {
        return Mathf.Log(percentage / 100 + 0.001f) * 20;
    }

}
