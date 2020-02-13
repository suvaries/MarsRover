using MarsRoverLibrary;
using System;
using System.Windows.Forms;

namespace MarsRover
{
    public partial class MarsRoverForm : Form
    {
        public MarsRoverForm()
        {
            InitializeComponent();

            txtOutput.ReadOnly = true;
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            try
            {
                txtOutput.Text = string.Empty;
                var input = txtInput.Text;
                var output = MarsRoverCalculator.Calculate(input);
                txtOutput.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
