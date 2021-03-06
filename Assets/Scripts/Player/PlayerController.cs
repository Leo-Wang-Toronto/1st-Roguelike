﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    //private Rigidbody2D playerRb;

    [SerializeField] float speed;

    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        // want to keep character between scene changes
        DontDestroyOnLoad(this);
        animator = GetComponent<Animator>();
        // playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        /*playerRb.MovePosition(playerRb.position + direction * speed * Time.fixedDeltaTime);*/
    }

    private void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        direction = direction.normalized;

        /*direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");*/
        if (direction != Vector2.zero)
        {
            SetAnimatorMovement();
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
        
    }

    private void SetAnimatorMovement()
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);

        // print(animator.GetFloat("xDir"));
    }
}
