using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.UserInterface
{
    // SOURCE: http://magellanicgames.co.uk/textdrawing.html
    class TextGenerator
    {
        ContentManager content;
        SpriteFont font;
        public TextGenerator(ContentManager content)
        {
            this.content = content;
            font = this.content.Load<SpriteFont>("UserInterface/UIText");
        }

        public void DrawString(SpriteBatch spriteBatch, string text, Vector2 position, float scale, bool center, Color color)
        {
            if (center)
            {
                Vector2 stringSize = font.MeasureString(text) * 0.5f;
                spriteBatch.DrawString(font, text, position - (stringSize * scale), color, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
            } 
            else
            {
                spriteBatch.DrawString(font, text, position, color, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
            }
        }
    }
}
