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
    public partial class WaitWindowMessage : Form
    {
        public WaitWindowMessage()
        {
            InitializeComponent();
        }

        public void SetErrorMessage(string _TextInfo)
        {
            labelMessage.Text = _TextInfo;
            labelMessage.ForeColor = Color.White;
            this.BackColor = Color.Red;//SystemColors.Control;
            labelMessage.Refresh();
            this.Refresh();
        }

        public void SetInfoMessage(string _TextInfo)
        {
            labelMessage.Text = _TextInfo;
            //labelMessage.ForeColor = SystemColors.ControlText;
            labelMessage.Refresh();
            this.Refresh();
        }

    }
}
