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
            this.speed = new Vector2(0, 49.33f);
            direction = new Vector2(0, -1);
        }
        public void Execute(ITransform transform)
        {
            System.Diagnostics.Debug.WriteLine("prevpos: " + prevPosition.Y + "           pos: " + transform.Position.Y);
            if (transform.Position.Y == transform.PrevPosition.Y)
            transform.Acceleration = new Vector2(transform.Acceleration.X,(speed.Y * direction.Y));

            prevPosition = transform.Position;
        }
    }
}
