using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mute : MonoBehaviour, IPointerDownHandler
{
    // Inspector
    public bool isMuted = false;
    public AudioSource soundSource;
    public Sprite mutedSprite;

    // private
    Image image;
    Sprite saveSprite;

    // Use this for initialization
    void Start()
    {
        // Get Image and Save the current Sprite
        image = GetComponent<Image>();
        saveSprite = image.sprite;

        if (isMuted)
            SpeakerOff();
	}

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        isMuted = !isMuted;

        if (isMuted)
            SpeakerOff();
        else
            SpeakerOn();

    }

    private void SpeakerOn()
    {
        image.sprite = saveSprite;
        soundSource.mute = false;
    }

    private void SpeakerOff()
    {
        image.sprite = mutedSprite;
        soundSource.mute = true;
    }

}
