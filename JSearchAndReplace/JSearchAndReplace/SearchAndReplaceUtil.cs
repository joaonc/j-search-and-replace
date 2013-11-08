using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JSearchAndReplace
{
    public static class SearchAndReplaceUtil
    {
        /// <summary>
        /// Existing sets of search and replace.
        /// 2D array whith the content
        /// {Command line name , Readable name , description}
        /// </summary>
        public static readonly string[,] ExistingSets = new string[,] { { "RemoveDiacritics", "Remove Diacritics", "Removes accents from a string" } };

        /// <summary>
        /// Gets an existing search and replace set
        /// </summary>
        /// <param name="setName">The commandline name of the set.</param>
        /// <returns></returns>
        public static string[][] GetExistingSetByCommandLineName(string setName)
        {
            switch (setName.ToLower())
            {
                case "removediacritics":
                    return SearchAndReplaceContent.RemoveDiacritics;
                default:
                    throw new Exception("Unknown set: " + setName);
            }
        }

        /// <summary>
        /// Gets an existing search and replace set
        /// </summary>
        /// <param name="setReadableName">The readable name of the set.</param>
        /// <returns></returns>
        public static string[][] GetExistingSetByReadableName(string setReadableName)
        {
            for (int i = 0; i < ExistingSets.GetLength(0); i++)
                if (ExistingSets[i, 1].ToLower().Equals(setReadableName))
                    return GetExistingSetByCommandLineName(ExistingSets[i, 0]);

            throw new Exception("Unknown set: " + setReadableName);
        }


        public static string[][] GetSetFromCSV(string csv)
        {
            List<string[]> lines = new List<string[]>();
            string separator = "\",\"";

            if (csv != null)
            {
                foreach (string line in Regex.Split(csv, Environment.NewLine).ToList().Where(s => !string.IsNullOrEmpty(s)))
                {
                    string[] values = Regex.Split(line, separator);

                    for (int i = 0; i < values.Length; i++)
                        values[i] = values[i].Trim('\"');  //Trim values

                    lines.Add(values);
                }
            }

            return lines.ToArray();
        }
    }
}
