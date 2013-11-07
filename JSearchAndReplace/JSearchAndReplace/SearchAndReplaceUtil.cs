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
        public static string[][] GetExistingSet(string setName)
        {
            switch (setName.ToLower())
            {
                case "removediacritics":
                    return SearchAndReplaceContent.RemoveDiacritics;
                default:
                    throw new Exception("Unknown set: " + setName);
            }
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
