using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level.Definition
{
    public interface IBlockDefinitionBuilder
    {
        public Dictionary<string, IBlockDefinition> GetBlockDefinitions()
        {
            return new Dictionary<string, IBlockDefinition>();
        }
    }
}
