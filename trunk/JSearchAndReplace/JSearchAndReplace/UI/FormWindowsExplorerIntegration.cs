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
            SetSearchAndReplaceParameters(new SearchAndReplaceParameters());
        }

        public FormWindowsExplorerIntegration(SearchAndReplaceParameters searchAndReplaceParameters)
        {
            InitializeComponent();
            SetSearchAndReplaceParameters(searchAndReplaceParameters);
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
                StringBuilder args = new StringBuilder();

                //
                // Options to be passed to the SearchAndReplace application when running elevated to register
                //

                args.Append(SetRegistry.SetRegistryCommandLineArg).Append(" ");

                // Right click options
                if(!string.IsNullOrEmpty(textBoxRightClick.Text.Trim()))
                    args.AppendFormat("-rightclicktext {0} ", textBoxRightClick.Text.Trim());

                if (radioButtonReplaceExisting.Checked)
                    args.Append("-replaceexisting ");
                else if (radioButtonAddToExisting.Checked)
                {
                    args.Append("-addtoexisting ");
                    if (checkBoxMakeDefault.Checked)
                        args.Append("-makedefault ");
                }
                else
                    throw new Exception("Need to implement registry option related to right click options.");

                // File extensions
                if (radioButtonAllFiles.Checked)
                {
                    throw new Exception("TODO: implement handling all files in the registry.");
                }
                else if (radioButtonFileExtensions.Checked)
                {
                    string[] fileExtensions = textBoxFileExtensions.Text.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
                    args.AppendFormat("-extensions \"{1}\" ", string.Join(" ", fileExtensions));
                }
                else
                    throw new Exception("Need to implement registry option related to file extensions.");

                //
                // Options to be passed to the SearchAndReplace application when running from right click
                //

                //SearchAndReplaceParameters searchAndReplaceParameters = userControlSearchAndReplaceOptions.get

                SetRegistry.StartProcessElevatedPrivileges(args.ToString().Trim(), true);
            }

            Close();
        }

        public void SetSearchAndReplaceParameters(SearchAndReplaceParameters searchAndReplaceParameters)
        {
            checkBoxNoUI.Checked = searchAndReplaceParameters.NoUI;
            userControlSearchAndReplaceOptions.SetSearchAndReplaceParameters(searchAndReplaceParameters);
        }

        private void UpdateUI()
        {
            checkBoxMakeDefault.Enabled = radioButtonAddToExisting.Checked;

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

        private void radioButtonRightClickReplaceExisting_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void radioButtonAddToExisting_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
