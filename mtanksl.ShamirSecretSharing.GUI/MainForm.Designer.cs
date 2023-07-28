using System.Drawing;
using System.Windows.Forms;

namespace mtanksl.ShamirSecretSharing.GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm) );
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            buttonJoin = new Button();
            textBoxShares = new TextBox();
            label5 = new Label();
            tabPage2 = new TabPage();
            buttonSplit = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            numericUpDownMinimumShares = new NumericUpDown();
            numericUpDownTotalShares = new NumericUpDown();
            textBoxMessage = new TextBox();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinimumShares).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTotalShares).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(732, 276);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(buttonJoin);
            tabPage1.Controls.Add(textBoxShares);
            tabPage1.Controls.Add(label5);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(724, 248);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Join";
            // 
            // buttonJoin
            // 
            buttonJoin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonJoin.Location = new Point(8, 190);
            buttonJoin.Name = "buttonJoin";
            buttonJoin.Size = new Size(707, 50);
            buttonJoin.TabIndex = 2;
            buttonJoin.Text = "&Join Shares";
            buttonJoin.UseVisualStyleBackColor = true;
            buttonJoin.Click += buttonJoin_Click;
            // 
            // textBoxShares
            // 
            textBoxShares.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxShares.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxShares.Location = new Point(8, 21);
            textBoxShares.Multiline = true;
            textBoxShares.Name = "textBoxShares";
            textBoxShares.ScrollBars = ScrollBars.Both;
            textBoxShares.Size = new Size(707, 163);
            textBoxShares.TabIndex = 1;
            textBoxShares.Text = resources.GetString("textBoxShares.Text");
            textBoxShares.WordWrap = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 3);
            label5.Name = "label5";
            label5.Size = new Size(425, 15);
            label5.TabIndex = 0;
            label5.Text = "Enter enough shares to recover the message (separate each share by a new line)";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Controls.Add(buttonSplit);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(numericUpDownMinimumShares);
            tabPage2.Controls.Add(numericUpDownTotalShares);
            tabPage2.Controls.Add(textBoxMessage);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(724, 248);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Split";
            // 
            // buttonSplit
            // 
            buttonSplit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonSplit.Location = new Point(8, 190);
            buttonSplit.Name = "buttonSplit";
            buttonSplit.Size = new Size(707, 50);
            buttonSplit.TabIndex = 7;
            buttonSplit.Text = "&Split Message";
            buttonSplit.UseVisualStyleBackColor = true;
            buttonSplit.Click += buttonSplit_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(432, 164);
            label4.Name = "label4";
            label4.Size = new Size(277, 15);
            label4.TabIndex = 6;
            label4.Text = "of those shares can be used to restore the message.";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(269, 164);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 4;
            label3.Text = "shares so that any";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(8, 164);
            label2.Name = "label2";
            label2.Size = new Size(199, 15);
            label2.TabIndex = 2;
            label2.Text = "I would like to split the message into";
            // 
            // numericUpDownMinimumShares
            // 
            numericUpDownMinimumShares.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numericUpDownMinimumShares.Location = new Point(376, 162);
            numericUpDownMinimumShares.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDownMinimumShares.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDownMinimumShares.Name = "numericUpDownMinimumShares";
            numericUpDownMinimumShares.Size = new Size(50, 23);
            numericUpDownMinimumShares.TabIndex = 5;
            numericUpDownMinimumShares.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // numericUpDownTotalShares
            // 
            numericUpDownTotalShares.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numericUpDownTotalShares.Location = new Point(213, 162);
            numericUpDownTotalShares.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDownTotalShares.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDownTotalShares.Name = "numericUpDownTotalShares";
            numericUpDownTotalShares.Size = new Size(50, 23);
            numericUpDownTotalShares.TabIndex = 3;
            numericUpDownTotalShares.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // textBoxMessage
            // 
            textBoxMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMessage.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMessage.Location = new Point(8, 21);
            textBoxMessage.Multiline = true;
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.ScrollBars = ScrollBars.Vertical;
            textBoxMessage.Size = new Size(707, 138);
            textBoxMessage.TabIndex = 1;
            textBoxMessage.Text = "Share your knowledge. It is a way to achieve immortality.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 3);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "Message";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 276);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(748, 315);
            Name = "MainForm";
            Text = "mtanksl's Shamir Secret Sharing";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinimumShares).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTotalShares).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBoxMessage;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private NumericUpDown numericUpDownMinimumShares;
        private NumericUpDown numericUpDownTotalShares;
        private Button buttonSplit;
        private Button buttonJoin;
        private TextBox textBoxShares;
        private Label label5;
    }
}