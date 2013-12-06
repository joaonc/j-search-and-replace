namespace JSearchAndReplace
{
    partial class FormWindowsExplorerIntegration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkBoxEnableRightClick = new System.Windows.Forms.CheckBox();
            this.radioButtonAllFiles = new System.Windows.Forms.RadioButton();
            this.radioButtonFileExtensions = new System.Windows.Forms.RadioButton();
            this.textBoxFileExtensions = new System.Windows.Forms.TextBox();
            this.groupBoxFiles = new System.Windows.Forms.GroupBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxSearchAndReplace = new System.Windows.Forms.GroupBox();
            this.userControlSearchAndReplaceOptions = new JSearchAndReplace.UserControlSearchAndReplaceOptions();
            this.labelText = new System.Windows.Forms.Label();
            this.textBoxRightClick = new System.Windows.Forms.TextBox();
            this.groupBoxRightClickEntry = new System.Windows.Forms.GroupBox();
            this.checkBoxMakeDefault = new System.Windows.Forms.CheckBox();
            this.radioButtonAddToExisting = new System.Windows.Forms.RadioButton();
            this.radioButtonReplaceExisting = new System.Windows.Forms.RadioButton();
            this.checkBoxNoUI = new System.Windows.Forms.CheckBox();
            this.groupBoxFiles.SuspendLayout();
            this.groupBoxSearchAndReplace.SuspendLayout();
            this.groupBoxRightClickEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(340, 451);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableRightClick
            // 
            this.checkBoxEnableRightClick.AutoSize = true;
            this.checkBoxEnableRightClick.Checked = true;
            this.checkBoxEnableRightClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnableRightClick.Location = new System.Drawing.Point(12, 12);
            this.checkBoxEnableRightClick.Name = "checkBoxEnableRightClick";
            this.checkBoxEnableRightClick.Size = new System.Drawing.Size(113, 17);
            this.checkBoxEnableRightClick.TabIndex = 2;
            this.checkBoxEnableRightClick.Text = "Enable Right Click";
            this.checkBoxEnableRightClick.UseVisualStyleBackColor = true;
            this.checkBoxEnableRightClick.CheckedChanged += new System.EventHandler(this.checkBoxEnableRightClick_CheckedChanged);
            // 
            // radioButtonAllFiles
            // 
            this.radioButtonAllFiles.AutoSize = true;
            this.radioButtonAllFiles.Location = new System.Drawing.Point(13, 19);
            this.radioButtonAllFiles.Name = "radioButtonAllFiles";
            this.radioButtonAllFiles.Size = new System.Drawing.Size(60, 17);
            this.radioButtonAllFiles.TabIndex = 3;
            this.radioButtonAllFiles.Text = "All Files";
            this.radioButtonAllFiles.UseVisualStyleBackColor = true;
            this.radioButtonAllFiles.CheckedChanged += new System.EventHandler(this.radioButtonAllFiles_CheckedChanged);
            // 
            // radioButtonFileExtensions
            // 
            this.radioButtonFileExtensions.AutoSize = true;
            this.radioButtonFileExtensions.Checked = true;
            this.radioButtonFileExtensions.Location = new System.Drawing.Point(13, 42);
            this.radioButtonFileExtensions.Name = "radioButtonFileExtensions";
            this.radioButtonFileExtensions.Size = new System.Drawing.Size(109, 17);
            this.radioButtonFileExtensions.TabIndex = 4;
            this.radioButtonFileExtensions.TabStop = true;
            this.radioButtonFileExtensions.Text = "These Extensions";
            this.radioButtonFileExtensions.UseVisualStyleBackColor = true;
            this.radioButtonFileExtensions.CheckedChanged += new System.EventHandler(this.radioButtonFileExtensions_CheckedChanged);
            // 
            // textBoxFileExtensions
            // 
            this.textBoxFileExtensions.Location = new System.Drawing.Point(128, 41);
            this.textBoxFileExtensions.Multiline = true;
            this.textBoxFileExtensions.Name = "textBoxFileExtensions";
            this.textBoxFileExtensions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFileExtensions.Size = new System.Drawing.Size(100, 51);
            this.textBoxFileExtensions.TabIndex = 5;
            this.textBoxFileExtensions.Text = "*.srt";
            // 
            // groupBoxFiles
            // 
            this.groupBoxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFiles.Controls.Add(this.textBoxFileExtensions);
            this.groupBoxFiles.Controls.Add(this.radioButtonFileExtensions);
            this.groupBoxFiles.Controls.Add(this.radioButtonAllFiles);
            this.groupBoxFiles.Location = new System.Drawing.Point(12, 148);
            this.groupBoxFiles.Name = "groupBoxFiles";
            this.groupBoxFiles.Size = new System.Drawing.Size(403, 103);
            this.groupBoxFiles.TabIndex = 6;
            this.groupBoxFiles.TabStop = false;
            this.groupBoxFiles.Text = "File Extensions";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(259, 451);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBoxSearchAndReplace
            // 
            this.groupBoxSearchAndReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSearchAndReplace.Controls.Add(this.userControlSearchAndReplaceOptions);
            this.groupBoxSearchAndReplace.Location = new System.Drawing.Point(13, 257);
            this.groupBoxSearchAndReplace.Name = "groupBoxSearchAndReplace";
            this.groupBoxSearchAndReplace.Size = new System.Drawing.Size(402, 184);
            this.groupBoxSearchAndReplace.TabIndex = 8;
            this.groupBoxSearchAndReplace.TabStop = false;
            this.groupBoxSearchAndReplace.Text = "Search and Replace";
            // 
            // userControlSearchAndReplaceOptions
            // 
            this.userControlSearchAndReplaceOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlSearchAndReplaceOptions.Location = new System.Drawing.Point(12, 19);
            this.userControlSearchAndReplaceOptions.Name = "userControlSearchAndReplaceOptions";
            this.userControlSearchAndReplaceOptions.Size = new System.Drawing.Size(384, 159);
            this.userControlSearchAndReplaceOptions.TabIndex = 0;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(6, 24);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(28, 13);
            this.labelText.TabIndex = 9;
            this.labelText.Text = "Text";
            // 
            // textBoxRightClick
            // 
            this.textBoxRightClick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRightClick.Location = new System.Drawing.Point(42, 21);
            this.textBoxRightClick.Name = "textBoxRightClick";
            this.textBoxRightClick.Size = new System.Drawing.Size(353, 20);
            this.textBoxRightClick.TabIndex = 10;
            // 
            // groupBoxRightClickEntry
            // 
            this.groupBoxRightClickEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRightClickEntry.Controls.Add(this.checkBoxMakeDefault);
            this.groupBoxRightClickEntry.Controls.Add(this.radioButtonAddToExisting);
            this.groupBoxRightClickEntry.Controls.Add(this.radioButtonReplaceExisting);
            this.groupBoxRightClickEntry.Controls.Add(this.textBoxRightClick);
            this.groupBoxRightClickEntry.Controls.Add(this.labelText);
            this.groupBoxRightClickEntry.Location = new System.Drawing.Point(13, 35);
            this.groupBoxRightClickEntry.Name = "groupBoxRightClickEntry";
            this.groupBoxRightClickEntry.Size = new System.Drawing.Size(401, 107);
            this.groupBoxRightClickEntry.TabIndex = 11;
            this.groupBoxRightClickEntry.TabStop = false;
            this.groupBoxRightClickEntry.Text = "Right Click Entry";
            // 
            // checkBoxMakeDefault
            // 
            this.checkBoxMakeDefault.AutoSize = true;
            this.checkBoxMakeDefault.Location = new System.Drawing.Point(127, 71);
            this.checkBoxMakeDefault.Name = "checkBoxMakeDefault";
            this.checkBoxMakeDefault.Size = new System.Drawing.Size(90, 17);
            this.checkBoxMakeDefault.TabIndex = 13;
            this.checkBoxMakeDefault.Text = "Make Default";
            this.checkBoxMakeDefault.UseVisualStyleBackColor = true;
            // 
            // radioButtonAddToExisting
            // 
            this.radioButtonAddToExisting.AutoSize = true;
            this.radioButtonAddToExisting.Location = new System.Drawing.Point(12, 71);
            this.radioButtonAddToExisting.Name = "radioButtonAddToExisting";
            this.radioButtonAddToExisting.Size = new System.Drawing.Size(95, 17);
            this.radioButtonAddToExisting.TabIndex = 12;
            this.radioButtonAddToExisting.Text = "Add to Existing";
            this.radioButtonAddToExisting.UseVisualStyleBackColor = true;
            this.radioButtonAddToExisting.CheckedChanged += new System.EventHandler(this.radioButtonAddToExisting_CheckedChanged);
            // 
            // radioButtonReplaceExisting
            // 
            this.radioButtonReplaceExisting.AutoSize = true;
            this.radioButtonReplaceExisting.Checked = true;
            this.radioButtonReplaceExisting.Location = new System.Drawing.Point(12, 47);
            this.radioButtonReplaceExisting.Name = "radioButtonReplaceExisting";
            this.radioButtonReplaceExisting.Size = new System.Drawing.Size(101, 17);
            this.radioButtonReplaceExisting.TabIndex = 11;
            this.radioButtonReplaceExisting.TabStop = true;
            this.radioButtonReplaceExisting.Text = "ReplaceExisting";
            this.radioButtonReplaceExisting.UseVisualStyleBackColor = true;
            this.radioButtonReplaceExisting.CheckedChanged += new System.EventHandler(this.radioButtonRightClickReplaceExisting_CheckedChanged);
            // 
            // checkBoxNoUI
            // 
            this.checkBoxNoUI.AutoSize = true;
            this.checkBoxNoUI.Location = new System.Drawing.Point(187, 12);
            this.checkBoxNoUI.Name = "checkBoxNoUI";
            this.checkBoxNoUI.Size = new System.Drawing.Size(119, 17);
            this.checkBoxNoUI.TabIndex = 12;
            this.checkBoxNoUI.Text = "Execute Without UI";
            this.checkBoxNoUI.UseVisualStyleBackColor = true;
            // 
            // FormWindowsExplorerIntegration
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(427, 486);
            this.Controls.Add(this.checkBoxNoUI);
            this.Controls.Add(this.groupBoxSearchAndReplace);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.checkBoxEnableRightClick);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxFiles);
            this.Controls.Add(this.groupBoxRightClickEntry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(442, 410);
            this.Name = "FormWindowsExplorerIntegration";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Windows Explorer Integration";
            this.Load += new System.EventHandler(this.FormWindowsExplorerIntegration_Load);
            this.groupBoxFiles.ResumeLayout(false);
            this.groupBoxFiles.PerformLayout();
            this.groupBoxSearchAndReplace.ResumeLayout(false);
            this.groupBoxRightClickEntry.ResumeLayout(false);
            this.groupBoxRightClickEntry.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.CheckBox checkBoxEnableRightClick;
        private System.Windows.Forms.RadioButton radioButtonAllFiles;
        private System.Windows.Forms.RadioButton radioButtonFileExtensions;
        private System.Windows.Forms.TextBox textBoxFileExtensions;
        private System.Windows.Forms.GroupBox groupBoxFiles;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBoxSearchAndReplace;
        private UserControlSearchAndReplaceOptions userControlSearchAndReplaceOptions;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.TextBox textBoxRightClick;
        private System.Windows.Forms.GroupBox groupBoxRightClickEntry;
        private System.Windows.Forms.CheckBox checkBoxMakeDefault;
        private System.Windows.Forms.RadioButton radioButtonAddToExisting;
        private System.Windows.Forms.RadioButton radioButtonReplaceExisting;
        private System.Windows.Forms.CheckBox checkBoxNoUI;
    }
}