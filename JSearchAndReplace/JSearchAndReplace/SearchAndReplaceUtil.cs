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
        /// 2D jagged array whith the content
        /// {Command line name , Readable name , description}
        /// </summary>
        public static readonly string[][] ExistingSets = new string[][]
        {
            new string[] { "RemoveDiacritics", "Remove Diacritics", "Removes all accents" },
            new string[] { "RemoveSpaces", "Remove Spaces", "Removes all spaces" },
            new string[] { "ReplaceInvalidFilanameCharsWithUnderline", "Replace Invalid Filaname Chars With Underline", "Replaces invalid filaname characters with an underline" }
        };

        /// <summary>
        /// Gets an existing search and replace set
        /// </summary>
        /// <param name="commandLineName">The commandline name of the set.</param>
        /// <returns></returns>
        public static string[][] GetExistingSetByCommandLineName(string commandLineName)
        {
            switch (commandLineName.ToLower())
            {
                case "removediacritics":
                    return SearchAndReplaceContent.RemoveDiacritics;
                case "removespaces":
                    return SearchAndReplaceContent.RemoveSpaces;
                case "replaceinvalidfilanamecharswithunderline":
                    return SearchAndReplaceContent.ReplaceInvalidFilanameCharsWithUnderline;
                default:
                    throw new Exception("Unknown set: " + commandLineName);
            }
        }

        public static int GetExistingSetInfoIndexByCommandLineName(string commandLineName)
        {
            return GetExistingSetInfoIndexBySelectedIndexAndValue(0, commandLineName);
        }

        public static int GetExistingSetInfoIndexByReadableName(string readableName)
        {
            return GetExistingSetInfoIndexBySelectedIndexAndValue(1, readableName);
        }

        private static int GetExistingSetInfoIndexBySelectedIndexAndValue(int searchIndex, string value)
        {
            return GetExistingSetInfoIndexBySelectedIndexAndValue(searchIndex, value, StringComparison.CurrentCultureIgnoreCase);
        }

        private static int GetExistingSetInfoIndexBySelectedIndexAndValue(int searchIndex, string value, StringComparison comparisonType)
        {
            for (int i = 0; i < ExistingSets[0].Length; i++)
                if (ExistingSets[i][searchIndex].Equals(value, comparisonType))
                    return i;

            return -1;
        }

        /// <summary>
        /// Gets an existing search and replace set
        /// </summary>
        /// <param name="setReadableName">The readable name of the set.</param>
        /// <returns></returns>
        public static string[][] GetExistingSetByReadableName(string readableName)
        {
            int i = GetExistingSetInfoIndexByReadableName(readableName);
            if (i < 0)
                throw new Exception("Unknown set: " + readableName);

            return GetExistingSetByCommandLineName(ExistingSets[i][0]);
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
