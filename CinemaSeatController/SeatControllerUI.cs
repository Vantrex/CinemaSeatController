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

            int[] size = new int[2];

            size = getSize();

            
           
            InitializeComponent();
            this.Width = size[0];
            this.Height = size[1];
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



            int widt = 40 /* size @ edges */ + (seatWidt * seatController.getSeatManager().getSeatsPerRow()) + (seatGap * seatController.getSeatManager().getSeatsPerRow()) + corridorWidt;
            int height = 100 /* size @ edges */ + (seatHeight * seatController.getSeatManager().getMaxRows()) + (seatGap * seatController.getSeatManager().getSeatsPerRow());

            Console.WriteLine("widt: " + widt);
            Console.WriteLine("height: " + height);

            size[0] = widt;
            size[1] = height;

            return size;
        }

    }
}
