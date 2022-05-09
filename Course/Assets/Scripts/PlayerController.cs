using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rigidBody;
    public Transform groundPoint;
    public LayerMask whatIsGround;
    
    private bool isOnGround;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rigidBody.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundPoint.position, 0.1f, whatIsGround);
        
        if(isOnGround && Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpForce);
        }
    }
}
