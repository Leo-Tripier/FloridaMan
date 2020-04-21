using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class passdown : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Component is_player = other.GetComponent(typeof(Player_Control));
        if (is_player != null)
        {
            Vector3 temp = transform.position;
            
            temp.y = (-temp.y) - 1f;
            
            transform.position = temp;
            
        }
    }
}
