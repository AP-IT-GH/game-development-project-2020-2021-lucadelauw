using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.GameState
{
    class GameStateManager
    {
        private List<IGameState> states;
        private ContentManager content;
        private IGameState currentState;

        public GameStateManager(ContentManager content)
        {
            states = new List<IGameState>();
            this.content = content;
        }

        public void setState(IGameState state)
        {
            if (states.Contains(state))
                currentState = state;
            else
                throw new Exception("Selected gamestate not initialized");
        }

        public void AddState(IGameState state)
        {
            states.Add(state);
        }

        public void RemoveState(IGameState state)
        {
            states.Remove(state);
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch);
        }
    }
}
