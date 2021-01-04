using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Physics
{
    class Move
    {
        public static void ExecuteMove(IPhysicsObject obj, ICollision collision)
        {

            if ((obj.Velocity.X > 0 && CollisionManager.IsTouchingLeft(obj.CollisionBox, collision.CollisionBox)))
            {
                obj.Position = new Vector2(collision.CollisionBox.Left - obj.CollisionBox.Width - 1, obj.Position.X);
                obj.Velocity = new Vector2(0, obj.Velocity.Y);
            }
            if (obj.Velocity.X < 0 && CollisionManager.IsTouchingRight(obj.CollisionBox, collision.CollisionBox))
            {
                obj.Position = new Vector2(collision.CollisionBox.Right - obj.CollisionBox.Width + 1, obj.Position.X);
                obj.Velocity = new Vector2(0, obj.Velocity.Y);
            }


            if (obj.Velocity.Y > 0 && CollisionManager.IsTouchingTop(obj.CollisionBox, collision.CollisionBox))
            {
                obj.Position = new Vector2(obj.Position.X, collision.CollisionBox.Top - obj.CollisionBox.Height + 1);
                obj.Velocity = new Vector2(obj.Velocity.X, 0);
            }

            if (obj.Velocity.Y < 0 && CollisionManager.IsTouchingBottom(obj.CollisionBox, collision.CollisionBox))
            {
                obj.Position = new Vector2(obj.Position.X, collision.CollisionBox.Bottom - obj.CollisionBox.Height - 1);
                obj.Velocity = new Vector2(obj.Velocity.X, 0);
            }

            obj.Position += obj.Velocity;

        }
    }
}
