using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.interfaces
{
    interface ICollision
    {
        public Rectangle CollisionBox { get; set; }
    }
}
