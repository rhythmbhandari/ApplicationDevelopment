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
using System.Windows.Forms.DataVisualization.Charting;

namespace Coursework
{
    public partial class Home : Form
    {

        XmlSerializer xmlSerializer;
        //List<TicketPriceDataList> ticketPricesDataList;

        XmlSerializer xmlSerializer2;
        List<VisitorDetails> visitorsDetails;
        List<VisitorDetails> visitorsDetails2;

        String currentDate = DateTime.Now.ToString("yyyy-MM-dd");

        public Home()
        {
            InitializeComponent();

            xmlSerializer = new XmlSerializer(typeof(List<VisitorDetails>));

            visitorsDetails = new List<VisitorDetails>();
            xmlSerializer2 = new XmlSerializer(typeof(List<VisitorDetails>));
            txtEntryTime.Text = DateTime.Now.ToString("t");
            setup();
            txtVisitorID.Text = generateId();

            //tabHomePage.SelectedIndexChanged += new EventHandler(tabHomePage_SelectedIndexChanged);

        }

        void Tabs_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPage1)
            {

            }
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

        private void DailyReportButton_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(location.dataFile, FileMode.Open, FileAccess.Read);

            try
            {
                var vistor = xmlSerializer.Deserialize(fileStream);

                visitorsDetails = (List<VisitorDetails>)vistor;

                DataTable data = new DataTable();

                //int Child = visitorsDetails.Where(a => a.Date.ToString("yyyy-MM-dd") == currentDate && (a.Age >= 5 && a.Age <= 12)).Count();
                int Single = visitorsDetails.Where(a => a.Date.ToString("yyyy-MM-dd") == currentDate && a.GroupNum == "Single").Count();
                int GroupOf5 = visitorsDetails.Where(a => a.Date.ToString("yyyy-MM-dd") == currentDate && a.GroupNum == "Group of 5").Count();
                int GroupOf10 = visitorsDetails.Where(a => a.Date.ToString("yyyy-MM-dd") == currentDate && a.GroupNum == "Group of 10").Count();
                int GroupOf15 = visitorsDetails.Where(a => a.Date.ToString("yyyy-MM-dd") == currentDate && a.GroupNum == "Group of 15").Count();
                //int GroupOf20 = visitorsDetails.Where(a => a.Date.ToString("yyyy-MM-dd") == currentDate && a.GroupNum == "Group of 15").Count();

                data.Columns.Add("Name");
                data.Columns.Add("Count");

                //data.Rows.Add("Child", Child);
                data.Rows.Add("Single", Single);
                data.Rows.Add("Group of 5", GroupOf5);
                data.Rows.Add("Group of 10", GroupOf10);
                data.Rows.Add("Group of 15", GroupOf15);
               // data.Rows.Add("Group of 20", GroupOf20);

                DailyReportDataGridView.DataSource = data;

                //VisitorCountTextBox.Text = (Child + Adult + (GroupOf5 * 5) + (GroupOf10 * 10) + (GroupOf15 * 15) + (GroupOf20 * 20)).ToString();

                fileStream.Close();
            }
            catch (Exception e2)
            {
                fileStream.Close();
            }
        }

        private void WeeklyReportButton_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(location.dataFile, FileMode.Open, FileAccess.Read);

            try
            {
                var visitor2 = xmlSerializer2.Deserialize(fileStream);

                visitorsDetails2 = (List<VisitorDetails>)visitor2;

                DataTable data = new DataTable();

                data.Columns.Add("Day");
                data.Columns.Add("Total Visitor");
                data.Columns.Add("Total Earning");

                int date = ((int)DateTime.Parse(currentDate).DayOfWeek);
                String Date1 = (DateTime.Parse(currentDate).AddDays(-date)).ToString("yyyy-MM-dd");
                String Date2 = (DateTime.Parse(currentDate).AddDays((7 - date))).ToString("yyyy-MM-dd");

                data.Rows.Add("Sunday", calc(Date1), totalPrice(Date1));
                data.Rows.Add("Monday", calc(DateTime.Parse(Date1).AddDays(1).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(1).ToString("yyyy-MM-dd")));
                data.Rows.Add("Tuesday", calc(DateTime.Parse(Date1).AddDays(2).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(2).ToString("yyyy-MM-dd")));
                data.Rows.Add("Wednesday", calc(DateTime.Parse(Date1).AddDays(3).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(3).ToString("yyyy-MM-dd")));
                data.Rows.Add("Thursday", calc(DateTime.Parse(Date1).AddDays(4).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(4).ToString("yyyy-MM-dd")));
                data.Rows.Add("Friday", calc(DateTime.Parse(Date1).AddDays(5).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(5).ToString("yyyy-MM-dd")));
                data.Rows.Add("Saturday", calc(Date2), totalPrice(Date2));

                WeeklyReportDataGridView.DataSource = data;

                fileStream.Close();
            }
            catch (Exception e1)
            {
                fileStream.Close();

            }
        }

        public int calc(String cal)
        {

        int single = visitorsDetails.Where(a => a.Date.ToString("yyyy-MM-dd") == cal && a.GroupNum == "Single").Count() * 1;
        int groupOf5 = visitorsDetails.Where(a => a.Date.ToString("yyyy-MM-dd") == cal && a.GroupNum == "Group of 5").Count() * 5;
        int groupOf10 = visitorsDetails.Where(a => a.Date.ToString("yyyy-MM-dd") == cal && a.GroupNum == "Group of 10").Count() * 10;
        int groupOf15 = visitorsDetails.Where(a => a.Date.ToString("yyyy-MM-dd") == cal && a.GroupNum == "Group of 15").Count() * 15;

            int sum = single + groupOf5 + groupOf10 + groupOf15;
            return sum;
        }

        public int totalPrice(String cal)
        {

            int totalprice = visitorsDetails.Where(a => a.Date.ToString("yyyy-MM-dd") == cal).Select(a => a.TotalPrice).Sum();

            return totalprice;
        }

        private void WeeklyReportDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage5_Load(object sender, EventArgs e)
        {
            DailyReportButton_Click(sender, e);
            WeeklyReportButton_Click(sender, e);
            weeklyChart(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void btnImportDailyReport_Click(object sender, EventArgs e)
        {
            DailyReportButton_Click(sender, e);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void weeklyChart(String date)
        {
            FileStream fileStream = new FileStream(location.dataFile, FileMode.Open, FileAccess.Read);

            try
            {

                var vistor2 = xmlSerializer.Deserialize(fileStream);

                visitorsDetails = (List<VisitorDetails>)vistor2;

                DataTable data = new DataTable();

                data.Columns.Add("Day");
                data.Columns.Add("Total Visitor");
                data.Columns.Add("Total Earning");

                int D = ((int)DateTime.Parse(currentDate).DayOfWeek);
                String Date1 = (DateTime.Parse(currentDate).AddDays(-D)).ToString("yyyy-MM-dd");
                String Date2 = (DateTime.Parse(currentDate).AddDays((7 - D))).ToString("yyyy-MM-dd");

                data.Rows.Add("Sunday", calc(Date1), totalPrice(Date1));
                data.Rows.Add("Monday", calc(DateTime.Parse(Date1).AddDays(1).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(1).ToString("yyyy-MM-dd")));
                data.Rows.Add("Tuesday", calc(DateTime.Parse(Date1).AddDays(2).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(2).ToString("yyyy-MM-dd")));
                data.Rows.Add("Wednesday", calc(DateTime.Parse(Date1).AddDays(3).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(3).ToString("yyyy-MM-dd")));
                data.Rows.Add("Thursday", calc(DateTime.Parse(Date1).AddDays(4).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(4).ToString("yyyy-MM-dd")));
                data.Rows.Add("Friday", calc(DateTime.Parse(Date1).AddDays(5).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(5).ToString("yyyy-MM-dd")));
                data.Rows.Add("Saturday", calc(Date2), totalPrice(Date2));

                chartVisitor.Series["Series1"].LegendText = "Visitors";
                chartVisitor.Series["Series1"].ChartType = SeriesChartType.Column;
                chartVisitor.Series["Series1"].IsValueShownAsLabel = true;
                chartVisitor.Series["Series1"].XValueMember = "Day";
                chartVisitor.Series["Series1"].YValueMembers = "Total Visitor";
                chartVisitor.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chartVisitor.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                chartVisitor.DataSource = data;

                chartEarning.Series["Series1"].LegendText = "Price";
                chartEarning.Series["Series1"].ChartType = SeriesChartType.Column;
                chartEarning.Series["Series1"].IsValueShownAsLabel = true;
                chartEarning.Series["Series1"].XValueMember = "Day";
                chartEarning.Series["Series1"].YValueMembers = "Total Earning";
                chartEarning.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chartEarning.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                chartEarning.DataSource = data;

                fileStream.Close();
            }
            catch (Exception e)
            {
                fileStream.Close();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            String currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            
            weeklyChart(currentDate);
        }
    }
}
