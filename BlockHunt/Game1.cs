using BlockHunt.Abilities;
using BlockHunt.GameState;
using BlockHunt.Input;
using BlockHunt.Level;
using BlockHunt.UserInterface;
using BlockHunt.UserInterface.HUD;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BlockHunt
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        GameStateManager gameStateManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1920,  // set this value to the desired width of your window
                PreferredBackBufferHeight = 1080   // set this value to the desired height of your window
            };
            //_graphics.ToggleFullScreen();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.ApplyChanges();


            gameStateManager = new GameStateManager(this);
            gameStateManager.SetState(GameStateManager.States.Playing);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            PlaceAbility.RectangleTexture = new Texture2D(GraphicsDevice, 1, 1);
            PlaceAbility.RectangleTexture.SetData(new[] { Color.White });

            Button.LineTexture = new Texture2D(GraphicsDevice, 1, 1);
            Button.LineTexture.SetData(new[] { Color.White });

            InitializeGameObject();
        }

        private void InitializeGameObject()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            gameStateManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            gameStateManager.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
