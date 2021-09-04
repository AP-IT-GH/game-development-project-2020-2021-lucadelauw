﻿using BlockHunt.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Level
{
    public interface ILevelReader
    {
        public const string LEVEL1 = "Level1";
        public const string LEVEL2 = "Level2";
        public const string LEVEL3 = "Level3";
        public const string LEVEL4 = "Level4";
        public const string LEVEL5 = "Level5";

        public byte[,] GetLevel();
        void SetLevel(string file);
    }
}
