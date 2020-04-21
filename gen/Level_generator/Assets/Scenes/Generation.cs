using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level_gen
{
    public class Generation : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Room[,,,] stock = new Room[3, 3, 3, 3];
            Level current = new Level(10, 4, 5, stock);
            Room actual = current.level[current.XCurrent, current.YCurrent];
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}