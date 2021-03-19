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
        private readonly IGameState playingState;
        private Game game;

        public enum States
        {
            Playing,
            Paused,
        }
        private readonly ContentManager content;
        private IGameState currentState;

        public GameStateManager(Game game)
        {
            this.game = game;
            this.content = game.Content;
            this.playingState = new PlayingState(content);
        }

        public void SetState(States state)
        {
            switch(state)
            {
                case States.Playing:
                    currentState = playingState;
                    break;

                case States.Paused:
                    currentState = new PausedState(game);
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime, this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch);
        }
    }
}
