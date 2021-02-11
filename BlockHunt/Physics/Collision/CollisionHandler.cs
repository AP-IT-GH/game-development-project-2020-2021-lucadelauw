using BlockHunt.interfaces;
using BlockHunt.Level;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Physics
{
    // Source: https://github.com/OneLoneCoder/olcPixelGameEngine/blob/master/Videos/OneLoneCoder_PGE_Rectangles.cpp
    class CollisionHandler
    {
        public static void Move(IPhysicsObject obj, GameTime gameTime)
        {
            Vector2 cp = Vector2.Zero;
            Vector2 cn = Vector2.Zero;
            float ct = 0, min_t = float.PositiveInfinity;
            List<Tuple<int, float>> z = new List<Tuple<int, float>>();
            for (int i = 0; i < LevelManager.CollisionBoxes.Count; i++)
            {
                if (CollsionDetector.DynamicRectVsRect(obj, (float)gameTime.ElapsedGameTime.TotalSeconds, LevelManager.CollisionBoxes[i], ref cp, ref cn, ref ct))
                {
                    z.Add(new Tuple<int, float>(i, ct));
                }
            }

            z.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            foreach (Tuple<int, float> j in z)
            {
                CollsionDetector.ResolveDynamicRectVsRect(obj, (float)gameTime.ElapsedGameTime.TotalSeconds, LevelManager.CollisionBoxes[j.Item1]);
            }

            obj.Position += obj.Velocity * new Vector2((float)gameTime.ElapsedGameTime.TotalSeconds, (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
