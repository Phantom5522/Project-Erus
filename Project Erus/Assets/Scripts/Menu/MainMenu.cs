using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject startPanel;

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
        optionsPanel.SetActive(false);
        startPanel.SetActive(false);
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
