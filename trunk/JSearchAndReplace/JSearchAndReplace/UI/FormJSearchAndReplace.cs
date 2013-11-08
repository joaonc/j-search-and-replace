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

        private void FormJSearchAndReplace_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Gets all the parameters from the UI.
        /// </summary>
        /// <returns></returns>
        SearchAndReplaceParameters GetSearchAndReplaceParameters()
        {
            SearchAndReplaceParameters searchAndReplaceParameters = new SearchAndReplaceParameters();

            searchAndReplaceParameters.InputFile = textBoxFileIn.Text.Trim();
            searchAndReplaceParameters.OutputFile = textBoxFileOut.Text.Trim();

            searchAndReplaceParameters.Parse();

            return searchAndReplaceParameters;
        }

        private void textBoxFileIn_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void textBoxFileIn_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxFileIn.Text = files[0];
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            SearchAndReplaceParameters searchAndReplaceParamenters = GetSearchAndReplaceParameters();

            SearchAndReplace.SearchAndReplaceInFile(searchAndReplaceParamenters);
        }

        private void buttonWindowsExplorerIntegration_Click(object sender, EventArgs e)
        {
            FormWindowsExplorerIntegration form = new FormWindowsExplorerIntegration();
            form.ShowDialog();
        }
    }
}
