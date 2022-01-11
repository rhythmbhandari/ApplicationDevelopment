using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    class FileLocation
    {
       
        public static String visitorDetailsFile = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + "/visitor_details.xml";
        public static String ticketRatesFile = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + "/ticket_rates.csv";


    }
}
