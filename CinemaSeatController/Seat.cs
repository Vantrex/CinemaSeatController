using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSeatController
{
    public class Seat
    {

        private bool premium;
        private bool valid;
        private int row;

        public Seat(bool premium, int row)
        {
            this.premium = premium;
            this.valid = false;
            this.row = row;
        }

        public int getRow()
        {
            return row;
        }

      
        public bool isPremium()
        {
            return premium;
        }

        public bool isValid()
        {
            return valid;
        }

        
        public void setPremium(bool premium)
        {
            this.premium = premium;
        }

        public void setValid(bool valid)
        {
            this.valid = valid;
        }


    }
}
