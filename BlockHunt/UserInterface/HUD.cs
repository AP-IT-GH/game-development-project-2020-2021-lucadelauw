﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using BlockHunt.Level;
using BlockHunt.Input;

namespace BlockHunt.UserInterface
{
    class HUD : IUserInterface
    {
        private static bool placingMode = false;
        private Rectangle placingRectangle = Rectangle.Empty;
        private Texture2D placingRectangleTexture;
        private Texture2D[] zeroToNine;
        private static byte blockCount;

        public static Rectangle AmountOfBlockNumberRectangle { get; set; } = new Rectangle(0, 0, 26, 37);

        public HUD(Texture2D placingRectangleTexture, Texture2D[] zeroToNine)
        {
            this.placingRectangleTexture = placingRectangleTexture;
            this.zeroToNine = zeroToNine;
        }

        public static void TogglePlace()
        {
            placingMode = !placingMode;
        }
        public void Update(GameTime gameTime)
        {
            placingRectangle = new Rectangle((int)MouseReader.TransformedGridPosition.X, (int)MouseReader.TransformedGridPosition.Y, (int)LevelManager.TileSize.X, (int)LevelManager.TileSize.Y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Hollow placing rectangle
            if (placingMode)
            {
                int bw = 2; // Border width
                spriteBatch.Draw(placingRectangleTexture, new Rectangle(placingRectangle.Left, placingRectangle.Top, bw, placingRectangle.Height - bw), Color.Black); // Left
                spriteBatch.Draw(placingRectangleTexture, new Rectangle(placingRectangle.Right - bw, placingRectangle.Top, bw, placingRectangle.Height), Color.Black); // Right
                spriteBatch.Draw(placingRectangleTexture, new Rectangle(placingRectangle.Left, placingRectangle.Top, placingRectangle.Width, bw), Color.Black); // Top
                spriteBatch.Draw(placingRectangleTexture, new Rectangle(placingRectangle.Left, placingRectangle.Bottom - bw, placingRectangle.Width , bw), Color.Black); // Bottom
            }

            // Amount of placeable blocks number 
            spriteBatch.Draw(zeroToNine[blockCount], new Rectangle(1920 - AmountOfBlockNumberRectangle.Width, 0, AmountOfBlockNumberRectangle.Width, AmountOfBlockNumberRectangle.Height), Color.White);
        }

        public static void AmountOfBlocks(byte amountOfBlocks)
        {
            blockCount = amountOfBlocks;
        }
    }
}
