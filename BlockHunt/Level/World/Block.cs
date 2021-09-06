using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.World
{
    public class Block : ICollision
    {
        public Rectangle CollisionBox { get; set; }
        public Texture2D _texture { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle DestinationRectangle { get; set; }

        public Block(Texture2D texture, Vector2 pos, Rectangle destinationRectangle)
        {
            _texture = texture;
            Position = pos;
            CollisionBox = new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
            DestinationRectangle = destinationRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, DestinationRectangle, Color.AliceBlue);
        }
    }
}
