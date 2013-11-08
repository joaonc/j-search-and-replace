using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

            // Update the OK button to show a UAC shield icon
            buttonOk.FlatStyle = FlatStyle.System;
            SendMessage(buttonOk.Handle, BCM_SETSHIELD, 0, (IntPtr)1);
        }

        [System.Runtime.InteropServices.DllImport("user32", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        static extern int SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, IntPtr lParam);

        const UInt32 BCM_SETSHIELD = 0x160C;

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (checkBoxEnableRightClick.Checked)
            {
                if (radioButtonAllFiles.Checked)
                {
                    throw new Exception("TODO: implement handling all files in the registry.");
                }
                else if (radioButtonFileExtensions.Checked)
                {
                    string[] fileExtensions = textBoxFileExtensions.Text.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
                    string args = string.Format("{0} \"{1}\"", SetRegistry.SetRegistryCommandLineArg, string.Join(" ", fileExtensions));
                    SetRegistry.StartProcessElevatedPrivileges(args, true);
                }
                else
                    throw new Exception("Need to implement registry option.");
            }

            Close();
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
