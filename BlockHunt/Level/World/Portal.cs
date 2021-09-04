using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.World
{
    class Portal
    {
        private string toLevel;
        private Tuple<int, int> coords;

        public Portal(Tuple<int,int> coords, string toLevel)
        {
            this.coords = coords;
            this.toLevel = toLevel;
        }

        public Tuple<int,int> GetCoords()
        {
            return coords;
        }
        public string GetToLevel()
        {
            return toLevel;
        }
    }
}
