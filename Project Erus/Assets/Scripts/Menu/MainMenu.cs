using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Test");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Introduction");
    }

}
