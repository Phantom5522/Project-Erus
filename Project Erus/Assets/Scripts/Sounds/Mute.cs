using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mute : MonoBehaviour, IPointerDownHandler
{
    // Inspector
    public Toggle mute;
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
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        mute.isOn = !mute.isOn;
    }

    public void ChangeImage()
    {
        if (mute.isOn)
            image.sprite = mutedSprite;
        else
            image.sprite = saveSprite;

    }

}
