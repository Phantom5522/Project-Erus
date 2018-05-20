using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {

    public enum Axis { X = 0, Y, Z };

    // Einstellungen
    public float speed = 10f;       // angle per second
    public Axis axis = Axis.Y;


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {


        Vector3 rot = new Vector3();

        
        switch (axis)
        {
            case Axis.X:
                rot.x = speed * Time.deltaTime;
                break;
            case Axis.Y:
                rot.y = speed * Time.deltaTime;
                break;
            case Axis.Z:
                rot.z = speed * Time.deltaTime;
                break;
            default:
                rot.y = speed * Time.deltaTime;
                break;
        }

        this.transform.Rotate(rot);
        
         

    } 

}
