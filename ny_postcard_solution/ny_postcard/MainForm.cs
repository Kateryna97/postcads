using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ny_postcard
{
    public partial class MainForm : Form
    {
        private bool mIgnoreFormClosing = false;
        //
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mIgnoreFormClosing) return;
            //
            if (MessageBox.Show("Ви дійсно бажаєте вийти з програми?",
                       "Вихід з програми", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
            else
            {
                //_mainDataModel.CloseDbConnect();
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
