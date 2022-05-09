using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rigidBody;
    public Transform groundPoint;
    public LayerMask whatIsGround;
    
    private bool isOnGround = false;
    private bool doubleJump = true;

    private Animator anim;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rigidBody.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.1f, whatIsGround);
        if (isOnGround)
        {
            doubleJump = true;
        }
        if((isOnGround || doubleJump) && Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpForce);
            if (!isOnGround)
            {
                doubleJump = false;
            }
        }
        
        //Set properties for animator
        anim.SetFloat("xSpeed", Math.Abs(rigidBody.velocity.x));
        anim.SetFloat("ySpeed", rigidBody.velocity.y);
        
        //determine Sprite Render flip
        if (rigidBody.velocity.x < 0) spriteRenderer.flipX = true;
        if (rigidBody.velocity.x > 0) spriteRenderer.flipX = false;

    }
}
