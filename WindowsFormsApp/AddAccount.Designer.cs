namespace WindowsFormsApp
{
    partial class AddAccount
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
            this.debitGroupBox = new System.Windows.Forms.GroupBox();
            this.creditGroupBox = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.debitGroupBox.SuspendLayout();
            this.creditGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // debitGroupBox
            // 
            this.debitGroupBox.Controls.Add(this.label3);
            this.debitGroupBox.Location = new System.Drawing.Point(0, 0);
            this.debitGroupBox.Name = "debitGroupBox";
            this.debitGroupBox.Size = new System.Drawing.Size(560, 330);
            this.debitGroupBox.TabIndex = 1;
            this.debitGroupBox.TabStop = false;
            // 
            // creditGroupBox
            // 
            this.creditGroupBox.Controls.Add(this.label2);
            this.creditGroupBox.Controls.Add(this.debitGroupBox);
            this.creditGroupBox.Location = new System.Drawing.Point(12, 39);
            this.creditGroupBox.Name = "creditGroupBox";
            this.creditGroupBox.Size = new System.Drawing.Size(560, 330);
            this.creditGroupBox.TabIndex = 0;
            this.creditGroupBox.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(256, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selectaţi tipul contului:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // AddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.creditGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 420);
            this.MinimumSize = new System.Drawing.Size(600, 420);
            this.Name = "AddAccount";
            this.Text = "Adăugare Cont Nou";
            this.debitGroupBox.ResumeLayout(false);
            this.debitGroupBox.PerformLayout();
            this.creditGroupBox.ResumeLayout(false);
            this.creditGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox debitGroupBox;
        private System.Windows.Forms.GroupBox creditGroupBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}