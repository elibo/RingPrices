using System;
using System.Collections.Generic;
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

        public float getFinalPrice() {
            double price = (Pmf * 0.75 * 1.05 + color) * 1.25 * Weight;
            double roundprice=Math.Round(price , 1);
            roundprice = roundprice + Diamond;
            finalPrice = float.Parse(roundprice.ToString());

            return finalPrice;
        }
    }
}
