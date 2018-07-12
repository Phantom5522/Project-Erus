using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LookingDirection { Left, Right};

public class CatController : MonoBehaviour {

    public GameObject god;
    public float walkSpeed = 2;
    public float runSpeed = 5;  // Multiplication of walkSpeed
    public float jumpForce = 0.0005f;

    LookingDirection lookingDirectionCat = LookingDirection.Right;
    bool isWalking;
    bool isRunning;
    bool isJumping = false;
    bool isCollided;

    Rigidbody2D rb2dCat;
    Animator ani;
    InGameUI uiObject;

    void Start () {

        rb2dCat = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        uiObject = god.GetComponent<InGameUI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        // Bewegen
        float currentSpeed = walkSpeed; // Speichert die aktuelle Geschwindigkeit

        // Zurücksetzten 
        ani.SetBool("isWalking", false);
        ani.SetBool("isRunning", false);


        // Move Left
        if (Input.GetKey(KeyCode.A) && !uiObject.inMenu)
        {
            rb2dCat.velocity = new Vector2(-1 * currentSpeed, rb2dCat.velocity.y);
            Flip(LookingDirection.Left);

            ani.SetBool("isWalking", true);
        }
        // Move Right
        else if (Input.GetKey(KeyCode.D) && !uiObject.inMenu)
        {
            rb2dCat.velocity = new Vector2(currentSpeed, rb2dCat.velocity.y);
            Flip(LookingDirection.Right);

            ani.SetBool("isWalking", true);
        }
        // Keine Bewegung
        else
        {
            rb2dCat.velocity = new Vector2(0, rb2dCat.velocity.y);
        }

        if (!uiObject.inMenu)
        {
            // Running
            if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                rb2dCat.velocity = new Vector2(rb2dCat.velocity.x * runSpeed, rb2dCat.velocity.y);

                ani.SetBool("isWalking", false);
                ani.SetBool("isRunning", true);

            }

            // Jumping
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                isJumping = true;
                ani.SetBool("isJumping", true);
                rb2dCat.AddForce(new Vector2(0, jumpForce));
            }
        }

    }

    // Change View Direction of the Player
    private void Flip(LookingDirection changeTo)
    {
        if (lookingDirectionCat != changeTo)
        {
            lookingDirectionCat = changeTo;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    // 
    public void OnCollisionEnter2D(Collision2D coll)
    {
        isJumping = false;
        ani.SetBool("isJumping", false);
    }

}
