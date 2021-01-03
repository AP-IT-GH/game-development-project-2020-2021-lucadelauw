using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Physics
{
    static class GravityManager
    {
        public static Vector2 Gravity { get; set; } = new Vector2(0, 0.05f);
        private static readonly Vector2 gravityMaxAcceleration = new Vector2(0, 0.5f);

        public static void ApplyGravity(ITransform obj)
        {
            obj.Acceleration += Gravity;

            if (obj.Acceleration.Y > gravityMaxAcceleration.Y)
                obj.Acceleration = gravityMaxAcceleration;
        }
    }
}
