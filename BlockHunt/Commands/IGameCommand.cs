using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Commands
{
    public interface IGameCommand
    {
        void Execute(ITransform transform);
    }
}
