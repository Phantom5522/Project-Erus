using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour {

    public GameObject menuCanvas;

    [HideInInspector]
    public bool inMenu = false;

	void Start () {
		
	}
	
	void FixedUpdate () {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            inMenu = !inMenu;

            menuCanvas.SetActive(!menuCanvas.activeSelf);

        }


    }
}
