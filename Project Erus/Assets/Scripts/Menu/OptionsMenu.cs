using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public AudioSource audioOutput;
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

        audioOutput.volume = masterVolumeSlider.value / 100;

    }

    public void ChangedMute()
    {
        if (mute.isOn)
            audioOutput.mute = true;
        else
            audioOutput.mute = false;

        mainMute.GetComponent<Mute>().ChangeImage();

    }

    #endregion

    #region Configure Keyboard


    #endregion


}
