using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.interfaces
{
    public interface ICollision
    {
        public Rectangle CollisionBox { get; set; }
    }
}
