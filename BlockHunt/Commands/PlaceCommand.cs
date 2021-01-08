using BlockHunt.interfaces;
using BlockHunt.UserInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Commands
{
    class PlaceCommand : IGameCommand
    {
        public const bool Toggle = false;
        public const bool Trigger = true;

        private bool action;
        public PlaceCommand(bool action)
        {
            this.action = action;
        }
        public void Execute(ITransform transform)
        {
            if (action == PlaceCommand.Toggle)
                HUD.TogglePlace();
            else if (action == PlaceCommand.Trigger)
                Level.LevelManager.PlaceBlock();
        }
    }
}
