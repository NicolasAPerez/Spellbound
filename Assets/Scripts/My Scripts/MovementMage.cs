using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMage : MonoBehaviour
{
    public enum AirState
    {
        grounded,
        jumping,
        inAir

    }

    public AirState airS;
    public bool disable;
    public float speedMulti;
    public float jumpMulti;
    public float yVelLeniency;
    public bool leftFace;
    private float hMove;
    private bool jumpPressed;
    private Rigidbody2D body;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private 

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        jumpPressed = false;
        airS = AirState.grounded;
        //disable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!disable)
        {
            hMove = Input.GetAxisRaw("Horizontal");
            if (airS == AirState.grounded && Input.GetButtonDown("Jump"))
            {
                jumpPressed = true;
            }
        }
        else
        {
            hMove = 0;
        }
        if (jumpPressed && airS != AirState.grounded)
        {
            jumpPressed = false;
        }

        if (System.Math.Abs(hMove) > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        setDir();
        if (airS != AirState.grounded)
        {
            animator.SetBool("isGrounded", false);
            animator.SetFloat("airSpeed", body.velocity.y);
        }
        else
        {
            animator.SetBool("isGrounded", true);
        }


    }

    private void FixedUpdate()
    {
        calcMovement(hMove, jumpPressed);
    }

    void setDir()
    {
        if (hMove > 0)
        {
            leftFace = false;
            spriteRenderer.flipX = false;
        }
        else if (hMove < 0)
        {
            leftFace = true;
            spriteRenderer.flipX = true;
        }
    }


    void calcMovement(float horizontalMove, bool jump)
    {
        if (!jump)
        {
            body.velocity = new Vector2(speedMulti * horizontalMove, body.velocity.y);
        }
        else if (airS == AirState.grounded)
        {
            body.velocity = new Vector2(speedMulti * horizontalMove, jumpMulti);
            airS = AirState.jumping;
        }

        if ((airS == AirState.jumping && !jump) || (Mathf.Abs(body.velocity.y) > yVelLeniency && airS != AirState.jumping))
        {
            airS = AirState.inAir;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (airS == AirState.inAir && collision.gameObject.tag == "Ground")
        {
            airS = AirState.grounded;
        }
    }

    //Depreciated Code for Force based Movement
    //Use Velocity Based Movement instead
    /*
    void limitSpeed()
    {
        if (System.Math.Abs(body.velocity.x) > maxSpeed)
        {
            body.velocity = new Vector2(maxSpeed * ((body.velocity.x > 0) ? 1 : -1), body.velocity.y);
        }
        else
        {
            body.AddForce(hMove * speedMulti * Vector2.right);
        }
    }
    */
}
