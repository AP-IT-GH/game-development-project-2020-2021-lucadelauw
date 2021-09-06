using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.World
{
    public class Portal: ICollision
    {
        private Texture2D texture;
        private string toLevel;
        private Tuple<int, int> coords;
        private readonly float scale = 0.15f;

        public Rectangle CollisionBox { get; set; }

        public Portal(Tuple<int,int> coords, string toLevel, ContentManager content)
        {
            this.texture = content.Load<Texture2D>("WorldObjects/portal");

            this.coords = coords;
            this.toLevel = toLevel;

            CollisionBox = new Rectangle(coords.Item1, coords.Item2, (int)(806 * scale), (int)(990 * scale));
        }

        public Tuple<int,int> GetCoords()
        {
            return coords;
        }
        public string GetToLevel()
        {
            return toLevel;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(coords.Item1, coords.Item2), null, Color.White, 0.00f, new Vector2(0, 0), scale, SpriteEffects.None, 0.00f);
        }
    }
}
