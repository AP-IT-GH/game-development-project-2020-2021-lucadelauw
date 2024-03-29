﻿using BlockHunt.interfaces;
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

        private readonly float scale = 0.30f;

        public int Health { get; set; } = 100;
        public Rectangle CollisionBox { get; set; }
        public int DamageToDeal { get; set; } = 100;

        private EnemyAnimation animation;

        public Enemy(int y, int from, int to, ContentManager content)
        {
            this.y = y;
            this.from = from;
            this.to = to;

            this.position = new Vector2(this.from, this.y);
            this.speed = new Vector2(1.00f, 0);

            this.CollisionBox = new Rectangle((int)(position.X), (int)(position.Y), (int)(190 * scale), (int)(380 * scale));

            this.animation = new EnemyAnimation(content);
        }

        public void Update(GameTime gameTime)
        {
            position = new Vector2(position.X + speed.X, position.Y);

            if (position.X >= to || position.X <= from)
            {
                speed = new Vector2(-speed.X, speed.Y);
            }
            
            CollisionBox = new Rectangle((int)(position.X), (int)(position.Y), (int)(190 * scale), (int)(380 * scale));

            animation.Update(gameTime, position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, scale);
        }

        public void Damage(int damage)
        {
            this.Health -= damage;
        }
    }
}
