namespace JSearchAndReplace
{
    partial class UserControlSearchAndReplaceOptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonExistingSet = new System.Windows.Forms.RadioButton();
            this.radioButtonFromFile = new System.Windows.Forms.RadioButton();
            this.radioButtonCustom = new System.Windows.Forms.RadioButton();
            this.comboBoxSearchAndReplaceSet = new System.Windows.Forms.ComboBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonFileOpen = new System.Windows.Forms.Button();
            this.textBoxCustom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // radioButtonExistingSet
            // 
            this.radioButtonExistingSet.AutoSize = true;
            this.radioButtonExistingSet.Checked = true;
            this.radioButtonExistingSet.Location = new System.Drawing.Point(4, 4);
            this.radioButtonExistingSet.Name = "radioButtonExistingSet";
            this.radioButtonExistingSet.Size = new System.Drawing.Size(80, 17);
            this.radioButtonExistingSet.TabIndex = 0;
            this.radioButtonExistingSet.TabStop = true;
            this.radioButtonExistingSet.Text = "Existing Set";
            this.radioButtonExistingSet.UseVisualStyleBackColor = true;
            this.radioButtonExistingSet.CheckedChanged += new System.EventHandler(this.radioButtonExistingSet_CheckedChanged);
            // 
            // radioButtonFromFile
            // 
            this.radioButtonFromFile.AutoSize = true;
            this.radioButtonFromFile.Location = new System.Drawing.Point(4, 32);
            this.radioButtonFromFile.Name = "radioButtonFromFile";
            this.radioButtonFromFile.Size = new System.Drawing.Size(67, 17);
            this.radioButtonFromFile.TabIndex = 1;
            this.radioButtonFromFile.Text = "From File";
            this.radioButtonFromFile.UseVisualStyleBackColor = true;
            this.radioButtonFromFile.CheckedChanged += new System.EventHandler(this.radioButtonFromFile_CheckedChanged);
            // 
            // radioButtonCustom
            // 
            this.radioButtonCustom.AutoSize = true;
            this.radioButtonCustom.Location = new System.Drawing.Point(4, 59);
            this.radioButtonCustom.Name = "radioButtonCustom";
            this.radioButtonCustom.Size = new System.Drawing.Size(60, 17);
            this.radioButtonCustom.TabIndex = 2;
            this.radioButtonCustom.Text = "Custom";
            this.radioButtonCustom.UseVisualStyleBackColor = true;
            this.radioButtonCustom.CheckedChanged += new System.EventHandler(this.radioButtonCustom_CheckedChanged);
            // 
            // comboBoxSearchAndReplaceSet
            // 
            this.comboBoxSearchAndReplaceSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSearchAndReplaceSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchAndReplaceSet.FormattingEnabled = true;
            this.comboBoxSearchAndReplaceSet.Location = new System.Drawing.Point(96, 4);
            this.comboBoxSearchAndReplaceSet.Name = "comboBoxSearchAndReplaceSet";
            this.comboBoxSearchAndReplaceSet.Size = new System.Drawing.Size(201, 21);
            this.comboBoxSearchAndReplaceSet.TabIndex = 3;
            this.comboBoxSearchAndReplaceSet.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchAndReplaceSet_SelectedIndexChanged);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.AllowDrop = true;
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.Location = new System.Drawing.Point(96, 31);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(201, 20);
            this.textBoxFileName.TabIndex = 4;
            this.textBoxFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxFileName_DragDrop);
            this.textBoxFileName.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxFileName_DragEnter);
            // 
            // buttonFileOpen
            // 
            this.buttonFileOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFileOpen.Location = new System.Drawing.Point(303, 29);
            this.buttonFileOpen.Name = "buttonFileOpen";
            this.buttonFileOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonFileOpen.TabIndex = 5;
            this.buttonFileOpen.Text = "Open";
            this.buttonFileOpen.UseVisualStyleBackColor = true;
            // 
            // textBoxCustom
            // 
            this.textBoxCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCustom.Location = new System.Drawing.Point(96, 58);
            this.textBoxCustom.Multiline = true;
            this.textBoxCustom.Name = "textBoxCustom";
            this.textBoxCustom.Size = new System.Drawing.Size(282, 103);
            this.textBoxCustom.TabIndex = 6;
            // 
            // UserControlSearchAndReplaceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxCustom);
            this.Controls.Add(this.buttonFileOpen);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.comboBoxSearchAndReplaceSet);
            this.Controls.Add(this.radioButtonCustom);
            this.Controls.Add(this.radioButtonFromFile);
            this.Controls.Add(this.radioButtonExistingSet);
            this.Name = "UserControlSearchAndReplaceOptions";
            this.Size = new System.Drawing.Size(382, 164);
            this.Load += new System.EventHandler(this.UserControlSearchAndReplaceOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonExistingSet;
        private System.Windows.Forms.RadioButton radioButtonFromFile;
        private System.Windows.Forms.RadioButton radioButtonCustom;
        private System.Windows.Forms.ComboBox comboBoxSearchAndReplaceSet;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonFileOpen;
        private System.Windows.Forms.TextBox textBoxCustom;
    }
}
