using BlockHunt.UserInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Abilities
{
    class PlaceAbility : IAbility
    {
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
        }
        public void Execute()
        {
            if (action == Action.Toggle)
            {
                HUD.TogglePlace();
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
        }
    }
}
