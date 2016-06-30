using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prezas
{
    public partial class Form3 : Form
    {

        string text = "Bienvenido a Alianzas Akros" + Environment.NewLine +
                          "Esta aplicación te permitirá calcular el precio aproximado de nuestras alianzas de manera sencilla y rápida." + Environment.NewLine +
                          "El primer paso es introducir el precio del oro en cuanto salgas de este panel.Una vez introducido el precio del oro solo tendrás que buscar la alianza que deseas y configurarla a tu gusto. " + Environment.NewLine +
                          "Si tienes alguna duda puedes ponerte en contacto con nosotros y nosotros intentaremos resolverla. ";

        public Form3()
        {
            MessageBox.Show(text, "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.Ring.Pmf = double.Parse(pmf_tb.Text);
            Close();
        }

    }
}
