using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LookingDirection { Left, Right};

public class CatController : MonoBehaviour {

    public float walkSpeed = 2;
    public float runSpeed = 5;

    LookingDirection lookingDirectionCat = LookingDirection.Right;
    bool isWalking;
    bool isRunning;

    Rigidbody2D rb2dCat;
    Animator ani;

	void Start () {

        rb2dCat = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float currentSpeed = walkSpeed; // Speichert die aktuelle Geschwindigkeit

        // Bewegen

        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            rb2dCat.velocity = new Vector2(-1 * currentSpeed, rb2dCat.velocity.y);
            Flip(LookingDirection.Left);

            ani.SetBool("isWalking", true);
        }
        // Move Right
        else if (Input.GetKey(KeyCode.D))
        {
            rb2dCat.velocity = new Vector2(currentSpeed, rb2dCat.velocity.y);
            Flip(LookingDirection.Right);

            ani.SetBool("isWalking", true);
        }
        // Keine Bewegung
        else
        {
            rb2dCat.velocity = new Vector2(0, rb2dCat.velocity.y);

            ani.SetBool("isWalking", false);
            ani.SetBool("isRunning", false);
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

}
