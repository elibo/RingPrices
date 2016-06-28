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
        double pdiamond = 0;

        string observations = "";
        string reference = "";

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
            label11.Visible = false;
            xml.Load("catalogo.xml");
            heihgts = new List<string>();
            heihgts.Add("1,0");
            heihgts.Add("1,3");
            heihgts.Add("1,5");
        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 gold = new Form3();
            gold.Show();
        }

        private void contactarConNosotrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 contact = new Form2();
            contact.Show();
        }

        private void search_bt_Click(object sender, EventArgs e)
        {
            reference = ref_tb.Text;
            clearAll();
            loadBoxes();
            ring_pb.Image = Image.FromFile(@"Images\" + reference + ".jpg");
            ring_pb.SizeMode = PictureBoxSizeMode.StretchImage;
            rp = true;
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
            obs_rtb.Clear(); 
            if (rp) {
                ring_pb.Image = null;
                detail_pb.Image = null;
                diamond_pb.Image = null;
                texture_cb.ResetText();
                ref_tb.Clear();
                colors_cb.ResetText();
                heights_cb.ResetText();
                weighs_cb.ResetText();
                nums_cb.ResetText();
                diamond_cb.ResetText();
                label11.Visible = false;
                label12.ResetText();   
                rp = false;
            }
            
        }

        private void clean_bt_Click(object sender, EventArgs e)
        {
            clearAll();
            
        }

        private void price_bt_Click(object sender, EventArgs e)
        {
            getPrice();
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
            label11.Visible = true;
            getDiamond();
            Ring.Diamond = pdiamond;
            label12.Text = Ring.getFinalPrice().ToString() + " €";
        }

        public void roundWeight(double weight, int number, float height)
        {
            double weightnr = (weight / 58 * (number + 40)) * height;
            double finalWeight = Math.Round((weightnr * 2) / 2, 2);
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
            detail_pb.Image = Image.FromFile(@"Images\" + texture + ".jpg");
        }

        private void heights_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sh = heights_cb.SelectedItem.ToString();
            diamond_cb.Items.Clear();
            if (sh.Equals("1,0")) {
                diamond_cb.Items.Add("Sin diamante");
                diamond_cb.Items.Add("1,3mm");
                diamond_cb.Items.Add("1,5mm");
            } else if (sh.Equals("1,3")) {
                diamond_cb.Items.Add("Sin diamante");
                diamond_cb.Items.Add("1,3mm");
                diamond_cb.Items.Add("1,5mm");
                diamond_cb.Items.Add("1,7mm");
                diamond_cb.Items.Add("1,8mm");
            } else if (sh.Equals("1,5")) {
                diamond_cb.Items.Add("Sin diamante");
                diamond_cb.Items.Add("1,3mm");
                diamond_cb.Items.Add("1,5mm");
                diamond_cb.Items.Add("1,7mm");
                diamond_cb.Items.Add("1,8mm");
                diamond_cb.Items.Add("2,0mm");
                diamond_cb.Items.Add("2,2mm");
            }
        }

        public void getDiamond() {
            string diamond = diamond_cb.SelectedItem.ToString();
            switch (diamond)
            {
                case "Sin diamante":
                    pdiamond = 0;
                    break;
                case "1,3mm": pdiamond = 16;
                        break;
                case "1,5mm":
                    pdiamond = 20;
                    break;
                case "1,7mm":
                    pdiamond = 25;
                    break;
                case "1,8mm":
                    pdiamond = 29;
                    break;
                case "2,0mm":
                    pdiamond = 32;
                    break;
                case "2,2mm":
                    pdiamond = 43;
                    break;
                default:
                    break;
            }
        }

        private void round_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (round_rb.Checked) {
                diamond_pb.Image = Image.FromFile(@"Images\rounded.jpg");
                diamond_pb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void square_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (square_rb.Checked)
            {
                diamond_pb.Image = Image.FromFile(@"Images\squared.jpg");
                diamond_pb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
