using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelDesign.World
{
    public class Blok
    {
        public Point CollisionBox { get; set; } = new Point(32, 32);
        public Texture2D _texture { get; set; }
        public Vector2 Positie { get; set; }
        public Rectangle DestinationRectangle { get; set; }

        public Blok(Texture2D texture, Vector2 pos, Rectangle destinationRectangle)
        {
            _texture = texture;
            Positie = pos;
            DestinationRectangle = destinationRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Positie, DestinationRectangle, Color.AliceBlue);
        }
    }
}
