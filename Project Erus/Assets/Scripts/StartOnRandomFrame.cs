using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOnRandomFrame : MonoBehaviour {

    public Animator thisAnim;

	// Use this for initialization
	void Start () {
        thisAnim.Play("Rune_Fragment", -1, Random.Range(0.0f, 60.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
