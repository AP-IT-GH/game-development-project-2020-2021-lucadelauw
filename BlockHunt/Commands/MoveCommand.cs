using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Commands
{
    enum Direction
    {
        Left,
        Right
    }
    class MoveCommand : IGameCommand
    {
        public Vector2 speed;
        private Vector2 direction;
        public MoveCommand(Direction direction)
        {
            this.speed = new Vector2(500f,0);
            switch (direction)
            {
                case Direction.Left:
                    this.direction = new Vector2(-1, 0);
                    break;

                case Direction.Right:
                    this.direction = new Vector2(1, 0);
                    break;
            }
        }
        public void Execute(ITransform transform)
        {
            transform.Velocity = new Vector2(direction.X * speed.X, transform.Velocity.Y);
        }
    }
}
