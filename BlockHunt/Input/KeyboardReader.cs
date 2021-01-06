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
        public List<IGameCommand> ReadInput()
        {
            List<IGameCommand> commands = new List<IGameCommand> { };
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
            return commands;
        }
    }
}
