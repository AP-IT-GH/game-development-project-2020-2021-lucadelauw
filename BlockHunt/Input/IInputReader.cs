using BlockHunt.Abilities;
using BlockHunt.Commands;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Input
{
    public interface IInputReader
    {
        List<IGameCommand> ReadCommands();
        List<IAbility> ReadAbilities();
    }
}
