using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using BlockHunt.Animation;
using Microsoft.Xna.Framework.Input;
using BlockHunt.Input;
using BlockHunt.Commands;
using Microsoft.Xna.Framework.Content;
using BlockHunt.Physics;

namespace BlockHunt
{
    public class Hero : IGameObject, ITransform, ICollision
    {
        private ContentManager content;
        private HeroAnimation animation;
        private IInputReader inputReader;

        public float Scale { get; set; } = 0.50f;

        // ITransform
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Vector2 PrevPosition { get; set; } = new Vector2(0, 0);
        public Vector2 Acceleration { get; set; } = new Vector2(0, 0);
        public Vector2 Velocity { get; set; } = new Vector2(0, 0);


        // ICollision
        public Rectangle CollisionBox { get; set; }

        public Hero(ContentManager content, IInputReader reader)
        {
            this.content = content;
            animation = new HeroAnimation(content);

            Rectangle CollisionBox = new Rectangle((int)(Position.X), (int)(Position.Y), (int)(319 * Scale), (int)(486 * Scale));

            inputReader = reader;
        }

        public void Update(GameTime gameTime)
        {
            // get input and excecute command(s)
            List<IGameCommand> commands = inputReader.ReadInput();
            foreach (IGameCommand command in commands)
                command.Execute(this);
            PrevPosition = Position;
            // Add gravity to the acceleration
            GravityManager.ApplyGravity(this);

            // Subtract the friction
            FrictionManager.ApplyFriction(this);

            // Accelerate the velocity
            Velocity = Acceleration;

            // Create a temporary collisionbox simulating the next position
            Rectangle CollisionBox = new Rectangle((int)(Position.X + Velocity.X), (int)(Position.Y), (int)(319 * Scale), (int)(486 * Scale));

            // Check if the next position will collide with the barrier
            Rectangle barrier = new Rectangle(-30000, 910, 60000, 30000);
            var collision = CollisionManager.CheckCollision(CollisionBox, barrier);
            if (collision.intersect)
            {

                // If a collision is detected:
                // Determine whether the collision is on the X-axis, Y-axis or both
                if ((Velocity.X > 0 && CollisionManager.IsTouchingLeft(CollisionBox, barrier)) ||
                    (Velocity.X < 0 && CollisionManager.IsTouchingRight(CollisionBox, barrier)))
                {
                    Velocity = new Vector2(0, Velocity.Y);
                }

                if ((Velocity.Y > 0 && CollisionManager.IsTouchingTop(CollisionBox, barrier)) ||
                    (Velocity.Y < 0 && CollisionManager.IsTouchingBottom(CollisionBox, barrier)))
                {
                    Velocity = new Vector2(Velocity.X, 0);
                }

            }

            Position += Velocity;

            // Update the animation
            animation.Update(gameTime, Position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, Scale);
        }
    }
}
