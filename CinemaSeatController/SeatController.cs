using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaSeatController
{
    public class SeatController
    {

        private static SeatController instance;

        private SeatManager seatManager;

        private SeatControllerUI seatControllerUI;

        private int price;
        private int premiumPrice;

        public SeatController(string[] args)
        {

            instance = this;

            int seats;
            int maxRows;
            int seatsPerRow;

            Console.WriteLine("Program starting..");
            Console.WriteLine("Enter amount of seats the program has to use, however you can change this number later:");


            seats = Convert.ToInt32(Console.ReadLine());

            while(seats <= 0)
            {
                Console.WriteLine("Enter amount of seats the program has to use, however you can change this number later:");
                seats = Convert.ToInt32(Console.ReadLine());

            }

            Console.WriteLine("Enter amount of rows the cinema room should have, however you can change this number later:");
            maxRows = Convert.ToInt32(Console.ReadLine());
            while(maxRows <= 0)
            {
                Console.WriteLine("Enter amount of rows the cinema room should have, however you can change this number later:");
                maxRows = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Enter amount of seats per row, however you can change this number later");
            seatsPerRow = Convert.ToInt32(Console.ReadLine());
            while(seatsPerRow <= 0 || (seatsPerRow * maxRows < seats))
            {

                if(seatsPerRow * maxRows < seats)
                {
                    Console.WriteLine("You need more seats per row or more rows, please enter the amount of seats per row.");
                    Console.WriteLine("You need atleast " + (seats / maxRows ) + " seats!");
                    seatsPerRow = Convert.ToInt32(Console.ReadLine());
                }
                else
                {

              
                Console.WriteLine("Enter amount of seats per row, however you can change this number later");
                seatsPerRow = Convert.ToInt32(Console.ReadLine());
                }
            }

            
            for(int i = 0; i < 1000; i++)
            {
                Console.WriteLine(" ");
            }



            Console.WriteLine("Amount of seats: " + seats);
            Console.WriteLine("Amount of current max rows: " + maxRows);
            Console.WriteLine("Amount of current seats per row: " + seatsPerRow);

            System.Threading.Thread.Sleep(5000);
            this.seatManager = new SeatManager(seats, maxRows, seatsPerRow);

            this.seatControllerUI = new SeatControllerUI();
            


            // end of init thread, now running the application

           Application.EnableVisualStyles();
           Application.Run(seatControllerUI);
            onClose();
        }

        void onClose()
        {

            Console.WriteLine("Application closing...");

            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("Application closed!");

        }

        public SeatControllerUI getSeatControllerUI()
        {
            return seatControllerUI;
        }

        public SeatManager getSeatManager()
        {
            return seatManager;
        }

        public int getPrice()
        {
            return price;
        }

        public int getPremiumPrice()
        {
            return premiumPrice;
        }

        public void setPrice(int price)
        {
            this.price = price;
        }

        public void setPremiumPrice(int premiumPrice)
        {
            this.premiumPrice = premiumPrice;
        }

        public static SeatController getInstance()
        {
            return instance;
        }

    }
}
