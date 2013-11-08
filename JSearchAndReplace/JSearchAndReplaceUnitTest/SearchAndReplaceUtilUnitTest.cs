using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSearchAndReplace;
using System.Collections.Generic;
using System.Text;

namespace JSearchAndReplaceUnitTest
{
    [TestClass]
    public class SearchAndReplaceUtilUnitTest
    {
        private bool CompareListOfArray(List<object[]> a, List<object[]> b)
        {
            return CompareJaggedArray(a.ToArray(), b.ToArray());
        }

        private bool CompareJaggedArray(object[][] a, object[][] b)
        {
            if (a == null && b == null)
                return true;
            if (a == null ^ b == null)
                return false;
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
                if (!CompareArray(a[i], b[i]))
                    return false;

            return true;
        }

        private bool CompareArray(object[] a, object[] b)
        {
            if (a == null && b == null)
                return true;
            if (a == null ^ b == null)
                return false;
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
                if (!CompareObject(a[i], b[i]))
                    return false;

            return true;
        }

        private bool CompareObject(object a, object b)
        {
            if (a == null && b == null)
                return true;
            if (a == null ^ b == null)
                return false;

            return a.Equals(b);
        }

        private string JaggedArrayToString(object[][] dblArray)
        {
            char separator = ',';
            char[] separatorArray = new char[] { separator };

            StringBuilder sb = new StringBuilder();
            string arrayStr = string.Empty;

            if (dblArray != null && dblArray.Length > 0)
            {
                for (int i = 0; i < dblArray.Length; i++)
                {
                    StringBuilder line = new StringBuilder();
                    if (dblArray[i] != null)
                    {
                        for (int j = 0; j < dblArray[i].Length; j++)
                        {
                            if (dblArray[i][j] == null)
                                line.Append("").Append(separator);
                            else
                                line.Append(dblArray[i][j].ToString()).Append(separator);
                        }
                    }

                    sb.AppendLine(line.ToString().TrimEnd(separatorArray));
                }

                arrayStr = sb.ToString().Substring(0, sb.Length - Environment.NewLine.Length);  // Trim the last new line added in AppendLine
            }

            return arrayStr;
        }

        private void TestJaggedArrayComparison(object[][] expected, object[][] actual)
        {
            string errorMessage = string.Format("Expected:\n{0}\n\nActual:\n{1}", JaggedArrayToString(expected), JaggedArrayToString(actual));
            Assert.IsTrue(CompareJaggedArray(expected, actual), errorMessage);
        }

        [TestMethod]
        public void GetExistingSet_RemoveDiacritics_CamelCase()
        {
            string[][] set = SearchAndReplaceUtil.GetExistingSetByCommandLineName("RemoveDiacritics");
            Assert.AreSame(SearchAndReplaceContent.RemoveDiacritics, set);
        }

        [TestMethod]
        public void GetExistingSet_RemoveDiacritics_Lowercase()
        {
            string[][] set = SearchAndReplaceUtil.GetExistingSetByCommandLineName("removediacritics");
            Assert.AreSame(SearchAndReplaceContent.RemoveDiacritics, set);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Expected exception for non existing set.")]
        public void GetExistingSet_NonExisting()
        {
            string[][] set = SearchAndReplaceUtil.GetExistingSetByCommandLineName("RandomNonExistingSet");
        }

        [TestMethod]
        public void GetSetFromCSV_EmptyString()
        {
            string csv = string.Empty;
            string[][] csvExpected = new string[][] { };
            string[][] csvActual = SearchAndReplaceUtil.GetSetFromCSV(csv);
            TestJaggedArrayComparison(csvExpected, csvActual);
        }

        [TestMethod]
        public void GetSetFromCSV_Null()
        {
            string csv = null;
            string[][] csvExpected = new string[][] { };
            string[][] csvActual = SearchAndReplaceUtil.GetSetFromCSV(csv);
            TestJaggedArrayComparison(csvExpected, csvActual);
        }

        [TestMethod]
        public void GetSetFromCSV_OneLineSimple()
        {
            string csv = "\"1\",\"2\",\"3\"";

            string[][] csvExpected = new string[][]
            {
                new string[] {"1", "2", "3"}
            };

            string[][] csvActual = SearchAndReplaceUtil.GetSetFromCSV(csv);
            TestJaggedArrayComparison(csvExpected, csvActual);
        }

        [TestMethod]
        public void GetSetFromCSV_OneLineOneCharacter()
        {
            string csv = "\"a\"";

            string[][] csvExpected = new string[][]
            {
                new string[] {"a"}
            };

            string[][] csvActual = SearchAndReplaceUtil.GetSetFromCSV(csv);
            TestJaggedArrayComparison(csvExpected, csvActual);
        }

        [TestMethod]
        public void GetSetFromCSV_OneLineTwoCharacters()
        {
            string csv = "\"a\",\"b\"";

            string[][] csvExpected = new string[][]
            {
                new string[] {"a", "b"}
            };

            string[][] csvActual = SearchAndReplaceUtil.GetSetFromCSV(csv);
            TestJaggedArrayComparison(csvExpected, csvActual);
        }

        [TestMethod]
        public void GetSetFromCSV_TwoLines()
        {
            string csv = "\"a\",\"b\"" + Environment.NewLine + "\"c\",\"d\",\"e\",\"f\",\"g\"";

            string[][] csvExpected = new string[][]
            {
                new string[] {"a", "b"},
                new string[] {"c", "d", "e", "f", "g"}
            };

            string[][] csvActual = SearchAndReplaceUtil.GetSetFromCSV(csv);
            TestJaggedArrayComparison(csvExpected, csvActual);
        }

        [TestMethod]
        public void GetSetFromCSV_ThreeLines()
        {
            string csv = "\"a\",\"b\"" + Environment.NewLine + "\"c\",\"d\",\"e\",\"f\",\"g\"" + Environment.NewLine + "\"regular text with spaces\""; ;

            string[][] csvExpected = new string[][]
            {
                new string[] {"a", "b"},
                new string[] {"c", "d", "e", "f", "g"},
                new string[] {"regular text with spaces"}
            };

            string[][] csvActual = SearchAndReplaceUtil.GetSetFromCSV(csv);
            TestJaggedArrayComparison(csvExpected, csvActual);
        }
    }
}
