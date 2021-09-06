using BlockHunt.HeroNS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace BlockHunt.Level.World
{
    class EnemyAnimation
    {
        private ContentManager content;
        private GameTime gameTime;

        public AnimationFrame CurrentFrame { get; set; }
        public Rectangle sourceRectangle { get; }
        private Vector2 position;
        private Vector2 prevPosition;
        private List<AnimationFrame> frames_walk;
        private int counter;
        private Double lastTime = 0;
        private bool toFlip;
        public EnemyAnimation(ContentManager content)
        {
            this.content = content;

            frames_walk = new List<AnimationFrame>();

            InitzializeContent();
        }

        private void InitzializeContent()
        {
            frames_walk.Add(new AnimationFrame(content.Load<Texture2D>("WorldObjects/Enemy/Walk1")));
            frames_walk.Add(new AnimationFrame(content.Load<Texture2D>("WorldObjects/Enemy/Walk2")));
            frames_walk.Add(new AnimationFrame(content.Load<Texture2D>("WorldObjects/Enemy/Walk3")));
            frames_walk.Add(new AnimationFrame(content.Load<Texture2D>("WorldObjects/Enemy/Walk4")));
            frames_walk.Add(new AnimationFrame(content.Load<Texture2D>("WorldObjects/Enemy/Walk5")));
            frames_walk.Add(new AnimationFrame(content.Load<Texture2D>("WorldObjects/Enemy/Walk6")));
        }

        public void Update(GameTime gameTime, Vector2 position)
        {
            this.position = position;
            this.gameTime = gameTime;

            // Decide whether the texture should be flipped

            if (position.X < prevPosition.X)
                toFlip = true;
            else
                toFlip = false;

            prevPosition = position;
            UpdateThis(frames_walk, true);
        }

        private void UpdateThis(List<AnimationFrame> frames, bool toLoop)
        {
            CurrentFrame = frames[counter];

            if (gameTime.TotalGameTime.TotalMilliseconds > (1000 / 12) + lastTime)
            {
                counter++;
                lastTime = gameTime.TotalGameTime.TotalMilliseconds;
            }

            if (counter >= frames.Count)
            {
                if (toLoop)
                    counter = 0;
                else
                    counter--;
            }
        }

        public void Draw(SpriteBatch spriteBatch, float scale)
        {
            if (toFlip)
                spriteBatch.Draw(CurrentFrame.Texture, position, null, Color.White, 0.00f, new Vector2(0, 0), scale, SpriteEffects.FlipHorizontally, 0.00f);
            else
                spriteBatch.Draw(CurrentFrame.Texture, position, null, Color.White, 0.00f, new Vector2(0, 0), scale, SpriteEffects.None, 0.00f);
        }
    }
}
