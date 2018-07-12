using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Up = 0, Down, Left, Right };

public class JumpingBush : MonoBehaviour {

    public float jumpForce = 750f; // For x-Movement approximately 3
    public Direction direction = Direction.Up;

    private CatController playerScript;
    private Animator ani;

    void OnCollisionEnter2D(Collision2D collision)
    {

        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        playerScript = collision.collider.GetComponent<CatController>();
        ani = collision.collider.GetComponent<Animator>();

        // Sprung von oben
        if (collision.contacts[0].normal.y == -1 && direction == Direction.Up && rb.velocity.y < 1 && rb.velocity.y > -1)
            playerScript.Jump(jumpForce, true);
        // Sprung von Unten
        else if (collision.contacts[0].normal.y == 1 && direction == Direction.Down)
            rb.AddForce(new Vector2(0, -jumpForce));
        else if (collision.contacts[0].normal.x == 1 && direction == Direction.Left)
            playerScript.XAxisForce(-jumpForce);
        else if (collision.contacts[0].normal.x == -1 && direction == Direction.Right)
            playerScript.XAxisForce(jumpForce);




    }

}
