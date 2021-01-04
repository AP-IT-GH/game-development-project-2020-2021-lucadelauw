﻿using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Physics
{
    public class FrictionManager : IPhysicComponent
    {
        public static Vector2 Friction { get; set; } = new Vector2(1.02f, 1.02f);

        public void ApplyPhysic(ITransform transform)
        {
            float accX = transform.Acceleration.X;
            float accY = transform.Acceleration.Y;

            if (accX > 1)
                accX -= Friction.X;
            else if (accX < -1)
                accX += Friction.X;
            else
                accX = 0;

            if (accY > 1)
                accY -= Friction.Y;
            else if (accY < -1)
                accY += Friction.Y;
            else
                accY = 0;
            transform.Acceleration = new Vector2(accX, accY);
        }
    }
}
