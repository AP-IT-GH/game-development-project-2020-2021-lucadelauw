using BlockHunt.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level
{
    public interface ILevelReader
    {
        public void SetLevel(string file);
        public byte[,] GetLevel();
    }
}
