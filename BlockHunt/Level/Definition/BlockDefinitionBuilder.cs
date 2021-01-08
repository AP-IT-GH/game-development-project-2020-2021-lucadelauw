using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.Definition
{
    class BlockDefinitionBuilder : IBlockDefinitionBuilder
    {
        private readonly Dictionary<string,IBlockDefinition> definitions;
        public BlockDefinitionBuilder()
        {
            definitions = new Dictionary<string, IBlockDefinition>();
        }
        public Dictionary<string, IBlockDefinition> GetBlockDefinitions()
        {
            CreateDefinitions();
            return definitions;
        }

        private void CreateDefinitions()
        {
            Vector2 tileSize = new Vector2(70, 70);

            // Solid
            definitions.Add("grass", new BlockDefinition("grassCliffLeft", true, tileSize));
            definitions.Add("grass_center", new BlockDefinition("grassCenter", true, tileSize));
            definitions.Add("grass_mid", new BlockDefinition("grassMid", true, tileSize));
            definitions.Add("grass_left", new BlockDefinition("grassLeft", true, tileSize));
            definitions.Add("grass_right", new BlockDefinition("grassRight", true, tileSize));
            definitions.Add("grass_cliff_left", new BlockDefinition("grassCliffLeft", true, tileSize));
            definitions.Add("grass_cliff_right", new BlockDefinition("grassCliffRight", true, tileSize));

            // Special
            definitions.Add("door_closed_mid", new BlockDefinition("door_closedMid", false, tileSize));
            definitions.Add("door_closed_top", new BlockDefinition("door_closedTop", false, tileSize));
            definitions.Add("door_open_mid", new BlockDefinition("door_openMid", false, tileSize));
            definitions.Add("door_open_top", new BlockDefinition("door_openTop", false, tileSize));

            // Decoration
            definitions.Add("fence", new BlockDefinition("fence", false, tileSize));
            definitions.Add("fence_broken", new BlockDefinition("fenceBroken", false, tileSize));

            // Placeable
            definitions.Add("dynamic", new BlockDefinition("boxAlt", true, tileSize));
        }
    }
}
