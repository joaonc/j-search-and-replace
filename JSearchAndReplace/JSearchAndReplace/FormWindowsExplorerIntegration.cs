using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSearchAndReplace
{
    public partial class FormWindowsExplorerIntegration : Form
    {
        public FormWindowsExplorerIntegration()
        {
            InitializeComponent();
        }

        private void FormWindowsExplorerIntegration_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void SetRegistry()
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SetRegistry();
        }

        private void UpdateUI()
        {
            groupBoxFiles.Enabled = checkBoxEnableRightClick.Checked;
            groupBoxSearchAndReplace.Enabled = checkBoxEnableRightClick.Checked;

            textBoxFileExtensions.Enabled = radioButtonFileExtensions.Checked;
        }

        private void checkBoxEnableRightClick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void radioButtonAllFiles_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void radioButtonFileExtensions_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
