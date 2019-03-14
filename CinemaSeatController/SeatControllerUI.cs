using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaSeatController
{



    public partial class SeatControllerUI : Form
    {

        private SeatController seatController;

        public SeatControllerUI()
        {

            this.seatController = SeatController.getInstance(); // instance of the main class

            // init form


            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            resizeForm();
            addSeats();
            addPriceButton();
            setPrice();
            setEarned();
        }

        
        public void setPrice()
        {
            priceLabel.Text = "Seat price: " + seatController.getPrice() + "$";

            premiumPriceLabel.Text = "Premium seat price: " + seatController.getPremiumPrice() + "$";
            this.Update();
        }

        public void setEarned()
        {
            int earned = 0;


            for (int i = 0; i < seatController.getSeatManager().getAllSeats().Count; i++)
            {
                Seat seat = seatController.getSeatManager().getAllSeats().ElementAt(i);
                if (!seat.isValid())
                {
                    earned += seat.isPremium() ? seatController.getPremiumPrice() : seatController.getPrice();
                }      
            }

            earnedMoney.Text = "Earned money: "+earned+"$";
            this.Update();
        }

        public void resizeForm()
        {
            int[] size = new int[2];
            size = getSize();
            this.Width = size[0];
            this.Height = size[1];
            this.Update();
        }

       

        protected void seatButtonClickEvent(object sender, EventArgs e)
        {
            Button button = sender as Button;

            Console.WriteLine("Button clicked -> " + button.Text);

            Seat seat = seatController.getSeatManager().getSeat(int.Parse(button.Text));

            seat.setValid(!seat.isValid());     
            button.BackColor = seat.isValid() ? (seat.isPremium() ? Color.Purple : Color.Green) : Color.Red;
            setEarned();
            this.Update();

        }

       

        protected void seatHoverEvent(object sender, EventArgs e)
        {
            Button button = sender as Button;
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(button, "Click to edit seat");
        }

        private void premiumPriceButtonClickEvent(object sender, EventArgs e)
        {
   
            Price priceEdit = new Price(true);
            this.Hide();
            priceEdit.Show();

        }

        private void priceButtonClickEvent(object sender, EventArgs e)
        {
            Price priceEdit = new Price(false);
            this.Hide();
            priceEdit.Show();

        }

        public void addPriceButton()
        {
            int height = this.Height;
            int widt = this.Width;


            int buttonHeight = 40;
            int buttonWidt = 90;


            Button premiumPriceButton = new Button();


            height -= 85;
            widt -= 115;

            premiumPriceButton.Location = new Point(widt, height);
            premiumPriceButton.Height = buttonHeight;
            premiumPriceButton.Width = buttonWidt;

            premiumPriceButton.Click += new EventHandler(premiumPriceButtonClickEvent);

            premiumPriceButton.Text = "Change Premium Price";

            premiumPriceButton.Show();

            Button priceButton = new Button();

            widt -= 100;
            priceButton.Location = new Point(widt, height);

            priceButton.Text = "Change Price";
            priceButton.Click += new EventHandler(priceButtonClickEvent);
            priceButton.Height = buttonHeight;
            priceButton.Width = buttonWidt;
            this.Controls.Add(priceButton);
            this.Controls.Add(premiumPriceButton);
            priceButton.Show();
            this.Update();

        }

        public void addSeats()
        {


            int x = 20;
            int y = 50;


            int buttonsInRow = 0;

            for(int i = 0; i < seatController.getSeatManager().getAllSeats().Count; i++)
            {
                Seat seat = seatController.getSeatManager().getAllSeats().ElementAt(i);


                int number = i+1;


                Button button = new Button();
                button.Width = 30;
                button.Height = 30;
                this.Controls.Add(button);
                button.Text = number + "";
                button.Location = new Point(x,y);
                
                button.Click += new EventHandler(seatButtonClickEvent);
                button.MouseHover += new EventHandler(seatHoverEvent);
                button.BackColor = seat.isValid() ? (seat.isPremium() ? Color.Purple : Color.Green) : Color.Red ;
                button.Show();

                buttonsInRow++;


                if (seatController.getSeatManager().getSeatsPerRow() / 2 == buttonsInRow)
                {
                
                    x += 90;

                }
                else if (seatController.getSeatManager().getSeatsPerRow() == buttonsInRow)
                {

                    x = 20;
                    y += 40;
                    buttonsInRow = 0;

                }
                else
                {
                    x += 35;
                }


            }
            Console.WriteLine("Added seats!");
            this.Update();
        }

        private int[] getSize()
        {
            int[] size = new int[2];


            int seatWidt = 30; //   seat widt
            int seatGap = 5;   // seat gap
            int seatHeight = 30; // seat height



            // Form size
            // we´re starting with the widt

            int corridorWidt = 50; // size of the corridor widt between the seats

            int usedRows = seatController.getSeatManager().getSeats() / seatController.getSeatManager().getSeatsPerRow();


            int widt = 40 /* size @ edges */ + (seatWidt * seatController.getSeatManager().getSeatsPerRow()) + (seatGap * seatController.getSeatManager().getSeatsPerRow()) + corridorWidt + 20;
            int height = 100 /* size @ edges */ + (seatHeight * usedRows) + (seatGap * usedRows) + 90;

            Console.WriteLine("widt: " + widt);
            Console.WriteLine("height: " + height);

            size[0] = widt;
            size[1] = height;

            return size;
        }

    }
}
