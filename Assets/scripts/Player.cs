
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;
    public int jumpPower;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsground;
    private bool onGround;
    private int jumpCount; // this variable counts how many times the player has jumped
    private int maxJumpCount = 1; // this variable sets the maximum number of jumps allowed
    private Animator anim;
    private int facing;
    public int coins;
    public bool moveLeft , moveRight ;
    public float startx, starty;
    public GameObject Blood;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = 5;
        jumpPower = 8;
       // jumpCount = 0; // initialize the jump count to zero
        facing = 1; //this is for chenging the rotation of player when running(1 =for rigt)
        startx = transform.position.x;
        starty = transform.position.y;  
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft || Input.GetKey(KeyCode.LeftArrow))
        {
            //this is for movement {vector 2 is for 2 dimentions ;moveSpeed is for x, rb.velocity.y is for do nothing in y axis
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            anim.SetBool("Walking", true);
            if (facing==1) {
            transform.localScale=new Vector3(-1f,1f,1f);
                facing = 0;
                    }
        }
        else if (moveRight || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            anim.SetBool("Walking", true);
            if (facing == 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                facing = 1;
            }
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) /*&& jumpCount < maxJumpCount */) // check if the player can jump again
        {
            jump();
          
            //jumpCount ++ ; // increment the jump count by one
        }

    }//update

    public void jump()
    {
        if (onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsground);
       /* if (onGround) // reset the jump count when the player is on the ground
        {
            jumpCount = 0;
        }*/
    }
    public void Death()
    {
        StartCoroutine("respawndelay");
    }
    public IEnumerator respawndelay()
    {
        Instantiate(Blood, transform.position, transform.rotation); //this is for blood after deth of player
        enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);

        transform.position = new Vector2(startx, starty);

        GetComponent<Renderer>().enabled = true;
        enabled = true;
    }
}