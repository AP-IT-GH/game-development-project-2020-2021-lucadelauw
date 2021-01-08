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
        public const bool Toggle = false;
        public const bool Trigger = true;

        private static bool enabled = false;

        private static Action action;
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
            else if (action == Action.Place && enabled)
                Level.LevelManager.PlaceBlock();
            else if (action == Action.Remove && enabled)
                Level.LevelManager.RemoveBlock();
        }
    }
}
