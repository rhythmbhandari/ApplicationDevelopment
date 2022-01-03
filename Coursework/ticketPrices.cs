using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class ticketPrices
    {
        private string v1;
        private int v2;
        private string v3;
        private string v4;

        public ticketPrices(string v1, int v2, string v3, string v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        public String DayType { get; set; }
        public String Age { get; set; }

        public String GroupNum { get; set; }
        public String OneHour { get; set; }
        public String TwoHour { get; set; }
        public String ThreeHour { get; set; }
    }
}
