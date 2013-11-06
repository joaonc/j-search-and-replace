using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using JSearchAndReplace;

namespace JSearchAndReplace
{
    public partial class FormJSearchAndReplace : Form
    {
        public FormJSearchAndReplace()
        {
            InitializeComponent();
        }

        SearchAndReplaceParameters GetSearchAndReplaceParameters()
        {
            SearchAndReplaceParameters searchAndReplaceParameters = new SearchAndReplaceParameters();

            searchAndReplaceParameters.InputFile = textBoxFileIn.Text.Trim();
            searchAndReplaceParameters.OutputFile = textBoxFileOut.Text.Trim();

            searchAndReplaceParameters.Parse();

            return searchAndReplaceParameters;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            SearchAndReplaceParameters searchAndReplaceParamenters = GetSearchAndReplaceParameters();

            SearchAndReplace.SearchAndReplaceInFile(searchAndReplaceParamenters);
        }
    }
}
