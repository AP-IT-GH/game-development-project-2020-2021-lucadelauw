using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Physics
{
    public class FrictionManager : IPhysicComponent
    {
        public static Vector2 Friction { get; set; } = new Vector2(20.59f, 20.59f);

        public void ApplyPhysic(ITransform transform)
        {
            float accX = transform.Acceleration.X;
            float accY = transform.Acceleration.Y;

            if (accX > Friction.X)
                accX -= Friction.X;
            else if (accX < -Friction.X)
                accX += Friction.X;
            else
                accX = 0;

            if (accY > Friction.Y)
                accY -= Friction.Y;
            else if (accY < -Friction.Y)
                accY += Friction.Y;
            else
                accY = 0;
            transform.Acceleration = new Vector2(accX, accY);
        }
    }
}
