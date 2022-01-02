using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Coursework
{
    public partial class Home : Form
    {

        //XmlSerializer xmlSerializer;
        //List<TicketPriceDataList> ticketPricesDataList;

        XmlSerializer xmlSerializer2;
        List<VisitorDetails> visitorsDetails;

        public Home()
        {
            InitializeComponent();

            visitorsDetails = new List<VisitorDetails>();
            xmlSerializer2 = new XmlSerializer(typeof(List<VisitorDetails>));
            txtEntryTime.Text = DateTime.Now.ToString("t");
            setup();
            txtVisitorID.Text = generateId();
        }

        private String generateId()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return '#' + finalString.ToUpper();
        }

        private void setup()
        {
            FileStream fileStream = new FileStream(location.dataFile, FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                var value = xmlSerializer2.Deserialize(fileStream);

                visitorsDetails = (List<VisitorDetails>)value;

                Console.WriteLine(visitorsDetails);
                fileStream.Close();
            }
            catch (Exception e)
            {
                fileStream.Close();
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AdultButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileStream fileStream2 = new FileStream(location.dataFile, FileMode.OpenOrCreate, FileAccess.Write);

            VisitorDetails info = new VisitorDetails();

            info.ID = txtVisitorID.Text;
            info.Name = txtFullName.Text;
            info.Contact = txtPhone.Text;
            info.Date = DateTime.Parse(DatePicker.Text, System.Globalization.CultureInfo.CurrentCulture);

            DayOfWeek day = info.Date.DayOfWeek;
            switch (day)
            {   
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    info.DayType = "Weekday";
                    break;
                case DayOfWeek.Saturday:
                default:
                    info.DayType = "Weekend";
                    break;
            }
            Console.WriteLine("Start Of Week: " + info.DayType);

            info.CheckInTime = DateTime.Parse(txtEntryTime.Text);


            if (radioChild.Checked)
            {
                info.Age = 12;
            }
            else {
                info.Age = 13;
            }

            info.CheckOutTime = DateTime.Parse(txtOutTime.Text);
            info.GroupNum = comboGroupBy.Text;
            info.TotalPrice = Int32.Parse(txtPrice.Text);

            visitorsDetails.Add(info);
            xmlSerializer2.Serialize(fileStream2, visitorsDetails);
            
            fileStream2.Close();

        }

        private void txtEntryTime_Click(object sender, EventArgs e)
        {
            txtEntryTime.Text = DateTime.Now.ToString("t");
        }

        private void txtOutTime_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
