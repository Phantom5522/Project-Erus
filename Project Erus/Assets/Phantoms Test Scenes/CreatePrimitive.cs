using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrimitive : MonoBehaviour {

    public PrimitiveType pType = PrimitiveType.Cube;
    public bool addSinMove;

    public float x = 0;
    public float y = 0;
    public float z = 0;

    // Use this for initialization
    void Start() {

        GameObject pObject = GameObject.CreatePrimitive(pType);

        pObject.transform.position = new Vector3(x, y, z);

        pObject.name = "Generated " + pType.ToString();


        if (addSinMove)
        {
            SinMove pSin = pObject.AddComponent<SinMove>();
            pSin.amplitude = 0.5f;
            pSin.speed = 0.1f;
        }

	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
