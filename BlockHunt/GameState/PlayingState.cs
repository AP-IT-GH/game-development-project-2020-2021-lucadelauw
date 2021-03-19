using BlockHunt.HeroNS;
using BlockHunt.Input;
using BlockHunt.Level;
using BlockHunt.UserInterface.HUD;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.GameState
{
    class PlayingState : IGameState
    {
        private ContentManager content;
        private Hero hero;
        private LevelManager level;
        private HUD hud;

        private Camera camera;
        public static Matrix viewMatrix;


        private bool escToggle = false;

        public PlayingState(ContentManager content)
        {
            this.content = content;

            level = new LevelManager(this.content, new Level.Definition.BlockDefinitionBuilder(), new CsvReader(ILevelReader.LEVEL1), new Level.Background.ParallaxBackground(this.content));
            level.CreateWorld();

            camera = Camera.Instance;

            hud = HUD.Instance;

            hero = new Hero(content, new KeyboardReader(), new MouseReader());
        }
        public void Update(GameTime gameTime, GameStateManager gameStateManager)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) || escToggle)
            {
                escToggle = true;
                if (Keyboard.GetState().IsKeyUp(Keys.Escape))
                {
                    gameStateManager.SetState(GameStateManager.States.Paused);
                    escToggle = false;
                }
            }
            hero.Update(gameTime);
            level.Update();
            hud.Update(gameTime);
            camera.MoveTo(-hero.Position.X);
            viewMatrix = camera.GetTransform();
            MouseReader.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Moving items
            Vector2 parallax = new Vector2(0.5f);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, viewMatrix);
            level.DrawWorld(spriteBatch);
            hero.Draw(spriteBatch);
            spriteBatch.End();

            //static items
            spriteBatch.Begin();
            hud.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
