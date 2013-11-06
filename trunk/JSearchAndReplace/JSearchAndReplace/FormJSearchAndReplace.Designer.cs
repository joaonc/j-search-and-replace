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
            this.SuspendLayout();
            // 
            // textBoxFileIn
            // 
            this.textBoxFileIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileIn.Location = new System.Drawing.Point(13, 34);
            this.textBoxFileIn.Name = "textBoxFileIn";
            this.textBoxFileIn.Size = new System.Drawing.Size(384, 20);
            this.textBoxFileIn.TabIndex = 0;
            this.textBoxFileIn.Text = "TestSearchAndReplace.srt";
            // 
            // buttonFileIn
            // 
            this.buttonFileIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFileIn.Location = new System.Drawing.Point(403, 32);
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
            this.textBoxFileOut.Location = new System.Drawing.Point(13, 61);
            this.textBoxFileOut.Name = "textBoxFileOut";
            this.textBoxFileOut.Size = new System.Drawing.Size(384, 20);
            this.textBoxFileOut.TabIndex = 2;
            this.textBoxFileOut.Text = "<n>.out<e>";
            // 
            // buttonFileOut
            // 
            this.buttonFileOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFileOut.Location = new System.Drawing.Point(403, 59);
            this.buttonFileOut.Name = "buttonFileOut";
            this.buttonFileOut.Size = new System.Drawing.Size(75, 23);
            this.buttonFileOut.TabIndex = 3;
            this.buttonFileOut.Text = "Open";
            this.buttonFileOut.UseVisualStyleBackColor = true;
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.Location = new System.Drawing.Point(403, 117);
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
            // FormJSearchAndReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 152);
            this.Controls.Add(this.textBoxInstructions);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.buttonFileOut);
            this.Controls.Add(this.textBoxFileOut);
            this.Controls.Add(this.buttonFileIn);
            this.Controls.Add(this.textBoxFileIn);
            this.Name = "FormJSearchAndReplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "J Search and Replace";
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
    }
}

