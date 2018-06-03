using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

    

    public AudioMixer Mixer;
    public AudioSource[] audioOutputs;

    // VolumeSlider & ValueText
    public Slider masterVolumeSlider;
    public Text masterVolumeValue;

    public Slider musicVolumeSlider;
    public Text musicVolumeValue;

    public Slider soundForegroundVolumeSlider;
    public Text soundForegroundVolumeValue;

    public Slider soundBackgroundVolumeSlider;
    public Text soundBackgroundVolumeValue;

    public Slider dialogVolumeSlider;
    public Text dialogVolumeValue;

    //----------------------------

    public Toggle mute;
    public Image mainMute;

    private void Start()
    {
        // Alle Werte auf den aktuellen Stand bringen

        #region Start Configure Graphics




        #endregion

        #region Start Configure Audio

        ChangedVolume("MasterVolume");
        ChangedMute();

        #endregion

        #region Start Configure Keyboard


        #endregion
    }

    #region Configure Graphics


    #endregion

    #region Configure Audio

    // Passt die Lautstärke den Slidern an
    public void ChangedVolume(string volumeType)
    {
        Text volumeValue = masterVolumeValue;
        Slider volumeSlider = masterVolumeSlider;
        
        switch (volumeType)
        {
            case "MasterVolume":
                break;
            case "MusicVolume":
                volumeValue = musicVolumeValue;
                volumeSlider = musicVolumeSlider;
                break;
            case "SoundForegroundVolume":
                volumeValue = soundForegroundVolumeValue;
                volumeSlider = soundForegroundVolumeSlider;
                break;
            case "SoundBackgroundVolume":
                volumeValue = soundBackgroundVolumeValue;
                volumeSlider = soundBackgroundVolumeSlider;
                break;
            case "DialogVolume":
                volumeValue = dialogVolumeValue;
                volumeSlider = dialogVolumeSlider;
                break;
            default:
                volumeValue = masterVolumeValue;
                volumeSlider = masterVolumeSlider;
                break;
        }

        volumeValue.text = volumeSlider.value.ToString();
        Mixer.SetFloat(volumeType, AudioPercentToDb(volumeSlider.value));
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

        if (mainMute != null)
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
