using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float jumpHeight;
    private Rigidbody2D rb;
    private bool faceLeft = false;
    


	void Start () {
        rb = GetComponent<Rigidbody2D>();  
	}

	void Update () {

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector2.up * 10000);
        }
        

		float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX*speed * Time.deltaTime);
        
        

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

}
