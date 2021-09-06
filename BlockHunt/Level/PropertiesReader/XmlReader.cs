using BlockHunt.Level.World;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace BlockHunt.Level
{
    class XmlReader : IPropertiesReader
    {
        private string file;

        private const int Yoffset = 28;

        public void SetLevel(string file)
        {
            string executingPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            this.file = executingPath + @"\Content\World\" + file + @"\world.xml";
        }

        public void GetBlocks()
        {
            throw new NotImplementedException();
        }

        public List<Enemy> GetEnemies(ContentManager content)
        {
            var xml = XDocument.Load(this.file);

            List<Enemy> enemies = new List<Enemy>();

            foreach (var element in xml.Root.Element("enemies").Elements())
            {
                var position = element.Element("position");
                var y = Int32.Parse(position.Element("y").Value);
                var from = Int32.Parse(position.Element("from").Value);
                var to = Int32.Parse(position.Element("to").Value);

                enemies.Add(new Enemy((int)(y * LevelManager.TileSize.Y) + Yoffset, (int)(from * LevelManager.TileSize.X), (int)(to * LevelManager.TileSize.X), content));
            }

            return enemies;
        }

        public List<Portal> GetPortals(ContentManager content)
        {
            var xml = XDocument.Load(this.file);

            List<Portal> portals = new List<Portal>();

            foreach (var element in xml.Root.Element("portals").Elements())
            {
                var position = element.Element("position");
                var x = Int32.Parse(position.Element("x").Value);
                var y = Int32.Parse(position.Element("y").Value);
                var toLevel = element.Element("to").Value;
                
                portals.Add(new Portal(new Tuple<int, int>((int)(x * LevelManager.TileSize.X), (int)(y * LevelManager.TileSize.Y)), toLevel, content));
            }

            return portals;
        }

    }
}
