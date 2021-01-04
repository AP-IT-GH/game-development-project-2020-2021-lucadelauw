using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Physics
{
    class GravityManager : IPhysicComponent
    {
        public static Vector2 Gravity { get; set; } = new Vector2(0, 2.49f);

        public void ApplyPhysic(ITransform transform)
        {
            transform.Acceleration = new Vector2(transform.Acceleration.X, transform.Acceleration.Y + Gravity.Y);
        }
    }
}
