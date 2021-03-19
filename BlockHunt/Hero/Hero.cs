using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using BlockHunt.Input;
using BlockHunt.Commands;
using Microsoft.Xna.Framework.Content;
using BlockHunt.Physics;
using BlockHunt.Abilities;

namespace BlockHunt.HeroNS
{
    public class Hero : IGameObject, IPhysicsObject
    {
        private readonly ContentManager content;
        private readonly HeroAnimation animation;
        private readonly IInputReader keyboardReader;
        private readonly IInputReader mouseReader;
        private readonly PhysicsManager phyma;

        public float Scale { get; set; } = 0.25f;

        // IPhysicsObject
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Vector2 PrevPosition { get; set; } = new Vector2(0, 0);
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

            string path = "UserInterface/HUD/";
            var zeroToNine = new Texture2D[10];
            zeroToNine[0] = this.content.Load<Texture2D>(path + "hud_0");
            zeroToNine[1] = this.content.Load<Texture2D>(path + "hud_1");
            zeroToNine[2] = this.content.Load<Texture2D>(path + "hud_2");
            zeroToNine[3] = this.content.Load<Texture2D>(path + "hud_3");
            zeroToNine[4] = this.content.Load<Texture2D>(path + "hud_4");
            zeroToNine[5] = this.content.Load<Texture2D>(path + "hud_5");
            zeroToNine[6] = this.content.Load<Texture2D>(path + "hud_6");
            zeroToNine[7] = this.content.Load<Texture2D>(path + "hud_7");
            zeroToNine[8] = this.content.Load<Texture2D>(path + "hud_8");
            zeroToNine[9] = this.content.Load<Texture2D>(path + "hud_9");
            PlaceAbility.ZeroToNine = zeroToNine;
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
            //Velocity = Acceleration;
            //System.Diagnostics.Debug.WriteLine("Velocity: " + Velocity);

            // Create the new collisionbox for the next position
            CollisionBox = new Rectangle((int)(Position.X), (int)(Position.Y), (int)(319 * Scale), (int)(486 * Scale));

            CollisionHandler.Move(this, gameTime);

            CollisionBox = new Rectangle((int)(Position.X), (int)(Position.Y), (int)(319 * Scale), (int)(486 * Scale));

            if (Position.Y > 2000)
                new ResetCommand().Execute(this);

            animation.Update(gameTime, Position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, Scale);
        }
    }
}
