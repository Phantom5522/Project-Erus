using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LookingDirection { Left, Right};

public class CatController : MonoBehaviour {

    public GameObject god;
    public float walkSpeed = 2;
    public float runSpeed = 3;  // Multiplication of walkSpeed
    public float xJumpRange = 0.5f; // Multiplication to smaller the range while the character is jumping
    public float jumpForce = 750f;

    LookingDirection lookingDirectionCat = LookingDirection.Right;
    bool isWalking;
    bool isRunning;

    [HideInInspector]
    public bool isJumping = false;
    private int jumpTime = 0;

    Rigidbody2D rb2dCat;
    Animator ani;
    InGameUI uiObject;

    private float addVelocity;

    void Start () {

        rb2dCat = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        uiObject = god.GetComponent<InGameUI>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Jumping: " + isJumping);
        Debug.Log("Frame Space: " + Input.GetKey(KeyCode.Space));
    }

    private void FixedUpdate()
    {

        Debug.Log("Fixed Space: " + Input.GetKey(KeyCode.Space));

        // Bewegen
        float currentSpeed = walkSpeed; // Speichert die aktuelle Geschwindigkeit

        // Zurücksetzten 
        ani.SetBool("isWalking", false);
        ani.SetBool("isRunning", false);


        // Move Left
        if (Input.GetKey(KeyCode.A) && !uiObject.inMenu)
        {
            rb2dCat.velocity = new Vector2((-1 * currentSpeed) + (addVelocity * currentSpeed), rb2dCat.velocity.y);
            Flip(LookingDirection.Left);

            ani.SetBool("isWalking", true);
        }
        // Move Right
        else if (Input.GetKey(KeyCode.D) && !uiObject.inMenu)
        {
            rb2dCat.velocity = new Vector2(currentSpeed + (addVelocity * currentSpeed), rb2dCat.velocity.y);
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
                Jump(jumpForce);
            }
        }

        // Andere Kraft, z.B. Jump Bush
        if (addVelocity != 0)
        {
            if (addVelocity <= 1 && addVelocity >= -1)
                addVelocity = 0;
            else if (addVelocity < -1)
                addVelocity += 0.1f;
            else
                addVelocity -= 0.1f;

            Debug.Log(addVelocity);
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
    public void OnCollisionEnter2D(Collision2D coll) {

            Debug.Log("Jumping OFF");
            isJumping = false;
            ani.SetBool("isJumping", false);

    }


    public void Jump(float force, bool wait = false) {

        rb2dCat.AddForce(new Vector2(0, force));

        if (wait)
            StartCoroutine(WaitJump(0.05f, force));
        else
            StartCoroutine(WaitJump(0, force));



    }

    IEnumerator WaitJump(float sec, float force) {

        yield return new WaitForSeconds(sec);

        ani.SetBool("isJumping", true);
        isJumping = true;
        

    }

    public void XAxisForce(float speed) {

        addVelocity = speed;
        
    }
}
