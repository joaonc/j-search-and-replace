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

        public SearchAndReplaceDataSource SearchAndReplaceDataSource { get; set; }

        /// <summary>
        /// Content used to search and replace, as defined in the SearchAndReplaceContent class.
        /// If not specified, then SearchAndReplaceFile needs to be specified.
        /// </summary>
        public string[][] SearchAndReplaceContent { get; set; }

        /// <summary>
        /// If the option is to search and replace using an existing set, then this contains that set's info: command line name, readable name and description.
        /// See SearchAndReplaceUtil.ExistingSets for more details.
        /// </summary>
        public string[] SearchAndReplaceExistingSetInfo { get; set; }

        /// <summary>
        /// Run the app without UI, useful for command line batch processing.
        /// </summary>
        public bool NoUI { get; set; }

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
            OutputFile = "SearchAndReplaceOutput.txt";
            NoUI = false;

            // Remove Diacritics existing set
            SearchAndReplaceDataSource = SearchAndReplaceDataSource.ExistingSet;
            string existingSetCommandLineName = "RemoveDiacritics";
            SearchAndReplaceExistingSetInfo = SearchAndReplaceUtil.ExistingSets[SearchAndReplaceUtil.GetExistingSetInfoIndexByCommandLineName(existingSetCommandLineName)];
            SearchAndReplaceContent = SearchAndReplaceUtil.GetExistingSetByCommandLineName(existingSetCommandLineName);
        }

        public void Parse()
        {
            ParseCommandLineParameters();
            ParseOutputFile();
        }

        /// <summary>
        /// Returns a string that can be passed later as command line parameters to be used to create a new object.
        /// </summary>
        /// <returns></returns>
        public string SerializeToCommandLineParameters(
            bool verbose=false, bool excludeInputFile=false, bool excludeOutputFile=false)
        {
            StringBuilder args = new StringBuilder();

            if (!excludeInputFile && !string.IsNullOrEmpty(InputFile))
                args.AppendFormat("-{0} \"{1}\" ",verbose ? "input" : "i", InputFile);
            if (!excludeOutputFile && !string.IsNullOrEmpty(OutputFile))
                args.AppendFormat("-{0} \"{1}\" ", verbose ? "output" : "o", OutputFile);

            switch (SearchAndReplaceDataSource)
            {
                case SearchAndReplaceDataSource.ExistingSet:
                    args.AppendFormat("-{0} {1} ", verbose ? "existingset" : "e", SearchAndReplaceExistingSetInfo[0]);
                    break;
                case SearchAndReplaceDataSource.FromFile:
                    args.AppendFormat("-{0} \"{1}\" ", verbose ? "searchandreplacefile" : "f", SearchAndReplaceFile);
                    break;
                case SearchAndReplaceDataSource.Custom:
                    throw new Exception("TODO: serialize custom set to command line string.");
                default:
                    throw new Exception("Need to implement handling of SearchAndReplaceDataSource." + SearchAndReplaceDataSource.ToString());
            }

            if (NoUI)
                args.Append("-noui ");

            return args.ToString().Trim();
        }

        private void ParseCommandLineParameters()
        {
            if (CommandLineParameters != null)
            {
                char[] trimStart = new char[] { '-', '/', ' ' };
                char[] trimQuotes = new char[] { '"', ' ' };

                for (int i = 0; i < CommandLineParameters.Length; i++)
                {
                    string parameter = CommandLineParameters[i].TrimStart(trimStart).ToLower();
                    switch (parameter)
                    {
                        case "i":
                        case "input":
                            InputFile = GetNextCommandLineParameter(i++).Trim(trimQuotes);
                            break;
                        case "o":
                        case "output":
                            OutputFile = GetNextCommandLineParameter(i++).Trim(trimQuotes);
                            break;
                        case "f":
                        case "searchandreplacefile":
                            SearchAndReplaceFile = GetNextCommandLineParameter(i++);
                            SearchAndReplaceDataSource = SearchAndReplaceDataSource.FromFile;
                            break;
                        case "e":
                        case "existingset":
                            string existingSetCommandLineName = GetNextCommandLineParameter(i++);
                            int existingSetInfoIndex = SearchAndReplaceUtil.GetExistingSetInfoIndexByCommandLineName(existingSetCommandLineName);
                            if (existingSetInfoIndex < 0)
                                throw new Exception("Unknown set: " + existingSetCommandLineName);
                            SearchAndReplaceExistingSetInfo = SearchAndReplaceUtil.ExistingSets[existingSetInfoIndex];
                            SearchAndReplaceContent = SearchAndReplaceUtil.GetExistingSetByCommandLineName(existingSetCommandLineName);
                            SearchAndReplaceDataSource = SearchAndReplaceDataSource.ExistingSet;
                            break;
                        case "c":
                        case "custom":
                            SearchAndReplaceContent = SearchAndReplaceUtil.GetSetFromCSV(GetNextCommandLineParameter(i++));
                            SearchAndReplaceDataSource = SearchAndReplaceDataSource.Custom;
                            break;
                        case "noui":
                            NoUI = true;
                            break;
                        default:
                            throw new Exception("Unknown parameter: " + parameter);
                    }
                }
            }
        }

        private string GetNextCommandLineParameter(int i)
        {
            if ((i + 1) > CommandLineParameters.Length)
                throw new Exception(string.Format("Value for command line \"{0}\" doesn't exist.", CommandLineParameters[i]));

            return CommandLineParameters[i + 1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="verbose">Whether to return the long version of the parameters (ex: input) or the short version (ex: i).</param>
        /// <param name="includeInputFile">Whether to include the input file. If false it will also NOT include the parsed output file.</param>
        /// <returns></returns>
        public string GetCommandLineParameters(bool verbose, bool includeInputFile)
        {
            StringBuilder sbParams = new StringBuilder();

            if (includeInputFile && !string.IsNullOrEmpty(InputFile))
                sbParams.Append(string.Format("{0} {1} ", verbose ? "input" : "i", InputFile));

            if (!string.IsNullOrEmpty(OutputFile))
                sbParams.Append(string.Format("{0} {1} ", verbose ? "output" : "o", OutputFile));

            if (!string.IsNullOrEmpty(SearchAndReplaceFile))
                sbParams.Append(string.Format("{0} {1} ", verbose ? "searchandreplacefile" : "f", SearchAndReplaceFile));

            return sbParams.ToString();
        }

        private void ParseOutputFile()
        {
            if (string.IsNullOrEmpty(OutputFile))
            {
                OutputFileParsed = "";
                return;
            }

            if (string.IsNullOrEmpty(InputFile))
            {
                OutputFileParsed = OutputFile.Replace('<', '_').Replace('>', '_');
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
