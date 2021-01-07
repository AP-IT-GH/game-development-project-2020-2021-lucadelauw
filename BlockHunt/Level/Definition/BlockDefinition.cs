using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.Definition
{
    class BlockDefinition : IBlockDefinition
    {
        public string File { get; }
        public bool HasHitbox { get; }
        public Vector2 CollisionBoxSize { get; set; }

        public BlockDefinition(string file, bool hasHitbox, Vector2 collisionBoxSize)
        {
            File = file;
            HasHitbox = hasHitbox;
            CollisionBoxSize = collisionBoxSize;
        }
    }
}
