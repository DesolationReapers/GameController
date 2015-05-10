using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameController
{
    public partial class AddProgram : Form
    {
        public AddProgram()
        {
            InitializeComponent();
            radService.Checked = true; //Default to Service
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                string result = openFileDialog1.ShowDialog().ToString();
                if (result == DialogResult.OK.ToString())
                {
                  txtPath.Text = openFileDialog1.FileName;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "An Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radService_CheckedChanged(object sender, EventArgs e)
        {
            txtPath.Clear();
            txtPath.Enabled = false;
            btnBrowse.Enabled = false;
        }

        private void radProgram_CheckedChanged(object sender, EventArgs e)
        {
            txtPath.Enabled = true;
            btnBrowse.Enabled = true;
        }

        private void btnAddOK_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
