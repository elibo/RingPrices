using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Prezas
{


    public partial class Form1 : Form
    {
        private static Ring ring = new Ring();
        XmlDocument xml = new XmlDocument();
        private List<string> colors;
        private List<string> textures;
        private List<string> weights;
        private List<string> numbers;
        private List<string> heihgts;
        Boolean rp;
        bool mo = false;
        double pdiamond = 0;
        
        string observations = "";
        string reference = "";
        string engarze = "";

        internal static Ring Ring
        {
            get
            {
                return ring;
            }

            set
            {
                ring = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
            makeOrder_bt.Enabled = mo;
            label11.Visible = false;
            pslbl.Visible = false;
            xml.Load("catalogo.xml");
            heihgts = new List<string>();
            heihgts.Add("1,0");
            heihgts.Add("1,3");
            heihgts.Add("1,5");      
            groupBox4.Visible = false;
        }


        private void contactarConNosotrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 contact = new Form2();
            contact.Show();
        }

        private void search_bt_Click(object sender, EventArgs e)
        {
            reference = ref_tb.Text;
            if (reference.Equals(""))
            {
                MessageBox.Show("Debes introducir todos los campos marcados con *","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else {
                clearAll();
                loadBoxes();
                ring_pb.Image = Image.FromFile(@"Images\" + reference + ".jpg");
                ring_pb.SizeMode = PictureBoxSizeMode.CenterImage;
                rp = true;
            }
        
        }

        public void clearAll()
        {
            weights = new List<string>();
            textures = new List<string>();
            colors = new List<string>();
            numbers = new List<string>();
            colors_cb.Items.Clear();
            texture_cb.Items.Clear();
            heights_cb.Items.Clear();
            weighs_cb.Items.Clear();
            nums_cb.Items.Clear();
            diamond_cb.Items.Clear();
            square_rb.Checked = false;
            round_rb.Checked = false;
            kil3_rb.Checked = false;
            kil7_rb.Checked = false;
            obs_rtb.Clear();
            groupBox4.Visible = false;
            if (rp) {
                ring_pb.Image = null;
                detail_pb.Image = null;
                diamond_pb.Image = null;
                texture_cb.ResetText();
                colors_cb.ResetText();
                heights_cb.ResetText();
                weighs_cb.ResetText();
                nums_cb.ResetText();
                diamond_cb.ResetText();
                label11.Visible = false;
                price_lb.ResetText();
                pesolbl.ResetText();
                pslbl.ResetText();  
                rp = false;
            }
            
        }

        private void clean_bt_Click(object sender, EventArgs e)
        {
            clearAll();
            res2_rtb.ResetText();
            res_rtb.ResetText();
            
        }

        private void price_bt_Click(object sender, EventArgs e)
        {

            if (kil3_rb.Checked == false && kil7_rb.Checked == false)
            {
                MessageBox.Show("Debes introducir todos los campos marcados con *", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (colors_cb.SelectedItem==null || weighs_cb.SelectedItem == null|| texture_cb.SelectedItem == null|| heights_cb.SelectedItem == null||
                nums_cb.SelectedItem == null|| diamond_cb.SelectedItem == null) {
                MessageBox.Show("Debes introducir todos los campos marcados con *", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!diamond_cb.SelectedItem.ToString().Equals("Sin diamante") && square_rb.Checked == false && round_rb.Checked == false)
                {
                    MessageBox.Show("Debes introducir todos los campos marcados con *", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            else {
                getPrice();
            }
        }

        public string getSummary() { 
            string engarce = "";
            if (!diamond_cb.SelectedItem.ToString().Equals("Sin diamante")) {
                engarce = engarze;
            }
            string summary = "Referencia de alianza: " + reference + Environment.NewLine +
                "Ley de oro: " + Ring.Kilates.ToString() + Environment.NewLine +
                "Color de la alianza: " + colors_cb.SelectedItem.ToString() + Environment.NewLine +
                "Ancho de la alianza: " + weighs_cb.SelectedItem.ToString() + Environment.NewLine +
                "Tipo de textura: " + texture_cb.SelectedItem.ToString() + Environment.NewLine +
                "Altura alianza: " + heights_cb.SelectedItem.ToString() + Environment.NewLine +
                "Número de palo tatum: " + nums_cb.SelectedItem.ToString() + Environment.NewLine +
                "Tipo de diamante: " + diamond_cb.SelectedItem.ToString() + " " + engarce + Environment.NewLine +
                "Precio aproximado: " + Ring.FinalPrice.ToString() + " euros" + Environment.NewLine +
                "Peso aproximado: " + Ring.Weight.ToString() + " gramos";

            return summary;
        }

        public void getPrice() {
            string colorl = colors_cb.SelectedItem.ToString();
            string weightl = weighs_cb.SelectedItem.ToString();
            float heightl = float.Parse(heights_cb.SelectedItem.ToString());
            int numberl = Int32.Parse(nums_cb.SelectedItem.ToString());
            float color = 0;
            float weight = 0;
            XmlNodeList weighs = xml.SelectNodes("ALIANZAS/ALIANZA[@REF='" + reference + "']/PESOS/PESO[@TIPO='" + weightl + "']");
            XmlNodeList colorss = xml.SelectNodes("ALIANZAS/ALIANZA[@REF='" + reference + "']/COLORES/COLOR[@TIPO='" + colorl + "']");
            foreach (XmlNode c in colorss)
            {
                color = float.Parse(c.InnerText);
            }
            foreach (XmlNode w in weighs)
            {
                weight = float.Parse(w.InnerText);
            }
         
            Ring.Color = color;
            roundWeight(weight, numberl, heightl);
            getDiamond();
            Ring.Diamond = pdiamond;
            pslbl.Visible = true;
            pesolbl.Text = ring.Weight.ToString()+ " grs.";
            label11.Visible = true; 
            price_lb.Text = Ring.getFinalPrice().ToString() + " €";
        }

        public void roundWeight(double weight, int number, float height)
        {
            double weightnr = (weight / 58 * (number + 40)) * height;
            double finalWeight = Math.Round((weightnr * 2) / 2, 2);
            if (kil3_rb.Checked)
            {
                ring.Kilates = 375;
                finalWeight = finalWeight * 0.80;
                finalWeight = Math.Round(finalWeight, 2);
            }
            else if (kil7_rb.Checked)
            {
                ring.Kilates = 750;
                finalWeight = Math.Round(finalWeight, 2);
            }
            Ring.Weight = float.Parse(finalWeight.ToString());
            Ring.Height = height;
            Ring.Number = number;
        }

        public void loadBoxes()
        {
            XmlNodeList ring = xml.SelectNodes("ALIANZAS/ALIANZA[@REF='" + reference + "']");
            XmlNodeList obs = xml.SelectNodes("ALIANZAS/ALIANZA[@REF='" + reference + "']/OBS");


            foreach (XmlNode node in ring)
            {
                XmlNodeList colorslist = node["COLORES"].ChildNodes;
                XmlNodeList textureslist = node["TEXTURAS"].ChildNodes;
                XmlNodeList weightslist = node["PESOS"].ChildNodes;

                foreach (XmlNode color in colorslist)
                {
                    colors.Add(color.Attributes["TIPO"].Value);
                }
                foreach (XmlNode textura in textureslist)
                {
                    textures.Add(textura.InnerText);
                }
                foreach (XmlNode peso in weightslist)
                {
                    weights.Add(peso.Attributes["TIPO"].Value);
                }

            }

            foreach (XmlNode observation in obs)
            {
                observations = observation.InnerText;
                obs_rtb.Text += observations + Environment.NewLine;
            }

            for (int i = 6; i <= 36; i++)
            {
                numbers.Add(i.ToString());
            }
            colors_cb.Items.AddRange(colors.ToArray());
            texture_cb.Items.AddRange(textures.ToArray());
            weighs_cb.Items.AddRange(weights.ToArray());
            heights_cb.Items.AddRange(heihgts.ToArray());
            nums_cb.Items.AddRange(numbers.ToArray());
        }

        private void texture_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string texture = texture_cb.SelectedItem.ToString();
            if (!texture.Equals("Sin Textura"))
            detail_pb.Image = Image.FromFile(@"Images\" + texture + ".jpg");
            detail_pb.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void heights_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sh = heights_cb.SelectedItem.ToString();
            diamond_cb.Items.Clear();
            if (sh.Equals("1,0")) {
                diamond_cb.Items.Add("Sin diamante");
                diamond_cb.Items.Add("1,3mm - Diamante de un punto");
                diamond_cb.Items.Add("1,5mm - Diamante de un punto y medio");
            } else if (sh.Equals("1,3")) {
                diamond_cb.Items.Add("Sin diamante");
                diamond_cb.Items.Add("1,3mm - Diamante de un punto");
                diamond_cb.Items.Add("1,5mm - Diamante de un punto y medio");
                diamond_cb.Items.Add("1,7mm - Diamante de dos puntos");
                diamond_cb.Items.Add("1,8mm - Diamante de dos puntos y medio");
            } else if (sh.Equals("1,5")) {
                diamond_cb.Items.Add("Sin diamante");
                diamond_cb.Items.Add("1,3mm - Diamante de un punto");
                diamond_cb.Items.Add("1,5mm - Diamante de un punto y medio");
                diamond_cb.Items.Add("1,7mm - Diamante de dos puntos");
                diamond_cb.Items.Add("1,8mm - Diamante de dos puntos y medio");
                diamond_cb.Items.Add("2,0mm - Diamante de tres puntos");
                diamond_cb.Items.Add("2,2mm - Diamante de cuatro puntos");
            }
        }

        public void getDiamond() {
            string diamond = diamond_cb.SelectedItem.ToString();
            switch (diamond)
            {
                case "Sin diamante":
                    pdiamond = 0;
                    break;
                case "1,3mm - Diamante de un punto":
                    pdiamond = 16;
                        break;
                case "1,5mm - Diamante de un punto y medio":
                    pdiamond = 20;
                    break;
                case "1,7mm - Diamante de dos puntos":
                    pdiamond = 25;
                    break;
                case "1,8mm - Diamante de dos puntos y medio":
                    pdiamond = 29;
                    break;
                case "2,0mm - Diamante de tres puntos":
                    pdiamond = 32;
                    break;
                case "2,2mm - Diamante de cuatro puntos":
                    pdiamond = 43;
                    break;
                default:
                    break;
            }
        }

        private void round_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (round_rb.Checked) {
                engarze = "redondo";
                diamond_pb.Image = Image.FromFile(@"Images\rounded.jpg");
                diamond_pb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void square_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (square_rb.Checked)
            {
                engarze = "cuadrado";
                diamond_pb.Image = Image.FromFile(@"Images\squared.jpg");
                diamond_pb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void diamond_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sd = diamond_cb.SelectedItem.ToString();
            if (sd.Equals("Sin diamante")) {
                square_rb.Checked = false;
                round_rb.Checked = false;
                groupBox4.Visible = false;
                diamond_pb.Image = null;
            } else
                groupBox4.Visible = true;


        }

        private void ref_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                search_bt.PerformClick();
        }

        private void saver1_bt_Click(object sender, EventArgs e)
        {
            res_rtb.Text=getSummary();
            mo = true;
            makeOrder_bt.Enabled = mo;
        }

        private void saver2_bt_Click(object sender, EventArgs e)
        {
            res2_rtb.Text=getSummary();
            mo = true;
            makeOrder_bt.Enabled = mo;
        }

        private void makeOrder_bt_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.akrosjoyeros.com/contacto_es/");
            Clipboard.SetText("Alianza 1: " + Environment.NewLine
                +res_rtb.Text + Environment.NewLine + Environment.NewLine + "Alianza 2: " + Environment.NewLine  + res2_rtb.Text);
        }
    }
}
