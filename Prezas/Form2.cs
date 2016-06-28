using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prezas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            logo_pb.SizeMode = PictureBoxSizeMode.StretchImage;
            label1.Font = new Font("Algeria", 25, FontStyle.Regular);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.akrosjoyeros.com");
        }

      
    }
}
