using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JSearchAndReplace
{
    public class SearchAndReplaceParameters
    {
        /// <summary>
        /// The input file.
        /// </summary>
        public string InputFile { get; set; }

        /// <summary>
        /// Parameters passed to the application.
        /// </summary>
        public string[] CommandLineParameters { get; set; }

        /// <summary>
        /// The output file as specified in the input.
        /// Can be null or empty to replace the existing input file.
        /// </summary>
        public string OutputFile { get; set; }

        /// <summary>
        /// The output filename that will be used.
        /// This is created after parsing OutputFile.
        /// </summary>
        public string OutputFileParsed { get; set; }

        /// <summary>
        /// File to get the items to search and replace.
        /// If not specified, then SearchAndReplaceContent needs to be specified.
        /// </summary>
        public string SearchAndReplaceFile { get; set; }

        /// <summary>
        /// Content used to search and replace, as defined in the SearchAndReplaceContent class.
        /// If not specified, then SearchAndReplaceFile needs to be specified.
        /// </summary>
        public string[][] SearchAndReplaceContent { get; set; }

        public Encoding Encoding { get; set; }

        /// <summary>
        /// Method for searching and replacing the contents of the file.
        /// </summary>
        public SearchAndReplaceMethod SearchAndReplaceMethod { get; set; }

        public SearchAndReplaceParameters()
        {
            SetDefaults();
        }

        public SearchAndReplaceParameters(string[] commandLineParameters)
        {
            SetDefaults();
            CommandLineParameters = commandLineParameters;
            Parse();
        }

        private void SetDefaults()
        {
            SearchAndReplaceMethod = SearchAndReplaceMethod.LineByLine;
        }

        public void Parse()
        {
            ParseParameters();

            if (string.IsNullOrEmpty(SearchAndReplaceFile) && SearchAndReplaceContent == null)
            {
                throw new Exception("Search and replace contents need to be specified, either by a file or selecting a pre-determined set.");
            }

            ParseOutputFile();
        }

        private void ParseParameters()
        {
            foreach (string parameter in CommandLineParameters)
            {
                switch (parameter.ToLower())
                {
                    case "i":
                    case "input":
                        InputFile = parameter;
                        break;
                    case "o":
                    case "output":
                        OutputFile = parameter;
                        break;
                    case "s":
                    case "search":
                        SearchAndReplaceFile = parameter;
                        break;
                    case "d":
                    case "dictionary":
                        break;
                    default:
                        throw new Exception("Unknown parameter: " + parameter);
                }
            }
        }

        private void ParseOutputFile()
        {
            if (!File.Exists(InputFile))
                throw new FileNotFoundException("Input file not found");

            if (string.IsNullOrEmpty(OutputFile))
            {
                OutputFileParsed = "";
                return;
            }

            string n = Path.GetFileNameWithoutExtension(InputFile);
            string e = Path.GetExtension(InputFile);

            StringBuilder sb = new StringBuilder();

            int j, i = 0;
            while ((j = OutputFile.IndexOf('<', i)) != -1)
            {
                switch (OutputFile[j + 1])
                {
                    case 'n':

                        break;
                }
            }

            //OutputFile = OutputFile.Replace("<n>", n).Replace("<e>", e);
        }
    }
}
