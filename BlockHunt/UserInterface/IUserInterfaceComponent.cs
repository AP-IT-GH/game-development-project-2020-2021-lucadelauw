using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.UserInterface
{
    interface IUserInterfaceComponent
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        public bool IsClicked();
    }
}
