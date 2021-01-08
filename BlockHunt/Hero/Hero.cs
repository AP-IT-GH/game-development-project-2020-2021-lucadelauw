using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using BlockHunt.Animation;
using BlockHunt.Input;
using BlockHunt.Commands;
using Microsoft.Xna.Framework.Content;
using BlockHunt.Physics;
using BlockHunt.Abilities;

namespace BlockHunt
{
    public class Hero : IGameObject, IPhysicsObject
    {
        private ContentManager content;
        private HeroAnimation animation;
        private IInputReader keyboardReader;
        private IInputReader mouseReader;
        private PhysicsManager phyma;

        public float Scale { get; set; } = 0.25f;

        // IPhysicsObject
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Vector2 PrevPosition { get; set; } = new Vector2(0, 0);
        public Vector2 Acceleration { get; set; } = new Vector2(0, 0);
        public Vector2 Velocity { get; set; } = new Vector2(0, 0);
        public Rectangle CollisionBox { get; set; }
        public ICollision[] Contact { get; set; } = new ICollision[4];

        public Hero(ContentManager content, IInputReader keyboard, IInputReader mouse)
        {
            this.content = content;
            animation = new HeroAnimation(content);

            CollisionBox = new Rectangle((int)(Position.X), (int)(Position.Y), (int)(319 * Scale), (int)(486 * Scale));

            keyboardReader = keyboard;
            mouseReader = mouse;
            phyma = new PhysicsManager(new List<IPhysicComponent>() { new FrictionManager(), new GravityManager() });
        }

        public void Update(GameTime gameTime)
        {
            if (Position.Y > 1080)
                new ResetCommand().Execute(this);

            // get input and excecute commands
            foreach (IGameCommand command in keyboardReader.ReadCommands())
                command.Execute(this);
            foreach (IGameCommand command in mouseReader.ReadCommands())
                command.Execute(this);

            // get input and excecute abilities
            foreach (IAbility ability in keyboardReader.ReadAbilities())
                ability.Execute();
            foreach (IAbility ability in mouseReader.ReadAbilities())
                ability.Execute();

            PrevPosition = Position;

            // Apply the physics (Gravity and Friction)
            phyma.ApplyPhysics(this);

            // Accelerate the velocity
            Velocity = Acceleration;

            // Create the new collisionbox for the next position
            CollisionBox = new Rectangle((int)(Position.X), (int)(Position.Y), (int)(319 * Scale), (int)(486 * Scale));

            CollisionHandler.Move(this, gameTime);

            CollisionBox = new Rectangle((int)(Position.X), (int)(Position.Y), (int)(319 * Scale), (int)(486 * Scale));

            animation.Update(gameTime, Position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, Scale);
        }

        public void SetHeroPosition(Vector2 position)
        {
            Position = position;
            Velocity = new Vector2(0, 0);
            Acceleration = new Vector2(0, 0);
        }
    }
}
