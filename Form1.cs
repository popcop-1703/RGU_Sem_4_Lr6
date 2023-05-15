using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        private Store store = new Store();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (discountCheckBox.Checked)
            {
                DiscountProduct product = new DiscountProduct();
                product.Name = nameTextBox.Text;
                product.Price = decimal.Parse(priceTextBox.Text);
                product.Discount = decimal.Parse(discountTextBox.Text);
                store.AddProduct(product);
            }
            else
            {
                RegularProduct product = new RegularProduct();
                product.Name = nameTextBox.Text;
                product.Price = decimal.Parse(priceTextBox.Text);
                store.AddProduct(product);
            }

            nameTextBox.Clear();
            priceTextBox.Clear();
            discountTextBox.Clear();
            discountCheckBox.Checked = false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Product cheapestProduct = store.FindCheapestProduct();

            if (cheapestProduct == null)
            {
                MessageBox.Show("No products found.");
            }
            else
            {
                decimal price;

                if (cheapestProduct is DiscountProduct)
                {
                    price = ((DiscountProduct)cheapestProduct).GetDiscountPrice();
                }
                else
                {
                    price = ((RegularProduct)cheapestProduct).GetPrice();
                }

                MessageBox.Show(string.Format("The cheapest product is {0} at {1:C}.", cheapestProduct.Name, price));
            }
        }
    }
    
}
