using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Control : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private BoxCollider2D BoxCollider;
    private CircleCollider2D CircleCollider;
    [SerializeField] private LayerMask plateformLayerMask;
    public float jump_speed = 10f;
    public float run_speed = 5f;
    public float gravity_modifier = 0.001f;
    private bool air_jump;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        BoxCollider = transform.GetComponent<BoxCollider2D>();
        CircleCollider = transform.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Test if the object is grounded
        RaycastHit2D hit = Physics2D.Raycast(CircleCollider.bounds.center, Vector2.down, 
            CircleCollider.bounds.extents.y + 0.05f , plateformLayerMask);
        grounded = hit.collider;
        // End of the test
        
        // Jump test
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x , jump_speed);
            grounded = false;
            air_jump = true;
        }
        
        else if (Input.GetButtonDown("Jump") && air_jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x , jump_speed);
            air_jump = false;
        }

        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x , 0f);
        }
        // End of jump test
        
        // Computing ground normal and horizontal ground movement
        Vector2 ground_normal = hit.normal;
        Vector2 move_along = new Vector2(ground_normal.y , -ground_normal.x);
        // End of normal

        // Movement test
        if (grounded)
        {
            rb2d.velocity = move_along.normalized * run_speed * Input.GetAxisRaw("Horizontal");
        }

        else
        {
            rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * run_speed , rb2d.velocity.y - gravity_modifier);
        }
        // End of Movement test
    }

    private void FixedUpdate()
    {
        
    }
}
