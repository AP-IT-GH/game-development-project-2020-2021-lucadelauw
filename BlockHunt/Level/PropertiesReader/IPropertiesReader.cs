using BlockHunt.Level.World;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level
{
    public interface IPropertiesReader
    {
        public void SetLevel(string file);

        public List<Enemy> GetEnemies(ContentManager content);
        public List<Portal> GetPortals(ContentManager content);
    }
}
