using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    public float moveSpeed;
    public float jumpForce;
    public float bounceForce;
    public Rigidbody2D rigidBody;
    public Transform groundPoint;
    public LayerMask whatIsGround;
    
    private bool isOnGround = false;
    private bool doubleJump = true;
    
    public float knockBackDuration, knockBackForce;
    private float knockBackCounter;

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        knockBackCounter = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.instance.isPaused) return;
        if (knockBackCounter <= 0)
        {
            rigidBody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rigidBody.velocity.y);
            isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.1f, whatIsGround);
            if (isOnGround)
            {
                doubleJump = true;
            }

            if ((isOnGround || doubleJump) && Input.GetButtonDown("Jump"))
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                AudioManager.instance.playSFX(10);
                if (!isOnGround)
                {
                    doubleJump = false;
                }
            }
            if (rigidBody.velocity.x < 0) spriteRenderer.flipX = true;
            if (rigidBody.velocity.x > 0) spriteRenderer.flipX = false;
        }
        else
        {
            knockBackCounter = Mathf.Max(0.0f, knockBackCounter - Time.deltaTime);
            int dirFactor = 1;
            if (!spriteRenderer.flipX)
            {
                dirFactor = -1;
            }
            rigidBody.velocity = new Vector2(dirFactor*knockBackForce, rigidBody.velocity.y);
            if(knockBackCounter <= 0) anim.SetBool("hurt", false);
        }

        //Set properties for animator
        anim.SetFloat("xSpeed", Math.Abs(rigidBody.velocity.x));
        anim.SetFloat("ySpeed", rigidBody.velocity.y);
        
        if(transform.position.y <= LevelManager.instance.killYPos) LevelManager.instance.RespawnPlayer();
    }
    
    public void KnockBack()
    {
        knockBackCounter = knockBackDuration;
        rigidBody.velocity = new Vector2(0.0f, knockBackForce);
        anim.SetBool("hurt", true);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void ResetKnockBack()
    {
        knockBackCounter = 0.0f;
        anim.SetBool("hurt", false);
    }

    public void Bounce()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, bounceForce);
    }
}
