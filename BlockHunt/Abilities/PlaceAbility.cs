using BlockHunt.UserInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Abilities
{
    class PlaceAbility : IAbility
    {
        public const bool Toggle = false;
        public const bool Trigger = true;

        private static bool enabled = false;

        private static bool Action;
        public PlaceAbility(bool action)
        {
            Action = action;
        }
        public void Execute()
        {
            if (Action == PlaceAbility.Toggle)
            {
                HUD.TogglePlace();
                enabled = !enabled;
            }
            else if (Action == PlaceAbility.Trigger && enabled)
                Level.LevelManager.PlaceBlock();
        }
    }
}
