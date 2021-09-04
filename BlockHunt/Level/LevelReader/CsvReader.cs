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
        private string file;
        public CsvReader(string file)
        {
            string executingPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            this.file = executingPath + @"\Content\World\" + file + @"\world.csv";
        }

        public byte[,] GetLevel()
        {
            byte[,] byteField = new byte[15, 180];
            using (TextFieldParser csvParser = new TextFieldParser(file))
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
            this.file = file;
        }
    }
}
