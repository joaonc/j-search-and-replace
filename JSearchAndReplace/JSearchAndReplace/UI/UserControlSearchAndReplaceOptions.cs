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
    }
}
