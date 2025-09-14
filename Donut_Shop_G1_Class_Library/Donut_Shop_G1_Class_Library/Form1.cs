using DonutShop_Library;

namespace Donut_Shop_G1_Class_Library

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //create 2 int variables to hold qty from the textbox input
            int qtyDonut = Convert.ToInt32(txtbDonuts.Text);
            int qtyCoffee = Convert.ToInt32(txtbCoffee.Text);

            //create object for Order class (pass along the input from the textboxes)
            Order o = new Order(qtyDonut, qtyCoffee);

            //Display the order amount 
            MessageBox.Show(o.CalculateTotal().ToString());

        }
    }
}
