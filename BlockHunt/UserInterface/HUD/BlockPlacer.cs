using BlockHunt.Input;
using BlockHunt.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.UserInterface.HUD
{
    class BlockPlacer : IHUDComponent
    {
        private static bool placingMode = false;
        private Texture2D placingRectangleTexture;
        private Rectangle placingRectangle = Rectangle.Empty;
        private static byte blockCount;

        public static float AmountOfBlockNumberScale { get; set; } = 1.5f;
        public static Rectangle AmountOfBlockNumberRectangle { get; set; } = new Rectangle(1800, 20, (int)(26 * AmountOfBlockNumberScale), (int)(37 * AmountOfBlockNumberScale));

        private Texture2D[] zeroToNine;

        public BlockPlacer(Texture2D placingRectangleTexture, Texture2D[] zeroToNine)
        {
            this.placingRectangleTexture = placingRectangleTexture;
            this.zeroToNine = zeroToNine;
        }

        public void Update(GameTime gameTime)
        {
            placingRectangle = new Rectangle((int)MouseReader.GridPosition.X, (int)MouseReader.GridPosition.Y, (int)LevelManager.TileSize.X, (int)LevelManager.TileSize.Y);
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
                spriteBatch.Draw(placingRectangleTexture, new Rectangle(placingRectangle.Left, placingRectangle.Bottom - bw, placingRectangle.Width, bw), Color.Black); // Bottom
            }

            // Amount of placeable blocks number 
            spriteBatch.Draw(zeroToNine[blockCount], AmountOfBlockNumberRectangle, Color.White);
        }

        public static void TogglePlace()
        {
            placingMode = !placingMode;
        }

        public static void AmountOfBlocks(byte amountOfBlocks)
        {
            blockCount = amountOfBlocks;
        }
    }
}
