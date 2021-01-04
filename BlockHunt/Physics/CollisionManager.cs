using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt
{
    static class CollisionManager
    {
        public static (bool intersect, Rectangle intersectionArea) CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            bool intersect = false;
            Rectangle intersectionArea = Rectangle.Intersect(rect1, rect2);
            if (intersectionArea.Height >= 1 || intersectionArea.Width >= 1)
                intersect = true;
            
            return (intersect, intersectionArea);
        }

        public static bool IsTouchingLeft(Rectangle rect1, Rectangle rect2)
        {
            return rect1.Right > rect2.Left &&
                rect1.Left < rect2.Left &&
                rect1.Bottom > rect2.Top &&
                rect1.Top < rect2.Bottom;
        }
        public static bool IsTouchingRight(Rectangle rect1, Rectangle rect2)
        {
            return rect1.Left < rect2.Right &&
                rect1.Right > rect2.Right &&
                rect1.Bottom > rect2.Top &&
                rect1.Top < rect2.Bottom;
        }
        public static bool IsTouchingTop(Rectangle rect1, Rectangle rect2)
        {
            return rect1.Bottom > rect2.Top &&
                rect1.Top < rect2.Top &&
                rect1.Right > rect2.Left &&
                rect1.Left < rect2.Right;
        }
        public static bool IsTouchingBottom(Rectangle rect1, Rectangle rect2)
        {
            return rect1.Top < rect2.Bottom &&
                rect1.Bottom > rect2.Bottom &&
                rect1.Right > rect2.Left &&
                rect1.Left < rect2.Right;
        }
    }
}
