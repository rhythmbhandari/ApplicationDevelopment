using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    public class VisitorDetails
    {
        public String ID { get; set; }
        public String Name { get; set; }

        public String Contact { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set;  }
        public String DayType { get; set; }

        public DateTime EntryTime { get; set; }

        public int AgeGroup { get; set; }

        public String GroupNumber { get; set; }

        public DateTime ExitTime { get; set; }

        public int Price { get; set; }

    }
}
