using System;
using System.Linq;
using System.Windows.Forms;

namespace mtanksl.ShamirSecretSharing.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private ShamirSecretSharing sss;

        private void MainForm_Load(object sender, EventArgs e)
        {
            sss = new ShamirSecretSharing();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sss.Dispose();
        }

        private void buttonSplit_Click(object sender, EventArgs e)
        {
            try
            {
                var shares = sss.Split((int)numericUpDownMinimumShares.Value, (int)numericUpDownTotalShares.Value, textBoxMessage.Text);

                textBoxShares.Text = string.Join(Environment.NewLine, shares.Select(s => s.ToString() ).ToArray() );

                tabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            try
            {
                var message = sss.Join(textBoxShares.Text.Split(Environment.NewLine).Select(s => Share.Parse(s) ).ToArray() );

                textBoxMessage.Text = message;

                tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}