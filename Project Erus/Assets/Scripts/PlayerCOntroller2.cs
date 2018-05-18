using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCOntroller2 : MonoBehaviour {


    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    private bool faceLeft = false;
    public float groundCheckRadius;
    public LayerMask selectGround;
    private bool grounded;
    private float moveVelocity;
    private Rigidbody2D rb;

    void Start () {}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, selectGround); 
    }

	void Update () {

        float moveX = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }

        /* Alte Bewegungssteuerung
         * 
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        */

        if (moveX > 0 && !faceLeft)
        {
            flip();
        }
        else if (moveX < 0 && faceLeft)
        {
            flip();
        }
	}
    void flip()
    {
        faceLeft = !faceLeft;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
