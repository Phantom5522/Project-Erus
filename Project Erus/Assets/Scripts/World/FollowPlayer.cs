using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    public Vector2 maxDistance = new Vector2(20, 20);       // Distanz bei der 100% der Einholgeschwindigkeit erreicht wird. (without elasticStability)
    public Vector2 elasticStability = new Vector2(50, 50);  // How strong the camera should follow the object

    Rigidbody2D rBody;

    private void Start()
    {
        // Set start position
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);

        rBody = GetComponent<Rigidbody2D>();
    }

    void Update () {

        Vector2 distance = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        Vector2 distancePercent = new Vector2(Mathf.Abs(distance.x) / maxDistance.x, Mathf.Abs(distance.y) / maxDistance.y);

        // exclude unnecessary operations
        distance.x = (distance.x > 0.1F || distance.x < -0.1F) ? distance.x : 0;
        distance.y = (distance.y > 0.1F || distance.y < -0.1F) ? distance.y : 0;

        rBody.velocity = new Vector2(distance.x * distancePercent.x * elasticStability.x, distance.y * distancePercent.y * elasticStability.y);

    }
}
