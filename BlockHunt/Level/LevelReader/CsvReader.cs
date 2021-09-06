using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Reflection;

namespace BlockHunt.Level
{
    public class CsvReader : ILevelReader
    {
        private string path;
        public CsvReader()
        {
          
        }

        public byte[,] GetLevel()
        {
            byte[,] byteField = new byte[15, 180];
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                int i = 0;
                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    for (int j = 0; j < fields.Length; j++)
                    {
                        byteField[i,j] = byte.Parse(fields[j]);
                    }
                    i++;
                }
            }
            return byteField;
        }

        public void SetLevel(string file)
        {
            string executingPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            path = executingPath + @"\Content\World\" + file + @"\world.csv";
        }
    }
}
