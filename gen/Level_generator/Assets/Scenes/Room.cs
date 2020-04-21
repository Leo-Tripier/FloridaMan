using System;
using System.IO;
using UnityEngine;

namespace Level_gen
{
    public class Room : MonoBehaviour
    {
        public bool up;
        public bool down;
        public bool left;
        public bool right;
        public UnityEngine.Object room;

        public Room(bool up, bool down, bool left, bool right, string path)
        {
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
            this.room = Resources.Load(path);
        }
    }
}