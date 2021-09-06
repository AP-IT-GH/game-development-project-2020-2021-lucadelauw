using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Physics
{
    class GravityManager : IPhysicComponent
    {
        public static Vector2 Gravity { get; set; } = new Vector2(0, 30.56f);

        public void ApplyPhysic(ITransform transform)
        {
            transform.Velocity = new Vector2(transform.Velocity.X, transform.Velocity.Y + Gravity.Y);
        }
    }
}
