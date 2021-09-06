using BlockHunt.Abilities;
using BlockHunt.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Input
{
    class KeyboardReader : IInputReader
    {
        private bool placeToggle = false;
        public List<IGameCommand> ReadCommands()
        {
            List<IGameCommand> commands = new List<IGameCommand>();
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
                if (state.IsKeyDown(Keys.Down))
                    commands.Add(new SlideCommand());
                else
                    commands.Add(new MoveCommand(Direction.Left));
            if (state.IsKeyDown(Keys.Right))
                if (state.IsKeyDown(Keys.Down))
                    commands.Add(new SlideCommand());
                else
                    commands.Add(new MoveCommand(Direction.Right));
            if (state.IsKeyDown(Keys.Up))
                commands.Add(new JumpCommand());
            if (state.IsKeyDown(Keys.R))
                commands.Add(new ResetCommand());
            return commands;
        }

        public List<IAbility> ReadAbilities()
        {
            List<IAbility> abilities = new List<IAbility>();
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.F) || placeToggle)
            {
                placeToggle = true;
                if (state.IsKeyUp(Keys.F))
                {
                    abilities.Add(new PlaceAbility(PlaceAbility.Action.Toggle));
                    placeToggle = false;
                }
            }
            return abilities;
        }
    }
}
