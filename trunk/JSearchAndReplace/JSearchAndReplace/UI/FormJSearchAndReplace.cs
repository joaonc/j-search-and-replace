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
            SetSearchAndReplaceParameters(new SearchAndReplaceParameters());
        }

        public FormJSearchAndReplace(SearchAndReplaceParameters searchAndReplaceParameters)
        {
            InitializeComponent();
            SetSearchAndReplaceParameters(searchAndReplaceParameters);
        }

        private void FormJSearchAndReplace_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Sets/updates the search and replace paramenters. Updates the UI as well.
        /// </summary>
        /// <param name="searchAndReplaceParameters">The new SearchAndReplaceParameters object.</param>
        /// <returns></returns>
        public void SetSearchAndReplaceParameters(SearchAndReplaceParameters searchAndReplaceParameters)
        {
            textBoxFileIn.Text = searchAndReplaceParameters.InputFile;
            textBoxFileOut.Text = searchAndReplaceParameters.OutputFile;
        }

        /// <summary>
        /// Gets all the parameters from the UI.
        /// </summary>
        /// <returns></returns>
        public SearchAndReplaceParameters GetSearchAndReplaceParameters()
        {
            SearchAndReplaceParameters searchAndReplaceParameters = new SearchAndReplaceParameters();

            searchAndReplaceParameters.InputFile = textBoxFileIn.Text.Trim();
            searchAndReplaceParameters.OutputFile = textBoxFileOut.Text.Trim();

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
            SearchAndReplaceParameters searchAndReplaceParameters = GetSearchAndReplaceParameters();
            SearchAndReplace.SearchAndReplaceInFile(searchAndReplaceParameters);
        }

        private void buttonWindowsExplorerIntegration_Click(object sender, EventArgs e)
        {
            FormWindowsExplorerIntegration form = new FormWindowsExplorerIntegration(GetSearchAndReplaceParameters());
            form.ShowDialog();
        }

        private void textBoxFileIn_Enter(object sender, EventArgs e)
        {
            textBoxFileIn.SelectAll();
        }

        private void textBoxFileOut_Enter(object sender, EventArgs e)
        {
            textBoxFileOut.SelectAll();
        }
    }
}
