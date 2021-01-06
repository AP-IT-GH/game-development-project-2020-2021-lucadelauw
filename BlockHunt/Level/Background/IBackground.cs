using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.Background
{
    public interface IBackground
    {
        void Update(Vector2 position);
        void Draw(SpriteBatch spriteBatch);
    }
}
