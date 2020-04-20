using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public int vie = 500;

    Transform player;

    public bool flip = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;

        if (transform.position.x > player.position.x && !flip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f,0f);
            flip = true;
        }
        else if (transform.position.x < player.position.x && flip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            flip = false;
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
