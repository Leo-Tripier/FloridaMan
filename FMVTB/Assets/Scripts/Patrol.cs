using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class Patrol : MonoBehaviour
{
    public float speed;
    public int vie = 60;
    
    private Vector2 target;
    private Vector2 right;
    private Vector2 left;
    
    private float waitTime;
    public float startWaitTime;
    
    private Transform cible;
    private GameObject enemy;
    private Rigidbody2D rb;

    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        waitTime = startWaitTime;
        var position = enemy.transform.position;
        
        right = new Vector2(position.x + 50.0f,position.y);
        left = new Vector2(position.x - 50.0f,position.y);
        target = left;
        cible = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(enemy.transform.position, right) < 0.2f)
        {
            if (waitTime <= 0)
            {
                target = left;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Vector2.Distance(enemy.transform.position, left) < 0.2f)
        {
            if (waitTime <= 0)
            {
                target = right;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    
    public void GetHurt(int damage)
    {
        vie -= damage;

        if (vie <= 0)
        {
            Destroy(gameObject);
        }
    }


}
