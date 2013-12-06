namespace JSearchAndReplace
{
    partial class FormJSearchAndReplace
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
            this.textBoxFileIn = new System.Windows.Forms.TextBox();
            this.buttonFileIn = new System.Windows.Forms.Button();
            this.textBoxFileOut = new System.Windows.Forms.TextBox();
            this.buttonFileOut = new System.Windows.Forms.Button();
            this.buttonGo = new System.Windows.Forms.Button();
            this.textBoxInstructions = new System.Windows.Forms.TextBox();
            this.labelFileIn = new System.Windows.Forms.Label();
            this.labelFileOut = new System.Windows.Forms.Label();
            this.labelSearchAndReplaceText = new System.Windows.Forms.Label();
            this.buttonWindowsExplorerIntegration = new System.Windows.Forms.Button();
            this.userControlSearchAndReplaceOptions1 = new JSearchAndReplace.UserControlSearchAndReplaceOptions();
            this.SuspendLayout();
            // 
            // textBoxFileIn
            // 
            this.textBoxFileIn.AllowDrop = true;
            this.textBoxFileIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileIn.Location = new System.Drawing.Point(71, 34);
            this.textBoxFileIn.Name = "textBoxFileIn";
            this.textBoxFileIn.Size = new System.Drawing.Size(255, 20);
            this.textBoxFileIn.TabIndex = 0;
            this.textBoxFileIn.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxFileIn_DragDrop);
            this.textBoxFileIn.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxFileIn_DragEnter);
            this.textBoxFileIn.Enter += new System.EventHandler(this.textBoxFileIn_Enter);
            // 
            // buttonFileIn
            // 
            this.buttonFileIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFileIn.Location = new System.Drawing.Point(332, 32);
            this.buttonFileIn.Name = "buttonFileIn";
            this.buttonFileIn.Size = new System.Drawing.Size(75, 23);
            this.buttonFileIn.TabIndex = 1;
            this.buttonFileIn.Text = "Open";
            this.buttonFileIn.UseVisualStyleBackColor = true;
            // 
            // textBoxFileOut
            // 
            this.textBoxFileOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileOut.Location = new System.Drawing.Point(71, 61);
            this.textBoxFileOut.Name = "textBoxFileOut";
            this.textBoxFileOut.Size = new System.Drawing.Size(255, 20);
            this.textBoxFileOut.TabIndex = 2;
            this.textBoxFileOut.Text = "<n>.out.<e>";
            this.textBoxFileOut.Enter += new System.EventHandler(this.textBoxFileOut_Enter);
            // 
            // buttonFileOut
            // 
            this.buttonFileOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFileOut.Location = new System.Drawing.Point(332, 59);
            this.buttonFileOut.Name = "buttonFileOut";
            this.buttonFileOut.Size = new System.Drawing.Size(75, 23);
            this.buttonFileOut.TabIndex = 3;
            this.buttonFileOut.Text = "Open";
            this.buttonFileOut.UseVisualStyleBackColor = true;
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.Location = new System.Drawing.Point(332, 298);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 4;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // textBoxInstructions
            // 
            this.textBoxInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInstructions.Location = new System.Drawing.Point(13, 88);
            this.textBoxInstructions.Multiline = true;
            this.textBoxInstructions.Name = "textBoxInstructions";
            this.textBoxInstructions.ReadOnly = true;
            this.textBoxInstructions.Size = new System.Drawing.Size(233, 52);
            this.textBoxInstructions.TabIndex = 5;
            this.textBoxInstructions.Text = "<n> Filename\r\n<e> Extension\r\n<s:\"ab\" r:\"cd\"> Search and replace";
            // 
            // labelFileIn
            // 
            this.labelFileIn.AutoSize = true;
            this.labelFileIn.Location = new System.Drawing.Point(12, 37);
            this.labelFileIn.Name = "labelFileIn";
            this.labelFileIn.Size = new System.Drawing.Size(50, 13);
            this.labelFileIn.TabIndex = 6;
            this.labelFileIn.Text = "Input File";
            // 
            // labelFileOut
            // 
            this.labelFileOut.AutoSize = true;
            this.labelFileOut.Location = new System.Drawing.Point(12, 64);
            this.labelFileOut.Name = "labelFileOut";
            this.labelFileOut.Size = new System.Drawing.Size(58, 13);
            this.labelFileOut.TabIndex = 7;
            this.labelFileOut.Text = "Output File";
            // 
            // labelSearchAndReplaceText
            // 
            this.labelSearchAndReplaceText.AutoSize = true;
            this.labelSearchAndReplaceText.Location = new System.Drawing.Point(13, 147);
            this.labelSearchAndReplaceText.Name = "labelSearchAndReplaceText";
            this.labelSearchAndReplaceText.Size = new System.Drawing.Size(120, 13);
            this.labelSearchAndReplaceText.TabIndex = 8;
            this.labelSearchAndReplaceText.Text = "Search and replace text";
            // 
            // buttonWindowsExplorerIntegration
            // 
            this.buttonWindowsExplorerIntegration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonWindowsExplorerIntegration.Location = new System.Drawing.Point(12, 298);
            this.buttonWindowsExplorerIntegration.Name = "buttonWindowsExplorerIntegration";
            this.buttonWindowsExplorerIntegration.Size = new System.Drawing.Size(121, 23);
            this.buttonWindowsExplorerIntegration.TabIndex = 13;
            this.buttonWindowsExplorerIntegration.Text = "Explorer Integration";
            this.buttonWindowsExplorerIntegration.UseVisualStyleBackColor = true;
            this.buttonWindowsExplorerIntegration.Click += new System.EventHandler(this.buttonWindowsExplorerIntegration_Click);
            // 
            // userControlSearchAndReplaceOptions1
            // 
            this.userControlSearchAndReplaceOptions1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlSearchAndReplaceOptions1.Location = new System.Drawing.Point(12, 163);
            this.userControlSearchAndReplaceOptions1.Name = "userControlSearchAndReplaceOptions1";
            this.userControlSearchAndReplaceOptions1.Size = new System.Drawing.Size(395, 129);
            this.userControlSearchAndReplaceOptions1.TabIndex = 14;
            // 
            // FormJSearchAndReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 333);
            this.Controls.Add(this.userControlSearchAndReplaceOptions1);
            this.Controls.Add(this.buttonWindowsExplorerIntegration);
            this.Controls.Add(this.labelSearchAndReplaceText);
            this.Controls.Add(this.labelFileOut);
            this.Controls.Add(this.labelFileIn);
            this.Controls.Add(this.textBoxInstructions);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.buttonFileOut);
            this.Controls.Add(this.textBoxFileOut);
            this.Controls.Add(this.buttonFileIn);
            this.Controls.Add(this.textBoxFileIn);
            this.Name = "FormJSearchAndReplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "J Search and Replace";
            this.Load += new System.EventHandler(this.FormJSearchAndReplace_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFileIn;
        private System.Windows.Forms.Button buttonFileIn;
        private System.Windows.Forms.TextBox textBoxFileOut;
        private System.Windows.Forms.Button buttonFileOut;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox textBoxInstructions;
        private System.Windows.Forms.Label labelFileIn;
        private System.Windows.Forms.Label labelFileOut;
        private System.Windows.Forms.Label labelSearchAndReplaceText;
        private System.Windows.Forms.Button buttonWindowsExplorerIntegration;
        private UserControlSearchAndReplaceOptions userControlSearchAndReplaceOptions1;
    }
}

