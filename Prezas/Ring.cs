using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezas
{
    class Ring
    {

        private double pmf;
        private string texture;
        private float color;
        private float weight;
        private int number;
        private float height;
        private float finalPrice;
        private double diamond;
        private int kilates;
        


        public double Pmf
        {
            get
            {
                return pmf;
            }

            set
            {
                pmf = value;
            }
        }

        public string Texture
        {
            get
            {
                return texture;
            }

            set
            {
                texture = value;
            }
        }

        public float Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public float Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public float Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public float FinalPrice
        {
            get
            {
                return finalPrice;
            }

            set
            {
                finalPrice = value;
            }
        }

        public double Diamond
        {
            get
            {
                return diamond;
            }

            set
            {
                diamond = value;
            }
        }

        public int Kilates
        {
            get
            {
                return kilates;
            }

            set
            {
                kilates = value;
            }
        }

  

        public float getFinalPrice() {
            if (kilates==375) {
                double price9 = ((((pmf * 0.375) * 1.10) + (Color + 1.5)) * 1.28) * Weight;
                double roundprice9 = Math.Round(price9, 2);
                roundprice9 = roundprice9 + Diamond;
                finalPrice = float.Parse(roundprice9.ToString());
            } else if (kilates==750) {
                double price = (Pmf * 0.75 * 1.05 + Color) * 1.25 * Weight;
                double roundprice = Math.Round(price, 2);
                roundprice = roundprice + Diamond;
                finalPrice = float.Parse(roundprice.ToString());
            }
            return finalPrice;
        }


   
    }
}
