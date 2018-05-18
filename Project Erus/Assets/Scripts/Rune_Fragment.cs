using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune_Fragment : MonoBehaviour {

    public int pointsToAdd;

    void OnTriggerEnter2D(Collider2D other)
    { 
        Destroy(gameObject);
    }
}
