using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.GameState
{
    class PausedState : IGameState
    {
        private bool escToggle = false;
        public void Update(GameTime gameTime, GameStateManager gameStateManager)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) || escToggle)
            {
                escToggle = true;
                if (Keyboard.GetState().IsKeyUp(Keys.Escape))
                { 
                    gameStateManager.SetState(GameStateManager.States.Playing);
                    escToggle = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw nothing
        }
    }
}
