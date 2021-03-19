using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace BlockHunt.HeroNS
{
    enum HeroAction
    {
        Idle,
        Run,
        Jump,
        Slide,
        Dead
    }
    class HeroAnimation
    {
        private ContentManager content;
        private GameTime gameTime;

        public AnimationFrame CurrentFrame { get; set; }
        public Rectangle sourceRectangle { get; }
        private Vector2 position;
        private Vector2 prevPosition;
        private List<AnimationFrame> frames_idle;
        private List<AnimationFrame> frames_run;
        private List<AnimationFrame> frames_jump;
        private List<AnimationFrame> frames_slide;
        private List<AnimationFrame> frames_dead;
        private int counter;
        private Double lastTime = 0;
        private bool toFlip;
        public HeroAnimation(ContentManager content)
        {
            this.content = content;

            frames_idle = new List<AnimationFrame>();
            frames_run = new List<AnimationFrame>();
            frames_jump = new List<AnimationFrame>();
            frames_slide = new List<AnimationFrame>();
            frames_dead = new List<AnimationFrame>();


            InitzializeConent();
        }

        private void InitzializeConent()
        {
            frames_idle.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Idle__001")));
            frames_idle.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Idle__002")));
            frames_idle.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Idle__003")));
            frames_idle.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Idle__004")));
            frames_idle.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Idle__005")));
            frames_idle.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Idle__006")));
            frames_idle.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Idle__007")));
            frames_idle.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Idle__008")));
            frames_idle.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Idle__009")));

            frames_run.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Run__001")));
            frames_run.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Run__002")));
            frames_run.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Run__003")));
            frames_run.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Run__004")));
            frames_run.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Run__005")));
            frames_run.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Run__006")));
            frames_run.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Run__007")));
            frames_run.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Run__008")));
            frames_run.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Run__009")));

            frames_jump.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Jump__001")));
            frames_jump.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Jump__002")));
            frames_jump.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Jump__003")));
            frames_jump.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Jump__004")));
            frames_jump.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Jump__005")));
            frames_jump.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Jump__006")));
            frames_jump.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Jump__007")));
            frames_jump.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Jump__008")));
            frames_jump.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Jump__009")));

            frames_slide.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Slide__001")));
            frames_slide.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Slide__002")));
            frames_slide.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Slide__003")));
            frames_slide.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Slide__004")));
            frames_slide.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Slide__005")));
            frames_slide.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Slide__006")));
            frames_slide.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Slide__007")));
            frames_slide.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Slide__008")));
            frames_slide.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Slide__009")));

            frames_dead.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Dead__001")));
            frames_dead.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Dead__002")));
            frames_dead.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Dead__003")));
            frames_dead.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Dead__004")));
            frames_dead.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Dead__005")));
            frames_dead.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Dead__006")));
            frames_dead.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Dead__007")));
            frames_dead.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Dead__008")));
            frames_dead.Add(new AnimationFrame(content.Load<Texture2D>("Hero/Dead__009")));
        }

        public void Update(GameTime gameTime, Vector2 position)
        {
            this.position = position;
            this.gameTime = gameTime;

            // Determine what animation to play based on the current and previous position.

            HeroAction heroAction = HeroAction.Idle;
            if (position.X != prevPosition.X)
                heroAction = HeroAction.Run;
            if (position.Y != prevPosition.Y)
                heroAction = HeroAction.Jump;

            // Decide whether the texture should be flipped

            if (position.X < prevPosition.X)
                toFlip = true;
            else
                toFlip = false;

            prevPosition = position;
            switch(heroAction)
            {
                case HeroAction.Idle:
                    UpdateThis(frames_idle, true);
                    break;

                case HeroAction.Run:
                    UpdateThis(frames_run, true);
                    break;

                case HeroAction.Jump:
                    UpdateThis(frames_jump, false);
                    break;

                case HeroAction.Slide:
                    UpdateThis(frames_slide, false);
                    break;

                case HeroAction.Dead:
                    UpdateThis(frames_dead, false);
                    break;
            }
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
