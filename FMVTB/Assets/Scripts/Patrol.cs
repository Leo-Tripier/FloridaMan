using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class Patrol : MonoBehaviour
{
    public float speed;
    //public Transform[] moveSpots;
    //private int randomSpot;
    private Vector2 target;
    private Vector2 right;
    private Vector2 left;
    private float waitTime;
    public float startWaitTime;

    void Start()
    {
        waitTime = startWaitTime;
        //Random rnd = new Random();
        //randomSpot = rnd.Next(0, moveSpots.Length);
        right = new Vector2(transform.position.x + 50.0f,transform.position.y);
        left = new Vector2(transform.position.x -  50.0f,transform.position.y);
        target = right;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);

        if (Vector2.Distance(transform.position,right) < 0.2f)
        {
            if (waitTime <= 0)
            {
                Random rnd = new Random();
                target = left;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
        if (Vector2.Distance(transform.position,left) < 0.2f)
        {
            if (waitTime <= 0)
            {
                Random rnd = new Random();
                target = right;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
