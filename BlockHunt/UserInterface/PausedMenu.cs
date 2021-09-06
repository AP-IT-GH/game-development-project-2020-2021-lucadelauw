using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.UserInterface
{
    class PausedMenu : IUserInterface
    {
        private readonly Game game;
        private readonly IUserInterfaceComponent exitButton;
        public PausedMenu (Game game)
        {
            this.game = game;
            exitButton = new Button(new Rectangle(860, 515, 200, 50), "Exit", game.Content);
        }
        public void Update(GameTime gameTime)
        {
            exitButton.Update(gameTime);
            if (exitButton.IsClicked())
                game.Exit();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            exitButton.Draw(spriteBatch);
        }
    }
}
