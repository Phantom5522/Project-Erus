using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatAnimation : MonoBehaviour {

    public float repeatSeconds;
    public string parameterNameStart;

    public float waitSeconds;
    public string parameterNameWait;

    Animator ani;

    // Use this for initialization
    void Start () {

        if (waitSeconds >= repeatSeconds)
            waitSeconds = repeatSeconds - 1;

        ani = GetComponent<Animator>();
        InvokeRepeating("activate", repeatSeconds, repeatSeconds);

	}

    private void activate()
    {
        ani.SetBool(parameterNameWait, false);
        ani.SetBool(parameterNameStart, true);
        Debug.Log("TestActivate");

        Invoke("deactivate", waitSeconds);
    }

    private void deactivate()
    {
        ani.SetBool(parameterNameStart, false);
        ani.SetBool(parameterNameWait, true);
        Debug.Log("TestDeactivate");
    }


}
