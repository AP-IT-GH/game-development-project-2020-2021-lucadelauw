using BlockHunt.Input;
using LevelDesign.LevelDesign;
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
        private Texture2D texture;
        private Color backgroundColor;
        private Random rnd;
        private double lastcall;
        private Camera camera;
        private Matrix viewMatrix;

        private Hero hero;
        Level level;

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
            // TODO: Add your initialization logic here

            rnd = new Random();
            lastcall = 0;

            level = new Level(Content);
            level.CreateWorld();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("hero");

            InitializeGameObject();
            // TODO: use this.Content to load your game content here

        }

        private void InitializeGameObject()
        {
            hero = new Hero(Content, new KeyboardReader());
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (gameTime.TotalGameTime.TotalMilliseconds > lastcall + 500)
            {
                backgroundColor = new Color(
                  rnd.Next(0, 255),
                  rnd.Next(0, 255),
                  rnd.Next(0, 255));

                lastcall = gameTime.TotalGameTime.TotalMilliseconds;
            }

            hero.Update(gameTime);
            level.Update(hero.Position);
            viewMatrix = camera.GetTransform();
            camera.MoveTo(new Vector2(-hero.Position.X, -hero.Position.Y));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, viewMatrix);
            //_spriteBatch.Begin();
            level.DrawWorld(_spriteBatch);
            hero.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
