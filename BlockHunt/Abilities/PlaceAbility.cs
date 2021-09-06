using BlockHunt.UserInterface.HUD;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BlockHunt.Abilities
{
    class PlaceAbility : IAbility
    {
        public static Texture2D[] ZeroToNine { get; set; } = new Texture2D[10];
        public static Texture2D RectangleTexture { get; set; }

        public enum Action
        {
            Toggle,
            Place,
            Remove
        }


        private static bool enabled = false;

        private static Action action;

        private static byte amountOfBlocks = 3;
        public PlaceAbility(Action thisAction)
        {
            action = thisAction;

            var hud = HUD.Instance;
            hud.AddComponent(new BlockPlacer(RectangleTexture, ZeroToNine));
        }
        public void Execute()
        {
            if (action == Action.Toggle)
            {
                BlockPlacer.TogglePlace();
                enabled = !enabled;
            }
            else if (action == Action.Place && enabled && amountOfBlocks >= 1)
            {
                if (Level.LevelManager.PlaceBlock())
                    amountOfBlocks--;
            }
            else if (action == Action.Remove && enabled)
            {
                if (Level.LevelManager.RemoveBlock())
                    amountOfBlocks++;
            }
            BlockPlacer.AmountOfBlocks(amountOfBlocks);
        }
    }
}
