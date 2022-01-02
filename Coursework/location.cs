using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    class location
    {
       
            public static String ticketPriceList = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + "/ticketPriceList.xml";
            public static String dataFile = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + "/dataFile.xml";
        
    }
}
