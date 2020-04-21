using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet_Scriptt : MonoBehaviour
{
    private Rigidbody2D rb;
    public int damage = 20;
    public float bullet_speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bullet_speed;
    }

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        Destroy(gameObject);
        Patrol info = HitInfo.GetComponent<Patrol>();
        if (info != null)
        {
            info.GetHurt(damage);
        }

        Boss boss = HitInfo.GetComponent<Boss>();
        if (boss != null)
        {
            boss.GetHurt(damage);
        }
    }
}
