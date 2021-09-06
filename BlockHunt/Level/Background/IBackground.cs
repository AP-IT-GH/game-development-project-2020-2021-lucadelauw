using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.Background
{
    public interface IBackground
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
