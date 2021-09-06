using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.World
{
    public class Enemy : IGameObject, IDamageable, ICollision
    {
        private Vector2 position;
        private Vector2 speed;

        private int y;
        private int from;
        private int to;

        private readonly float scale = 1.00f;

        public int Health { get; set; }
        public Rectangle CollisionBox { get; set; }

        private EnemyAnimation animation;

        public Enemy(int y, int from, int to, ContentManager content)
        {
            this.y = y;
            this.from = from;
            this.to = to;

            this.position = new Vector2(from, y);
            this.speed = new Vector2(1, 0);

            this.animation = new EnemyAnimation(content);
        }

        public void Update(GameTime gameTime)
        {
            position = new Vector2(position.X + speed.X, position.Y);

            animation.Update(gameTime, position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, scale);
        }
    }
}
