using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.World
{
    class Barrier : ICollision
    {
        public Rectangle CollisionBox { get; set; }
        public Vector2 Position { get; set; }

        public Barrier(Rectangle barrier)
        {
            Position = new Vector2(barrier.X, barrier.Y);
            CollisionBox = new Rectangle((int)Position.X, (int)Position.Y, barrier.Width, barrier.Height);
        }


    }
}
