using BlockHunt.Abilities;
using BlockHunt.Input;
using BlockHunt.Level;
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
        private Camera camera;
        public static Matrix viewMatrix;

        private Hero hero;
        private LevelManager level;
        private HUD hud;

        enum GameState
        {
            StartMenu,
            Loading,
            Playing,
            Paused
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 1080;   // set this value to the desired height of your window
            //_graphics.ToggleFullScreen();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.ApplyChanges();

        }

        protected override void Initialize()
        {

            level = new LevelManager(Content, new Level.Definition.BlockDefinitionBuilder(), new CsvReader(ILevelReader.LEVEL1), new Level.Background.ParallaxBackground(Content));
            level.CreateWorld();

            camera = new Camera();



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            PlaceAbility.RectangleTexture = new Texture2D(GraphicsDevice, 1, 1);
            PlaceAbility.RectangleTexture.SetData(new[] { Color.White });

            hud = HUD.Instance;
                
            InitializeGameObject();
        }

        private void InitializeGameObject()
        {
            hero = new Hero(Content, new KeyboardReader(), new MouseReader());
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            hero.Update(gameTime);
            level.Update(hero.Position);
            hud.Update(gameTime);
            camera.MoveTo(new Vector2(-hero.Position.X, 0));
            viewMatrix = camera.GetTransform();
            MouseReader.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Vector2 parallax = new Vector2(0.5f);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, viewMatrix);
            level.DrawWorld(_spriteBatch);
            hud.Draw(_spriteBatch);
            hero.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
