using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.GameState
{
    interface IGameState
    {
        public void Update(GameTime gameTime, GameStateManager gameStateManager);
        public void Draw(SpriteBatch spriteBatch);
    }
}
