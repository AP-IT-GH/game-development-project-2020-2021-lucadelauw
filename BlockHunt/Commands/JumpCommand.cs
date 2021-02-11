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
        private Vector2 direction;
        private Vector2 prevPosition = Vector2.Zero;

        public JumpCommand()
        {
            this.speed = new Vector2(0, 1123.58f);
            direction = new Vector2(0, -1);
        }
        public void Execute(ITransform transform)
        {
            if (transform.Position.Y == transform.PrevPosition.Y)
            transform.Velocity = new Vector2(transform.Velocity.X,(speed.Y * direction.Y));

            prevPosition = transform.Position;
        }
    }
}
