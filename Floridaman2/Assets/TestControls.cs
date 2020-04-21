using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControls : MonoBehaviour
{
    private Animator animator;

    private Rigidbody2D rigid;

    private SpriteRenderer render;

    public bool isGrounded;
    public LayerMask groundLayers;

    public int badCoolDown;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        badCoolDown = 0;

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 1.04f, transform.position.y - 1.04f),
            new Vector2(transform.position.x + 1.04f, transform.position.y - 1.04f), groundLayers);
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigid.velocity = new Vector2(3,rigid.velocity.y);
            render.flipX = false;
        }
        else if (Input.GetKey("q") || Input.GetKey("left"))
        {
            rigid.velocity = new Vector2(-3,rigid.velocity.y);
            render.flipX = true;
        }
        else
        {
            rigid.velocity = new Vector2(0,rigid.velocity.y);
        }
        if ((Input.GetKey("space")||Input.GetKey("up")) && isGrounded)
        {
            rigid.velocity = new Vector2(rigid.velocity.x,4);
        }

        if (Input.GetKey("shift") && badCoolDown <= 0)
        {
            rigid.velocity = new Vector2(rigid.velocity.x * 3, rigid.velocity.y);
            badCoolDown = 60;    
        }

        badCoolDown -= 1;
    }
}
