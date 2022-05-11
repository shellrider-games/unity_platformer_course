using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    public SpriteRenderer _spriteRenderer;

    public float moveTime, waitTime;
    private float moveCount, waitCount;
    
    private bool movingRight;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        leftPoint.parent = null;
        rightPoint.parent = null;
        movingRight = true;
        _spriteRenderer.flipX = true;
        _animator = GetComponent<Animator>();

        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            moveCount = Mathf.Max(0, moveCount - Time.deltaTime);
            if (movingRight)
            {
                _rigidbody2D.velocity = new Vector2(moveSpeed, _rigidbody2D.velocity.y);
                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                    _spriteRenderer.flipX = false;
                }
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(-moveSpeed, _rigidbody2D.velocity.y);
                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                    _spriteRenderer.flipX = true;
                }
            }
            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
                _animator.SetBool("isMoving", false);
            }
        }
        else
        {
            waitCount = Mathf.Max(0, waitCount - Time.deltaTime);
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);

            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
                _animator.SetBool("isMoving", true);
            }
        }
    }
}
