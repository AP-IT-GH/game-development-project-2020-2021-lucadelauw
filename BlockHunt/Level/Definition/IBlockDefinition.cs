using BlockHunt.interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.Definition
{
    public interface IBlockDefinition
    {
        public string File { get; }
        public bool HasHitbox { get; }
        public Vector2 CollisionBoxSize { get; }
        public IBlockDefinition GetBlockDefinition()
        {
            return this;
        }
    }
}
