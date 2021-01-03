using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Commands
{
    class JumpCommand : IGameCommand
    {
        public Vector2 speed;

        public JumpCommand()
        {
            this.speed = new Vector2(5, 5);
        }
        public void Execute(ITransform transform, Vector2 direction)
        {
            direction *= speed;
            transform.Position += direction;
        }
    }
}
