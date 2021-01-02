using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.LevelDesign.Background
{
    public interface IBackground
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
