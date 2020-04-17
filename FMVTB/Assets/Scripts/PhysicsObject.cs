﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum EntityType
 {
     SBOEUF,
     MINIBOSS,
     MAXIBOSS,
     CROCO,
     PLAYER
 }
public class PhysicsObject : MonoBehaviour
{

    public float gravityModifier = 1f;
    public float minGroundNormalY = 0.65f;
    protected Vector2 velocity;
    protected Vector2 TargetVelocity;
    protected Rigidbody2D rb2d;
    protected Vector2 groundNormal;
    protected const float minMove = 0.001f;
    protected const float ShellRadius = 0.01f;
    protected RaycastHit2D[] HitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> HitBufferList = new List<RaycastHit2D>(16);
    protected ContactFilter2D Filter;
    protected bool grouded;
    
    private int strength;
    private bool isKo;
    protected int hp;

    #region Constructor
    
    public int Hp
    {
        get => hp;
        set => hp = value;
    }

    public int Strength
    {
        get => strength;
        set => strength = value;
    }

    public bool IsKo
    {
        get => hp <= 0;

        set
        {
            isKo = value;
            isKo = false;
        }
    }

    #endregion

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Filter.useTriggers = false;
        Filter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        Filter.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        TargetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity()
    {
        
    }

    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = TargetVelocity.x;
        Vector2 deltaPosition = velocity * Time.deltaTime;
        
        grouded = false;
        
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;
        
        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement (move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMove)
        {
           int count = rb2d.Cast(move, Filter, HitBuffer, distance + ShellRadius);
           HitBufferList.Clear();
           for (int i = 0; i < count; i++)
           {
               HitBufferList.Add(HitBuffer[i]);
           }

           for (int i = 0; i < HitBufferList.Count; i++)
           {
               Vector2 currentNormal = HitBufferList[i].normal;
               if (currentNormal.y > minGroundNormalY)
               {
                   grouded = true;
                   if (yMovement)
                   {
                       groundNormal = currentNormal;
                       currentNormal.x = 0;
                   }
               }

               float projection = Vector2.Dot(velocity, currentNormal);
               if (projection < 0)
               {
                   velocity = velocity - projection * currentNormal;
               }

               float modifiedDistance = HitBufferList[i].distance - ShellRadius;
               if (modifiedDistance < distance)
               {
                   distance = modifiedDistance;
               }
           }
        }
        
        rb2d.position = rb2d.position + move.normalized * distance;
    }
}
