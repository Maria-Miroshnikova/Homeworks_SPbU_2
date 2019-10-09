using System;
using System.Collections.Generic;
using System.IO;

namespace _6_2_ex
{
    /// <summary>
    /// This class presetns extra functions for working with files;
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
    }
}
