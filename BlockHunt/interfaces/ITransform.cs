using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.interfaces
{
    public interface ITransform
    {
        Vector2 Position { get; set; }
        Vector2 PrevPosition { get; set; }
        Vector2 Velocity { get; set; }
    }
}
