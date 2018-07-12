using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Up = 0, Down, Left, Right };

public class JumpingBush : MonoBehaviour {

    public float jumpForce = 500f;
    public Direction direction = Direction.Up;

    private CatController playerScript;
    private Animator ani;

    void OnCollisionEnter2D(Collision2D collision)
    {

        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        playerScript = collision.collider.GetComponent<CatController>();
        ani = collision.collider.GetComponent<Animator>();

        if (rb != null)
        {

            playerScript.Jump(jumpForce);

            /*
            if (direction == Direction.Left || direction == Direction.Down)
                jumpForce = -1 * jumpForce;

            Vector2 directVec;

            if (direction == Direction.Up || direction == Direction.Down)
                directVec = new Vector2(0, jumpForce);
            else
                directVec = new Vector2(jumpForce, 0);

            rb.AddForce(directVec);*/

            
        }
    }

}
