using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("ALGERIA.ttf");
            label1.Font = new Font(pfc.Families[0], 32, FontStyle.Regular);
            logo_pb.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.akrosjoyeros.com");
        }

      
    }
}
