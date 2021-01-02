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

namespace BlockHunt
{
    public class Hero:IGameObject,ITransform
    {
        private Texture2D heroTexture;
        private Animatie animation;
        private Vector2 snelheid;
        private Vector2 versnelling;
        private Vector2 mouseVector;
        private IInputReader inputReader;
        private IGameCommand moveCommand;
        private IGameCommand moveToCommand;

        public Vector2 Position { get; set; }

        public Hero(Texture2D texture, IInputReader reader)
        {
            heroTexture = texture;
            animation = new Animatie();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 180, 247)));
            animation.AddFrame(new AnimationFrame(new Rectangle(180, 0, 180, 247)));
            animation.AddFrame(new AnimationFrame(new Rectangle(360, 0, 180, 247)));
            animation.AddFrame(new AnimationFrame(new Rectangle(540, 0, 180, 247)));
            animation.AddFrame(new AnimationFrame(new Rectangle(720, 0, 180, 247)));

            snelheid = new Vector2(1, 1);
            versnelling = new Vector2(1f, 1f);

            inputReader = reader;

            moveCommand = new MoveCommand();
            moveToCommand = new MoveToCommand();
        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();
            Move(direction);
            animation.Update(gameTime);
        }

        private Vector2 GetMouseState()
        {
            MouseState state = Mouse.GetState();
            mouseVector = new Vector2(state.X, state.Y);
            return mouseVector;
        }

        private void Move(Vector2 direction)
        {
            //moveToCommand.Execute(this, GetMouseState());
            moveCommand.Execute(this, direction);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
