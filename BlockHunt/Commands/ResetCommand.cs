using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Commands
{
    class ResetCommand : IGameCommand
    {
        Vector2 resetPosition = new Vector2(200, 200);
        public void Execute(ITransform transform)
        {
            transform.Position = resetPosition;
            transform.Velocity = Vector2.Zero;
        }
    }
}
