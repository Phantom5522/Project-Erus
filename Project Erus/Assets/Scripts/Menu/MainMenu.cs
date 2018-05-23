using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] Panels;

    public void Show(GameObject g)
    {
        if (!g.activeSelf)
        {
            DeactivateAll();
            g.SetActive(true);
        }
        else
            DeactivateAll();
    }

    // Deaktiviert alle unter Menüs
    public void DeactivateAll()
    {
        foreach (GameObject element in Panels)
        {
            element.SetActive(false);
        }

    }


    public void NewGame()
    {
        DeactivateAll();
        SceneManager.LoadScene("Introduction");
    }

    public void ExitGame()
    {
        DeactivateAll();
        Application.Quit();
        Debug.Log("Test");
    }


}
