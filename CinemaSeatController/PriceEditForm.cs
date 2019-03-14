using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaSeatController
{
    public partial class Price : Form
    {

        private bool premium;

        public Price(bool premium)
        {
            this.premium = premium;
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            if (textBox1.Text == " ") return;
            if (!Regex.IsMatch(textBox1.Text, @"^\d+$"))
            {
                Console.WriteLine("Price must be numeric!");
                return;
            }
            if (premium)
            {
                SeatController.getInstance().setPremiumPrice(int.Parse(textBox1.Text));
            }
            else
            {
                SeatController.getInstance().setPrice(int.Parse(textBox1.Text));
            }
            this.Hide();
            SeatController.getInstance().getSeatControllerUI().setPrice();
            SeatController.getInstance().getSeatControllerUI().Show();
           // SeatController.getInstance().getSeatControllerUI().setPrice();
        }

        private void Price_FormClosed(object sender, FormClosedEventArgs e)
        {
            SeatController.getInstance().getSeatControllerUI().setPrice();
            SeatController.getInstance().getSeatControllerUI().Show();
              //  SeatController.getInstance().getSeatControllerUI().setPrice();

        }
    }
}
