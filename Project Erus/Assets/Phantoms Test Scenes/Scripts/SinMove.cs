using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMove : MonoBehaviour {

    // Deklaration 

    public enum Direction { X = 0, Y, Z };

    // Einstellungen
    public float speed = 1.0f;                  // one cycle per Second
    public float amplitude = 1.0f;
    public Direction direction = Direction.Y;
    

    // Code
    private float add = 1.0f;
    private Vector3 oldPos;


    // Use this for initialization
    void Start () {
		
        oldPos = this.transform.position; // Speichern der alten Postion für eine Sinus-Bewegung um den voreingestellten Punkt.

    }
	
	// Update is called once per frame
    // Time.deltaTime Zeit seit dem letzten Frame
	void Update () {

        // Sinus-Bewegung eines Objektes
        Vector3 pos = this.transform.position;

        add += speed * Time.deltaTime;

        switch (direction)
        {
            case Direction.X:
                pos.x = amplitude * Mathf.Sin(add * 2 * Mathf.PI) + oldPos.x;
                break;
            case Direction.Y:
                pos.y = amplitude * Mathf.Sin(add * 2 * Mathf.PI) + oldPos.y;
                break;
            case Direction.Z:
                pos.z = amplitude * Mathf.Sin(add * 2 * Mathf.PI) + oldPos.z;
                break;
            default:
                pos.y = amplitude * Mathf.Sin(add * 2 * Mathf.PI) + oldPos.y;
                break;
        }

        this.transform.position = pos;

	}
}
