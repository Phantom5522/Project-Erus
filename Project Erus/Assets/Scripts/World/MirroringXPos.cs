using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirroringXPos : MonoBehaviour {

    public GameObject player;
    public GameObject followEmpty;
	
	// Update is called once per frame
	void Update () {

        float addDistance = (player.transform.position.x - followEmpty.transform.position.x)*2;

        transform.position = new Vector3(followEmpty.transform.position.x + addDistance, followEmpty.transform.position.y, -10f);

	}
}
