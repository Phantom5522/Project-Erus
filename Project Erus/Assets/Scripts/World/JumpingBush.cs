using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Up = 0, Down, Left, Right };

public class JumpingBush : MonoBehaviour {

    public float jumpForce = 10f;
    public Direction direct = Direction.Up;

    private CatController playerScript;
    private Animator ani;

    void OnCollisionEnter2D(Collision2D collision)
    {

        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        playerScript = collision.collider.GetComponent<CatController>();
        ani = collision.collider.GetComponent<Animator>();

        if (rb != null)
        {
            playerScript.isJumping = true;
            ani.SetBool("isJumping", true);

            if (direct == Direction.Left || direct == Direction.Down)
                jumpForce = -1 * jumpForce;

            Vector2 velocity = rb.velocity;

            if (direct == Direction.Up || direct == Direction.Down)
                velocity.y = jumpForce;
            else
                velocity.x = jumpForce;

            rb.velocity = velocity;
        }
    }

}
