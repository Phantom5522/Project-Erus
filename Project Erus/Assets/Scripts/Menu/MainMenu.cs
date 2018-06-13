using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject backButton;

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

    public void ShowWithBack(GameObject g)
    {
        if (!g.activeSelf)
        {
            DeactivateAll();
            g.SetActive(true);
            backButton.SetActive(true);
        }
        else
            DeactivateAll();
    }

    public void Deactivate(GameObject g)
    {
        g.SetActive(false);
    }

    // Deaktiviert alle unter Menüs
    public void DeactivateAll()
    {
        foreach (GameObject element in panels)
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
    }


}
