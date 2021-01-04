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
using LevelDesign.World;
using BlockHunt.World;

namespace BlockHunt
{
    public class Hero : IGameObject, IPhysicsObject
    {
        private ContentManager content;
        private HeroAnimation animation;
        private IInputReader inputReader;
        private PhysicsManager phyma;

        public float Scale { get; set; } = 0.50f;

        // IPhysicsObject
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Vector2 PrevPosition { get; set; } = new Vector2(0, 0);
        public Vector2 Acceleration { get; set; } = new Vector2(0, 0);
        public Vector2 Velocity { get; set; } = new Vector2(0, 0);
        public Rectangle CollisionBox { get; set; }

        public Hero(ContentManager content, IInputReader reader)
        {
            this.content = content;
            animation = new HeroAnimation(content);

            CollisionBox = new Rectangle((int)(Position.X), (int)(Position.Y), (int)(319 * Scale), (int)(486 * Scale));

            inputReader = reader;
            phyma = new PhysicsManager(new List<IPhysicComponent>() { new GravityManager(), new FrictionManager() });
        }

        public void Update(GameTime gameTime)
        {
            // get input and excecute command(s)
            List<IGameCommand> commands = inputReader.ReadInput();
            foreach (IGameCommand command in commands)
                command.Execute(this);
            PrevPosition = Position;

            // Apply the physics (Gravity and Friction)
            phyma.ApplyPhysics(this);

            // Accelerate the velocity
            Velocity = Acceleration;

            // Create the new collisionbox for the next position
            System.Diagnostics.Debug.WriteLine((int)(Position.X + Velocity.X) + "   " + (int)(Position.Y + Velocity.Y) + "   " + (int)(319 * Scale) + "   " + (int)(486 * Scale));
            CollisionBox = new Rectangle((int)(Position.X), (int)(Position.Y), (int)(319 * Scale), (int)(486 * Scale));

            // Check if the next position will collide with the barrier
            Rectangle barrier = new Rectangle(-30000, 910, 60000, 30000);
            Barrier _barrier = new Barrier(barrier);

            Move.ExecuteMove(this, _barrier);

            /*
            var collision = CollisionManager.CheckCollision(CollisionBox, barrier);
            if (collision.intersect)
            {

                // If a collision is detected:
                // Determine whether the collision is on the X-axis, Y-axis or both
                if ((Velocity.X > 0 && CollisionManager.IsTouchingLeft(CollisionBox, barrier)) ||
                    (Velocity.X < 0 && CollisionManager.IsTouchingRight(CollisionBox, barrier)))
                {
                    // If collision on X-axis; set horizontal velocity to 0.
                    Velocity = new Vector2(0, Velocity.Y);
                }

                if ((Velocity.Y > 0 && CollisionManager.IsTouchingTop(CollisionBox, barrier)) ||
                    (Velocity.Y < 0 && CollisionManager.IsTouchingBottom(CollisionBox, barrier)))
                {
                    if (Velocity.Y > 0 && CollisionManager.IsTouchingTop(CollisionBox, barrier))
                        Position = new Vector2(Position.X, barrier.Top - CollisionBox.Height + 1);
                    if (Velocity.Y < 0 && CollisionManager.IsTouchingBottom(CollisionBox, barrier))
                        Position = new Vector2(Position.X, barrier.Bottom - CollisionBox.Height - 1);
                    // If collision on Y-Axis; set vertical velocity to 0.
                    Velocity = new Vector2(Velocity.X, 0);
                }

            }*/

            // Update the animation
            animation.Update(gameTime, Position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, Scale);
        }
    }
}
