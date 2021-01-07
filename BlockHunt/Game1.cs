using BlockHunt.Input;
using BlockHunt.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BlockHunt
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Camera camera;
        private Matrix viewMatrix;

        private Hero hero;
        LevelManager level;

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
            _graphics.ToggleFullScreen();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.ApplyChanges();
            camera = new Camera();
        }

        protected override void Initialize()
        {



            level = new LevelManager(Content, new Level.Definition.BlockDefinitionBuilder(), new CsvReader(ILevelReader.LEVEL1), new Level.Background.ParallaxBackground(Content));
            level.CreateWorld();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            InitializeGameObject();
        }

        private void InitializeGameObject()
        {
            hero = new Hero(Content, new KeyboardReader());
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            hero.Update(gameTime);
            level.Update(hero.Position);
            camera.MoveTo(new Vector2(-hero.Position.X, -hero.Position.Y));
            viewMatrix = camera.GetTransform();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, viewMatrix);
            level.DrawWorld(_spriteBatch);
            hero.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
