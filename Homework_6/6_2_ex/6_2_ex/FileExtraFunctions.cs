using System;
using System.Collections.Generic;
using System.IO;

namespace _6_2_ex
{
    /// <summary>
    /// This class presents extra functions for working with files;
    /// </summary>
    public static class FileExtraFunctions
    {
        /// <summary>
        /// Reads and returns game map from given file;
        /// </summary>
        public static List<string> ReadMapFromFile(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException();
            }

            var listMap = new List<string>();

            using (var file = new StreamReader(fileName))
            {
                string line = file.ReadLine();

                while (line != null)
                {
                    listMap.Add(line);
                    line = file.ReadLine();
                }
            }

            return listMap;
        }

        /// <summary>
        /// Makes array from list (for game map);
        /// </summary>
        public static char[,] MakeArrayFromList(List<string> list)
        {
            var array = new char[list.Count, list[0].Length];

            for (int i = 0; i < list.Count; ++i)
            {
                for (int j = 0; j < list[0].Length; ++j)
                {
                    array[i, j] = list[i][j];
                }
            }

            return array;
        }
    }
}
