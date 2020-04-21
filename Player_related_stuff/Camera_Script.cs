using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Player.transform.position + Vector3.back;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + Vector3.back;
    }
}
