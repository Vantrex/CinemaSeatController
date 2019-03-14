using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSeatController
{
    public class SeatManager 
    {
        private IList<Seat> seatList;

        private int seats;

        private int maxRows;
        private int seatsPerRow;

        public SeatManager(int seats, int maxRows, int seatsPerRow)
        {
            this.seatList = new List<Seat>();
            this.seats = seats;
            this.maxRows = maxRows;
            this.seatsPerRow = seatsPerRow;
            // we´re adding some seats here, the front seats will start @ 1 
        

            Console.WriteLine("Creating standard seats with given informations.");
            Console.WriteLine("First row seats will be premium seats");
            System.Threading.Thread.Sleep(1000);


            int currentRow = 1;
            int currentSeatsInRow = 0;

            for(int i = 1; i <= seats; i++)
            {

                bool premium = false;

                if(currentSeatsInRow == seatsPerRow)
                {
                    currentRow++;
                    currentSeatsInRow = 0;
                }

                if(currentRow == 1)
                {
                    premium = true;
                }

                Seat seat = new Seat(premium, currentRow);
               Console.WriteLine("New Seat created! Premium: " + premium + ", Row: " + seat.getRow() + ", Number: " + i);   
                currentSeatsInRow++;
            }

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("All seats created!");

        }

        public void addSeat(Seat seat)
        {
            seatList.Add(seat);
        }

        public void removeSeat(Seat seat)
        {
            seatList.Remove(seat);
        }

        public Seat getSeat(int seatNumber)
        {
            seatNumber = seatNumber - 1;
            return seatList.ElementAt(seatNumber);
        }

        public IList<Seat> getPremiumSeats()
        {
            IList<Seat> list = new List<Seat>();
            for (int i = 0; i < seatList.Count; i++){

                if(seatList.ElementAt(i) != null)
                {
                    if (seatList.ElementAt(i).isPremium())
                    {
                        list.Add(seatList.ElementAt(i));
                    }
                }

            }
            return list;
        }


        public int getSeatsPerRow()
        {
            return seatsPerRow;
        }

        public void setSeatsPerRow(int seatsPerRow)
        {
            this.seatsPerRow = seatsPerRow;
        }

        public int getSeats()
        {
            return this.seatList.Count();
        }

        public int getMaxRows()
        {
            return maxRows;
        }

        public void setMaxRows(int maxRows)
        {
            this.maxRows = maxRows;
        }

        public IList<Seat> getNormalSeats()
        {
            IList<Seat> list = new List<Seat>();
            for (int i = 0; i < seatList.Count; i++)
            {

                if (seatList.ElementAt(i) != null)
                {
                    if (!seatList.ElementAt(i).isPremium())
                    {
                        list.Add(seatList.ElementAt(i));
                    }
                }

            }
            return list;
        }


        public IList<Seat> getAllSeats()
        {
            return seatList;
        }


    }
}
