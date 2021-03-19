using BlockHunt.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.UserInterface
{
    class Button : IUserInterfaceComponent
    {
        private Rectangle box;
        private int borderWidth = 3;
        private Rectangle border;
        public static Texture2D LineTexture { get; set; }
        private Color boxColor = Color.White;
        private bool toggle1 = false;
        private bool click = false;
        TextGenerator textGenerator;
        private string text;
        public Button(Rectangle rectangle, string text, ContentManager content)
        {
            box = rectangle;
            border = new Rectangle(box.X, box.Y, borderWidth, borderWidth);
            textGenerator = new TextGenerator(content);
            this.text = text;
        }
        public void Update(GameTime gameTime)
        {
            Rectangle mouseRectangle = new Rectangle((int)MouseReader.Position.X, (int)MouseReader.Position.Y, 1, 1);
            if (box.Intersects(mouseRectangle))
            {
                boxColor = Color.Gray;
                if (MouseReader.State.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed || toggle1)
                {
                    toggle1 = true;
                    if (MouseReader.State.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
                    {
                        toggle1 = false;
                        click = true;
                    }
                    else
                        click = false;
                }
                else
                    click = false;
            }
            else
            {
                click = false;
                boxColor = Color.White;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(LineTexture, box, boxColor);
            spriteBatch.Draw(LineTexture, new Rectangle(box.Left, box.Top, borderWidth, box.Height - borderWidth), Color.Black); // Left
            spriteBatch.Draw(LineTexture, new Rectangle(box.Right - borderWidth, box.Top, borderWidth, box.Height), Color.Black); // Right
            spriteBatch.Draw(LineTexture, new Rectangle(box.Left, box.Top, box.Width, borderWidth), Color.Black); // Top
            spriteBatch.Draw(LineTexture, new Rectangle(box.Left, box.Bottom - borderWidth, box.Width, borderWidth), Color.Black); // Bottom
            textGenerator.DrawString(spriteBatch, text, box.Center.ToVector2(), 0.3f, true, Color.Black); // Text
        }

        public bool IsClicked()
        {
            return click;
        }
    }
}
