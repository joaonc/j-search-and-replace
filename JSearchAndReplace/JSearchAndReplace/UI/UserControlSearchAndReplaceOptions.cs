using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSearchAndReplace
{
    public partial class UserControlSearchAndReplaceOptions : UserControl
    {
        public UserControlSearchAndReplaceOptions()
        {
            InitializeComponent();
        }

        private void UserControlSearchAndReplaceOptions_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < SearchAndReplaceUtil.ExistingSets.GetLength(0); i++)
            {
                comboBoxSearchAndReplaceSet.Items.Add(SearchAndReplaceUtil.ExistingSets[i, 1]);
            }
            comboBoxSearchAndReplaceSet.SelectedIndex = 0;

            UpdateUI();
        }

        private void UpdateUI()
        {
            comboBoxSearchAndReplaceSet.Enabled = radioButtonExistingSet.Checked;
            textBoxFileName.Enabled = radioButtonFromFile.Checked;
            buttonFileOpen.Enabled = radioButtonFromFile.Checked;
            textBoxCustom.Enabled = radioButtonCustom.Checked;
        }

        private void radioButtonExistingSet_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void radioButtonFromFile_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void radioButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        public SearchAndReplaceDataSource GetDataSource()
        {
            if (radioButtonExistingSet.Checked)
                return SearchAndReplaceDataSource.ExistingSet;
            if (radioButtonFromFile.Checked)
                return SearchAndReplaceDataSource.FromFile;
            if (radioButtonCustom.Checked)
                return SearchAndReplaceDataSource.Custom;

            throw new Exception("SearchAndReplaceDataSource from radio button needs to be implemented.");
        }

        /// <summary>
        /// Gets the value of the data source, which depends on which data source type is chosen in the UI.
        /// <list type="bullet">
        ///     <term>Existing Set: the readable name of the existing set.</term>
        ///     <term>From File: the filename where the search and replace contents are.</term>
        ///     <term>Custom: the search and replace text put in the text box.</term>
        /// </list>
        /// </summary>
        /// <returns></returns>
        public string GetDataSourceValue()
        {
            switch (GetDataSource())
            {
                case SearchAndReplaceDataSource.ExistingSet:
                    return comboBoxSearchAndReplaceSet.Text;
                case SearchAndReplaceDataSource.FromFile:
                    return textBoxFileName.Text;
                case SearchAndReplaceDataSource.Custom:
                    return textBoxCustom.Text;
                default:
                    throw new Exception("SearchAndReplaceDataSource from radio button needs to be implemented: " + GetDataSource().ToString());
            }
        }

        private void textBoxFileName_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void textBoxFileName_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxFileName.Text = files[0];
        }
    }
}
