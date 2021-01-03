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
    public class Hero:IGameObject,ITransform,ICollision
    {
        private ContentManager content;
        private HeroAnimation animation;
        private IInputReader inputReader;
        private IGameCommand moveCommand;

        public float Scale { get; set; } = 0.50f;

        // ITransform
        public Vector2 Position { get; set; }
        public Vector2 Acceleration { get; set; }
        public Vector2 Velocity { get; set; }


        // ICollision
        public Rectangle CollisionBox { get; set; }

        public Hero(ContentManager content, IInputReader reader)
        {
            this.content = content;
            animation = new HeroAnimation(content);

            Velocity = new Vector2(1, 1);
            Acceleration = new Vector2(1f, 1f);

            inputReader = reader;

            moveCommand = new MoveCommand();
        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();
            Move(direction);
            animation.Update(gameTime, Position);
            GravityManager.ApplyGravity(this);
            CollisionBox = new Rectangle((int)Position.X,(int)Position.Y,(int)(319 * Scale),(int)(486 * Scale));

            Velocity += Acceleration;
            if (!CollisionManager.CheckCollision(CollisionBox, new Rectangle(-3000, 910, 30000, 0)))
                Position += Velocity;
            else
                Velocity = Vector2.Zero;
        }

        private void Move(Vector2 direction)
        {
            moveCommand.Execute(this, direction);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, Scale);
        }
    }
}
