﻿using System.Collections;
using System.Collections.Generic;
 using UnityEngine;

 namespace IA
 {
     public class PlayerControl : PhysicsObject
     {
         protected SpriteRenderer render;

         public int hp = 100;
         public float TakeOfSpeed = 7;
         public float maxSpeed = 7;

         protected bool burger;
         protected bool doubleJump;
         protected bool Yeezys;
         // Start is called before the first frame update
         void Start()
         {
        
         }

         protected void OnEnable()
         {
             rb2d = GetComponent<Rigidbody2D>();
             render = GetComponent<SpriteRenderer>();
         }

         protected override void ComputeVelocity()
         {
             if (grouded)
             {
                 doubleJump = true;
             }

             Vector2 move = Vector2.zero;

             if (Input.GetKey(KeyCode.LeftShift))
             {
                 render.color = Color.red;
            
                 move.x = Input.GetAxisRaw("Horizontal") * 2;
             }
             else
             {
                 render.color = Color.white;
            
                 move.x = Input.GetAxisRaw("Horizontal");
             }

             if (Input.GetButtonDown("Jump") )
             {
                 if (grouded == false) //Deja saute une fois
                 {
                     doubleJump = false;
                     velocity.y = 1.5f * TakeOfSpeed;
                 }
                 
                 else //jamais saute
                 {
                     velocity.y = TakeOfSpeed;
                 }
             }
             else if (Input.GetButtonDown("Jump"))
             {
                 if (velocity.y > 0)
                 {
                     velocity.y = velocity.y * 0.5f;
                 }
             }

             TargetVelocity = move * maxSpeed;
         }

         protected void Burger()
         {
             if (hp < 100 & burger)
             {
                 if (hp > 75)
                 {
                     hp = 100;
                 }

                 hp += 25;
             }
         }
     }
 }
