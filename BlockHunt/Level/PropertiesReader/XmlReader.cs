using System;
using System.Collections.Generic;
using System.Linq;
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

        public void GetEnemies()
        {
            var xml = XDocument.Load(@"C:\contacts.xml");

            var query = from c in xml.Root.Descendants("enemies")
                        select c.Element("position").Value;

            Console.WriteLine(query.ToString());
        }

        public void GetPortal()
        {
            throw new NotImplementedException();
        }

    }
}
