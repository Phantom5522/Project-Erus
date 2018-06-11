using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class InGameUI : MonoBehaviour {

    public GameObject menuCanvas;
    public Camera camera;

    // Profiles for PostProcessing
    public PostProcessingProfile normalProfile;
    public PostProcessingProfile menuProfile;

    [HideInInspector]
    public bool inMenu = false;

	void Start() {
		
	}
	
	void FixedUpdate()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            inMenu = !inMenu;

            menuCanvas.SetActive(!menuCanvas.activeSelf);

            updatePostProcessing();

        }

    }

    void updatePostProcessing()
    {
        if (inMenu)
            camera.GetComponent<PostProcessingBehaviour>().profile = menuProfile;
        else
            camera.GetComponent<PostProcessingBehaviour>().profile = normalProfile;

    }

}
