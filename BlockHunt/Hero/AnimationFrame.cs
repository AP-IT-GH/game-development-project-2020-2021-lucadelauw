using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.HeroNS
{
    class AnimationFrame
    {
        public Texture2D Texture { get; }

        public AnimationFrame(Texture2D texture)
        {
            this.Texture = texture;
        }
    }
}
