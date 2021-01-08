using BlockHunt.Input;
using BlockHunt.Level;
using BlockHunt.UserInterface;
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

        Texture2D placingRectangleTexture;

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


            var placingRectangleTexture = new Texture2D(GraphicsDevice, 1, 1);
            placingRectangleTexture .SetData(new[] { Color.White });

            Texture2D[] zeroToNine = new Texture2D[10];
            string path = "UserInterface/HUD/";
            zeroToNine[0]= Content.Load<Texture2D>(path + "hud_0");
            zeroToNine[1]= Content.Load<Texture2D>(path + "hud_1");
            zeroToNine[2]= Content.Load<Texture2D>(path + "hud_2");
            zeroToNine[3]= Content.Load<Texture2D>(path + "hud_3");
            zeroToNine[4]= Content.Load<Texture2D>(path + "hud_4");
            zeroToNine[5]= Content.Load<Texture2D>(path + "hud_5");
            zeroToNine[6]= Content.Load<Texture2D>(path + "hud_6");
            zeroToNine[7]= Content.Load<Texture2D>(path + "hud_7");
            zeroToNine[8]= Content.Load<Texture2D>(path + "hud_8");
            zeroToNine[9]= Content.Load<Texture2D>(path + "hud_9");
            hud = new HUD(placingRectangleTexture, zeroToNine);

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
