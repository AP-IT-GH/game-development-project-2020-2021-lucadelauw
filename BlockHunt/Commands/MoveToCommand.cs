using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Commands
{
    public class MoveToCommand : IGameCommand
    {
        public Vector2 snelheid;
        public MoveToCommand()
        {
            snelheid = new Vector2(1, 0);
        }
        public void Execute(ITransform transform)
        {
            /*direction = Vector2.Add(direction, -transform.Position);
            direction.Normalize();
            direction = Vector2.Multiply(direction, 0.1f);

            snelheid += direction;
            snelheid = Limit(snelheid, 6);
            transform.Position += snelheid;*/
        }
        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }
    }
}
