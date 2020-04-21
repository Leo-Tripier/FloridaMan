using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using Object = System.Object;

public class Player_Control : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private BoxCollider2D BoxCollider;
    private CircleCollider2D CircleCollider;
    [SerializeField] private LayerMask plateformLayerMask;
    public GameObject Projectile;
    public GameObject FirePoint;
    public float jump_speed = 10f;
    public float run_speed = 5f;
    public float gravity_modifier = 0.001f;
    private bool air_jump;
    private bool grounded;
    private string orientation;
    

    // Start is called before the first frame update
    void Start()
    {
        orientation = "right";
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

        // Computing ground normal and horizontal ground movement
        Vector2 ground_normal = hit.normal;
        Vector2 move_along = new Vector2(ground_normal.y , -ground_normal.x);
        // End of normal

        // Movement test
        if (grounded)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                if (orientation == "right")
                {
                    orientation = "left";
                    transform.Rotate(0f, 180f, 0f);
                }
                
                if (Input.GetKey(KeyCode.D))
                {
                    rb2d.velocity = Vector2.zero;
                }

                rb2d.velocity = - move_along * run_speed;
            }

            else if(Input.GetKey(KeyCode.D))
            {
                if (orientation == "left")
                {
                    orientation = "right";
                    transform.Rotate (0f , 180f , 0f);
                }
                
                if (Input.GetKey(KeyCode.Q))
                {
                    rb2d.velocity = Vector2.zero;
                }

                rb2d.velocity = move_along * run_speed;
            }

            if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.D))
            {
                rb2d.velocity = Vector2.zero;
            }
        }

        else
        {
            if (Input.GetKey(KeyCode.Q))
            {
                rb2d.velocity = new Vector2(- run_speed , rb2d.velocity.y - gravity_modifier);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb2d.velocity = new Vector2(run_speed , rb2d.velocity.y - gravity_modifier);
            }

            if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.D))
            {
                rb2d.velocity -= rb2d.velocity.x * Vector2.right;
            }
        }
        // End of Movement test
        
        // Jump test
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2d.velocity += Vector2.up * jump_speed;
            grounded = false ;
            air_jump = true;
        }
        
        else if (Input.GetKeyDown(KeyCode.Space) && air_jump)
        {
            rb2d.velocity += Vector2.up * jump_speed;
            air_jump = false;
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x , 0f);
        }
        // End of jump test
        
        // Test of wall hit to prevent sticking to a wall
        RaycastHit2D left_bottom = Physics2D.Raycast(CircleCollider.bounds.center, Vector3.left,
            CircleCollider.bounds.extents.x + 0.01f, plateformLayerMask);
        RaycastHit2D left_upper = Physics2D.Raycast(BoxCollider.bounds.center, Vector2.left,
            BoxCollider.bounds.extents.x + 0.01f, plateformLayerMask);
        if ((left_bottom.collider || left_upper.collider) && !grounded)
        {
            if (rb2d.velocity.x < 0)
            {
                rb2d.velocity -= Vector2.right * rb2d.velocity.x;
            }
        }

        RaycastHit2D right_bottom = Physics2D.Raycast((CircleCollider.bounds.center), Vector2.right,
            CircleCollider.bounds.extents.x + 0.01f, plateformLayerMask);
        RaycastHit2D right_upper = Physics2D.Raycast(BoxCollider.bounds.center, Vector2.right,
            BoxCollider.bounds.extents.x + 0.01f, plateformLayerMask);
        if ((right_bottom.collider || left_upper.collider) && !grounded)
        {
            if (rb2d.velocity.x > 0)
            {
                rb2d.velocity -= Vector2.right * rb2d.velocity.x;
            }
        }
        // End Wall test
        
        // Fire Test
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(Projectile, FirePoint.transform.position, FirePoint.transform.rotation);
        }
        // End fire test
    }

    private void FixedUpdate()
    {
        
    }
}
