using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSearchAndReplace
{
    public enum SearchAndReplaceMethod
    {
        LineByLine,
        WholeFileInMemory
    }

    public static class SearchAndReplace
    {
        public static void SearchAndReplaceInFile(SearchAndReplaceParameters searchAndReplaceParameters)
        {
            if (string.IsNullOrEmpty(searchAndReplaceParameters.SearchAndReplaceFile) && searchAndReplaceParameters.SearchAndReplaceContent == null)
                throw new Exception("Search and replace contents need to be specified, either by a file or selecting a pre-determined set.");

            if (string.IsNullOrEmpty(searchAndReplaceParameters.SearchAndReplaceFile))
                // Use preset contents to search and replace
                SearchAndReplaceInFile(
                    searchAndReplaceParameters.SearchAndReplaceContent,
                    searchAndReplaceParameters.InputFile,
                    searchAndReplaceParameters.OutputFileParsed,
                    searchAndReplaceParameters.SearchAndReplaceMethod,
                    searchAndReplaceParameters.Encoding);
            else
                // Use existing file to search and replace
                SearchAndReplaceInFile(
                    searchAndReplaceParameters.SearchAndReplaceFile,
                    searchAndReplaceParameters.InputFile,
                    searchAndReplaceParameters.OutputFileParsed,
                    searchAndReplaceParameters.SearchAndReplaceMethod,
                    searchAndReplaceParameters.Encoding);
        }

        public static void SearchAndReplaceInFile(string fileSearchAndReplace, string fileIn, string fileOut = null, SearchAndReplaceMethod method = SearchAndReplaceMethod.WholeFileInMemory, Encoding encoding = null)
        {
            string[][] searchAndReplace = GetSearchAndReplaceArray(fileSearchAndReplace);
            SearchAndReplaceInFile(searchAndReplace, fileIn, fileOut, method, encoding);
        }

        public static void SearchAndReplaceInFile(string[][] searchAndReplace, string fileIn, string fileOut = null, SearchAndReplaceMethod method = SearchAndReplaceMethod.WholeFileInMemory, Encoding encoding = null)
        {
            switch(method)
            {
                case SearchAndReplaceMethod.LineByLine:
                    SearchAndReplaceInFile_LineByLine(searchAndReplace, fileIn, fileOut, encoding);
                    break;
                case SearchAndReplaceMethod.WholeFileInMemory:
                    SearchAndReplaceInFile_WholeFileInMemory(searchAndReplace, fileIn, fileOut, encoding);
                    break;
                default:
                    throw new Exception("Search and replace method needs to be implemented");
            }
        }

        /// <summary>
        /// Gets the default encoding when it's not defined.
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static Encoding GetEncoding(Encoding encoding)
        {
            return encoding ?? Encoding.Default;
        }

        private static string[][] GetSearchAndReplaceArray(string fileSearchAndReplace, Encoding encoding = null)
        {
            encoding = GetEncoding(encoding);
            StreamReader sr = new StreamReader(fileSearchAndReplace, encoding);
            // TODO: Finish
            return null;
        }

        /// <summary>
        /// Replaces the text in a file and saves it to a new file.
        /// The search and replacement is done by reading the whole file into memory, making it faster.
        /// </summary>
        /// <param name="searchAndReplace"></param>
        /// <param name="fileIn"></param>
        /// <param name="fileOut"></param>
        /// <param name="encoding"></param>
        private static void SearchAndReplaceInFile_WholeFileInMemory(string[][] searchAndReplace, string fileIn, string fileOut = null, Encoding encoding = null)
        {
            bool replace = false;
            if (string.IsNullOrEmpty(fileOut) || string.Compare(fileIn, fileOut, true) == 0)
            {
                replace = true;
                fileOut = fileIn + ".tmp";
            }

            encoding = GetEncoding(encoding);
            string contents = File.ReadAllText(fileIn, encoding);

            foreach (string[] searchAndReplaceItems in searchAndReplace)
            {
                string replaceWith = searchAndReplaceItems[searchAndReplaceItems.Length - 1];

                for (int i = searchAndReplaceItems.Length - 2; i >= 0; i--)
                    contents = contents.Replace(searchAndReplaceItems[i], replaceWith);
            }

            if (replace)
                File.Replace(fileOut, fileIn, null);
        }

        /// <summary>
        /// Replaces the text in a file and saves it to a new file.
        /// The search and replacement is done line by line, making it less memory intensive for big files.
        /// </summary>
        /// <param name="searchAndReplace"></param>
        /// <param name="fileIn"></param>
        /// <param name="fileOut"></param>
        /// <param name="encoding"></param>
        private static void SearchAndReplaceInFile_LineByLine(string[][] searchAndReplace, string fileIn, string fileOut = null, Encoding encoding = null)
        {
            bool replace = false;
            if (string.IsNullOrEmpty(fileOut) || string.Compare(fileIn, fileOut, true) == 0)
            {
                replace = true;
                fileOut = fileIn + ".tmp";
            }

            encoding = GetEncoding(encoding);
            StreamReader srIn = new StreamReader(fileIn, encoding);
            StreamWriter srOut = new StreamWriter(fileOut, false, encoding);
            string line;

            try
            {
                while ((line = srIn.ReadLine()) != null)  // Reading line by line to avoid big memory usage on big files.
                {
                    if (line.Length > 0)
                    {
                        foreach (string[] searchAndReplaceItems in searchAndReplace)
                        {
                            string replaceWith = searchAndReplaceItems[searchAndReplaceItems.Length - 1];

                            for (int i = searchAndReplaceItems.Length - 2; i >= 0; i--)
                                line = line.Replace(searchAndReplaceItems[i], replaceWith);
                        }
                    }

                    srOut.WriteLine(line);
                }
            }
            finally
            {
                srIn.Close();
                srOut.Close();
            }

            if (replace)
                File.Replace(fileOut, fileIn, null);
        }
    }
}
