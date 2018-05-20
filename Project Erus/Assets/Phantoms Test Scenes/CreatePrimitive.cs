using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrimitive : MonoBehaviour {

    public PrimitiveType pType = PrimitiveType.Cube;

    public float x = 0;
    public float y = 0;
    public float z = 0;

    // Use this for initialization
    void Start () {

        GameObject pObkect = GameObject.CreatePrimitive(pType);

        pObkect.transform.position = new Vector3(x, y, z);

        pObkect.name = "Generated " + pType.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
