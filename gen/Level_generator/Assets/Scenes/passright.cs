using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passright : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Component is_player = other.GetComponent(typeof(Player_Control));
        if (is_player != null)
        {
            Vector3 temp = transform.position;
            
            temp.x = (-temp.x) + 1f;
            
            transform.position = temp;
        }
    }
}
