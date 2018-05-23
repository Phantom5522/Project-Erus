using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public AudioSource audioOutput;
    public Slider masterVolumeSlider;
    public Text masterVolumeValue;

    private void Start()
    {
        #region Start Configure Graphics

        ChangedMasterVolume();


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

    #endregion

    #region Configure Keyboard


    #endregion


}
