using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.Background
{
    public class BackgroundLayer
    {
        public Texture2D texture { get; }
        public Rectangle sourceRectangle { get; }
        public Rectangle positionRectangle { get; set; }

        public BackgroundLayer(Texture2D texture, Rectangle sourceRectangle)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
        }
    }
}
