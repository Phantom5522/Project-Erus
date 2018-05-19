using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {

    public enum Direction { X = 0, Y, Z };

    // Einstellungen
    public float speed = 0.5f;
    public Direction direction = Direction.Y;

    // Code
    private float add = 1.0f;
    private Quaternion oldRot;

    // Use this for initialization
    void Start () {

        oldRot = this.transform.rotation; // Speichern der alten Rotation

    }
	
	// Update is called once per frame
	void Update () {
		
        Quaternion rot = this.transform.rotation;

        add += speed * Time.deltaTime;

        switch (direction)
        {
            case Direction.X:
                rot.x = add;
                break;
            case Direction.Y:
                rot.y = add;
                break;
            case Direction.Z:
                rot.z = add;
                break;
            default:
                rot.y = add;
                break;
        }

        this.transform.rotation = rot;

    }
}
