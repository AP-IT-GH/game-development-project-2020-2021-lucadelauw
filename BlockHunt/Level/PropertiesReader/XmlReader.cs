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

        public const string LEVEL1 = "Level1";
        public const string LEVEL2 = "Level2";
        public const string LEVEL3 = "Level3";
        public const string LEVEL4 = "Level4";
        public const string LEVEL5 = "Level5";

        public void SetLevel(string file)
        {
            this.file = file;
        }

        public void GetBlocks()
        {
            throw new NotImplementedException();
        }

        public List<Enemy> GetEnemies(ContentManager content)
        {
            string file = LEVEL1;
            string executingPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            this.file = executingPath + @"\Content\World\" + file + @"\world.xml";

            var xml = XDocument.Load(this.file);

            List<Enemy> enemies = new List<Enemy>();

            foreach (var element in xml.Root.Element("enemies").Elements())
            {
                var position = element.Element("position");
                var y = Int32.Parse(position.Element("y").Value);
                var from = Int32.Parse(position.Element("from").Value);
                var to = Int32.Parse(position.Element("to").Value);

                enemies.Add(new Enemy(y, from, to, content));
            }

            return enemies;
        }

        public List<Portal> GetPortals(ContentManager content)
        {
            string file = LEVEL1;
            string executingPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            this.file = executingPath + @"\Content\World\" + file + @"\world.xml";

            var xml = XDocument.Load(this.file);

            List<Portal> portals = new List<Portal>();

            foreach (var element in xml.Root.Element("portals").Elements())
            {
                var position = element.Element("position");
                var x = Int32.Parse(position.Element("x").Value);
                var y = Int32.Parse(position.Element("y").Value);
                var toLevel = element.Element("to").Value;
                
                portals.Add(new Portal(new Tuple<int, int>(x, y), toLevel, content));
            }

            return portals;
        }

    }
}
