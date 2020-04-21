using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level_gen
{
    public class Level : MonoBehaviour 
    {
        public Room[,] level;
        private int x_current;
        private int y_current;

        public int XCurrent
        {
            get => x_current;
            set => x_current = value;
        }

        public int YCurrent
        {
            get => y_current;
            set => y_current = value;
        }
        public Level(int hauteur, int y_exit, int largeur, Room[,,,] stock)
        {
            
            int x = hauteur - 1;
            int y = 0;
            
            this.level = new Room[hauteur,largeur];
            this.x_current = hauteur - 1;
            this.y_current = 0;
            bool up = false;
            bool down = true;
            bool left = true;
            bool right = false;

            int a = 0;
            int b;
            int c;
            int d = 0;

            Room actual;
            
            while ((x,y) != (0, largeur - 1))
            {
                up = false;
                if (x == hauteur - 1 && y != 0) {down = false;}
                if (y == 0) {left = false;}
                right = false;

                while (!(up || right))
                {
                    if (x != 0)
                    {
                        a = Random.Range(0, 10);
                        if (a >= 5)
                        {
                            up = true;
                        }
                    }
                    else
                    {
                        a = Random.Range(0, 5);
                    }

                    if (y != largeur - 1)
                    {
                        d = Random.Range(0, 10);
                        if (d >= 5)
                        {
                            right = true;
                        }
                    }
                    else
                    {
                        d = Random.Range(0, 5);
                    }
                }
            
                if (down)
                {
                    b = Random.Range(5, 10);
                }
                else
                {
                    b = Random.Range(0, 5);
                }

                if (left)
                {
                    c = Random.Range(5, 10);
                }
                else
                {
                    c = Random.Range(0, 5);
                }
                    

                if ((x,y) == (0,y_exit))
                {
                    actual = stock[a,b,c,d];

                    level[x, y] = actual;
                    left = actual.right;
                    down = level[x + 1, y].up;
                }
                else
                {

                    actual = stock[a,b,c,d];
                    level[x, y] = actual;
                    
                    left = actual.right;
                    if (x < hauteur - 1)
                    {
                        down = level[x + 1, y].up;
                    }
                }

                if (y == largeur - 1)
                {
                    x -= 1;
                    y = 0;
                }
                else
                {
                    y += 1;
                }
            }
        }
    }
}