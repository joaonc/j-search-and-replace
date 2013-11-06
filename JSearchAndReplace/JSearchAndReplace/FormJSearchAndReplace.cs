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
            comboBoxSearchAndReplaceSet.Items.Add("Remove Diacritics");
            comboBoxSearchAndReplaceSet.SelectedIndex = 0;

            UpdateUI();
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

        private void UpdateUI()
        {
            textBoxFileSearchAndReplace.Enabled = radioButtonSearchAndReplaceFile.Checked;
            comboBoxSearchAndReplaceSet.Enabled = radioButtonSearchAndReplaceSet.Checked;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            SearchAndReplaceParameters searchAndReplaceParamenters = GetSearchAndReplaceParameters();

            SearchAndReplace.SearchAndReplaceInFile(searchAndReplaceParamenters);
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

        private void textBoxFileSearchAndReplace_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void textBoxFileSearchAndReplace_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxFileSearchAndReplace.Text = files[0];
        }

        private void radioButtonSearchAndReplaceFile_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void radioButtonSearchAndReplaceSet_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void buttonWindowsExplorerIntegration_Click(object sender, EventArgs e)
        {
            FormWindowsExplorerIntegration form = new FormWindowsExplorerIntegration();
            form.ShowDialog();
        }
    }
}
