using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Physics
{
    // Source: https://github.com/OneLoneCoder/olcPixelGameEngine/blob/master/Videos/OneLoneCoder_PGE_Rectangles.cpp
    public class CollsionDetector
    {
        public static bool PointVsRect(Vector2 p, Rectangle r)
        {
            return (p.X >= r.X && p.Y >= r.Y && p.X < r.X + r.Width && p.Y < r.Y + r.Height);
        }

        public static bool RectVsRect(Rectangle r1, Rectangle r2)
        {
            return (r1.X < r2.X + r2.X && r1.X + r1.Width > r2.X && r1.Y < r2.Y + r2.Height && r1.Y + r1.Height > r2.Y);
        }

        public static bool RayVsRect(Vector2 ray_origin, Vector2 ray_dir, Rectangle target, ref Vector2 contact_point, ref Vector2 contact_normal, ref float t_hit_near)
        {
            contact_normal = Vector2.Zero;
            contact_point = Vector2.Zero;

            // Cache division
            Vector2 invdir = new Vector2(1.0f / ray_dir.X, 1.0f / ray_dir.Y);

            // Calculate intersections with rectangle bounding axes
            Vector2 t_near = (target.Location - ray_origin.ToPoint()).ToVector2() * invdir;
            Vector2 t_far = (target.Location.ToVector2() + target.Size.ToVector2() - ray_origin) * invdir;

            if (float.IsNaN(t_far.Y) || float.IsNaN(t_far.X)) return false;
            if (float.IsNaN(t_near.Y) || float.IsNaN(t_near.X)) return false;

            // Sort distances
            if (t_near.X > t_far.X)
            {
                var temp = t_near.X;
                t_near.X = t_far.X;
                t_far.X = temp;
            }
            if (t_near.Y > t_far.Y)
            {
                var temp = t_near.Y;
                t_near.Y = t_far.Y;
                t_far.Y = temp;
            }

            // Early rejection		
            if (t_near.X > t_far.Y || t_near.Y > t_far.X) return false;

            // Closest 'time' will be the first contact
            t_hit_near = Math.Max(t_near.X, t_near.Y);

            // Furthest 'time' is contact on opposite side of target
            float t_hit_far = Math.Min(t_far.X, t_far.Y);

            // Reject if ray direction is pointing away from object
            if (t_hit_far < 0)
                return false;

            // Contact point of collision from parametric line equation
            contact_point = ray_origin + t_hit_near * ray_dir;

            if (t_near.X > t_near.Y)
                if (ray_dir.X < 0)
                    contact_normal = new Vector2(1, 0);
                else
                    contact_normal = new Vector2(-1, 0);
            else if (t_near.X < t_near.Y)
                if (ray_dir.Y < 0)
                    contact_normal = new Vector2(0, 1);
                else
                    contact_normal = new Vector2(0, -1);

            // Note if t_near == t_far, collision is principly in a diagonal
            // so pointless to resolve. By returning a CN={0,0} even though its
            // considered a hit, the resolver wont change anything.
            return true;
        }

        public static bool DynamicRectVsRect(IPhysicsObject obj, float fElapsedTime, ICollision target, ref Vector2 contact_point, ref Vector2 contact_normal, ref float contact_time)
        {
            contact_point = Vector2.Zero;
            contact_normal = Vector2.Zero;
            contact_time = 0.0f;
            // Check if dynamic rectangle is actually moving - we assume rectangles are NOT in collision to start
            if (obj.Velocity.X == 0 && obj.Velocity.Y == 0)
            {
                return false; 
            }

            // Expand target rectangle by source dimensions
            Vector2 objHalfSize = new Vector2(obj.CollisionBox.Size.X / 2, obj.CollisionBox.Size.Y / 2);
            Rectangle expanded_target = new Rectangle(); ;
            expanded_target.Location = new Point(target.CollisionBox.Location.X - obj.CollisionBox.Size.X / 2, target.CollisionBox.Location.Y - obj.CollisionBox.Size.Y / 2);
            expanded_target.Size = target.CollisionBox.Size + obj.CollisionBox.Size;

            if (RayVsRect(obj.Position + objHalfSize, obj.Velocity * fElapsedTime, expanded_target, ref contact_point, ref contact_normal, ref contact_time))
                return (contact_time >= 0.0f && contact_time < 1.0f);
            else
                return false;
        }

        public static bool ResolveDynamicRectVsRect(IPhysicsObject obj, float fTimeStep, ICollision collision)
        {
            Vector2 contact_point = Vector2.Zero;
            Vector2 contact_normal = Vector2.Zero;
            float contact_time = 0.0f;
            if (DynamicRectVsRect(obj, fTimeStep, collision, ref contact_point, ref contact_normal, ref contact_time))
            {
                if (contact_normal.Y > 0)
                {
                    obj.Contact[0] = collision;
                }
                else obj.Contact[0] = null;

                if (contact_normal.X > 0)
                {
                    obj.Contact[1] = collision;
                }
                else obj.Contact[1] = null;

                if (contact_normal.Y < 0)
                {
                    obj.Contact[2] = collision;

                }
                else obj.Contact[2] = null;

                if (contact_normal.X > 0)
                {
                    obj.Contact[3] = collision;
                }
                else obj.Contact[3] = null;

                obj.Velocity += contact_normal * new Vector2(Math.Abs(obj.Velocity.X), Math.Abs(obj.Velocity.Y)) * (1 - contact_time);
                return true;
            }
            else
            return false;
        }
    }
}
