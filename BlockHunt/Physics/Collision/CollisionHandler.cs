using BlockHunt.interfaces;
using BlockHunt.Level;
using BlockHunt.Level.World;
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
                    if (LevelManager.CollisionBoxes[i] is IDamageable && obj is IDamageable)
                    {
                        var damageAbleObj = obj as IDamageable;
                        var damageAbleBox = LevelManager.CollisionBoxes[i] as IDamageable;
                        damageAbleObj.Damage(damageAbleBox.DamageToDeal);
                        damageAbleBox.Damage(damageAbleObj.DamageToDeal);
                    }
                }
            }

            z.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            foreach (Tuple<int, float> j in z)
            {
                if (LevelManager.CollisionBoxes[j.Item1] is Portal)
                {
                    var portal = LevelManager.CollisionBoxes[j.Item1] as Portal;
                    switch (portal.GetToLevel())
                    {
                        case "Level1":
                            LevelManager.SetLevel(LevelName.Level1);
                            break;
                        case "Level2":
                            LevelManager.SetLevel(LevelName.Level2);
                            break;
                        case "Level3":
                            LevelManager.SetLevel(LevelName.Level3);
                            break;
                    }
                    break;
                }
                CollsionDetector.ResolveDynamicRectVsRect(obj, (float)gameTime.ElapsedGameTime.TotalSeconds, LevelManager.CollisionBoxes[j.Item1]);
            }

            obj.Position += obj.Velocity * new Vector2((float)gameTime.ElapsedGameTime.TotalSeconds, (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
