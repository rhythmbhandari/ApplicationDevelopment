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

        //XmlSerializer xmlSerializer2;
        List<VisitorDetails> visitorsDetails;

        String currentDate = DateTime.Now.ToString("yyyy-MM-dd");

        public Home()
        {
            InitializeComponent();

            xmlSerializer = new XmlSerializer(typeof(List<VisitorDetails>));

            visitorsDetails = new List<VisitorDetails>();
            //xmlSerializer2 = new XmlSerializer(typeof(List<VisitorDetails>));
            comboBoxDuration.Text = "1";
            comboGroupBy.Text = "Single";
            txtEntryTime.Text = DateTime.Now.ToString("t");
            txtOutTime.Text = DateTime.Now.AddHours(1).ToString("t");
            txtPrice.Text = "200";
            radioAdult.Checked = true;

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
                var value = xmlSerializer.Deserialize(fileStream);

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
            xmlSerializer.Serialize(fileStream2, visitorsDetails);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = visitorsDetails;
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

                int Single = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == currentDate && visitorDetail.GroupNum == "Single").Count();
                int GroupOf5 = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == currentDate && visitorDetail.GroupNum == "Group of 5").Count();
                int GroupOf10 = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == currentDate && visitorDetail.GroupNum == "Group of 10").Count();
                int GroupOf15 = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == currentDate && visitorDetail.GroupNum == "Group of 15").Count();

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
                var visitor2 = xmlSerializer.Deserialize(fileStream);

                visitorsDetails = (List<VisitorDetails>)visitor2;

                DataTable data = new DataTable();

                data.Columns.Add("Day");
                data.Columns.Add("Total Visitor");
                data.Columns.Add("Total Earning");

                int date = ((int)DateTime.Parse(currentDate).DayOfWeek);
                String Date1 = (DateTime.Parse(currentDate).AddDays(-date)).ToString("yyyy-MM-dd");
                String Date2 = (DateTime.Parse(currentDate).AddDays((7 - date))).ToString("yyyy-MM-dd");

                data.Rows.Add("Sunday", visitorCalculator(Date1), totalPrice(Date1));
                data.Rows.Add("Monday", visitorCalculator(DateTime.Parse(Date1).AddDays(1).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(1).ToString("yyyy-MM-dd")));
                data.Rows.Add("Tuesday", visitorCalculator(DateTime.Parse(Date1).AddDays(2).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(2).ToString("yyyy-MM-dd")));
                data.Rows.Add("Wednesday", visitorCalculator(DateTime.Parse(Date1).AddDays(3).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(3).ToString("yyyy-MM-dd")));
                data.Rows.Add("Thursday", visitorCalculator(DateTime.Parse(Date1).AddDays(4).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(4).ToString("yyyy-MM-dd")));
                data.Rows.Add("Friday", visitorCalculator(DateTime.Parse(Date1).AddDays(5).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(5).ToString("yyyy-MM-dd")));
                data.Rows.Add("Saturday", visitorCalculator(Date2), totalPrice(Date2));

                WeeklyReportDataGridView.DataSource = data;

                fileStream.Close();
            }
            catch (Exception e1)
            {
                fileStream.Close();

            }
        }

        public int visitorCalculator(String date)
        {

        int singleVisitor = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNum == "Single").Count() * 1;
        int groupOf5Visitors = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNum == "Group of 5").Count() * 5;
        int groupOf10Visitors = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNum == "Group of 10").Count() * 10;
        int groupOf15Visitors = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNum == "Group of 15").Count() * 15;

        int totalVisitors = singleVisitor + groupOf5Visitors + groupOf10Visitors + groupOf15Visitors;
        return totalVisitors;

        }

        public int totalPrice(String price)
        {

            int totalprice = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == price).Select(visitorDetail => visitorDetail.TotalPrice).Sum();

            return totalprice;
        }

        private void WeeklyReportDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage5_Load(object sender, EventArgs e)
        {
            DailyReportButton_Click(sender, e);
            WeeklyReportButton_Click(sender, e);
            weeklyEarningsChart(DateTime.Now.ToString("yyyy-MM-dd"));
            weeklyVisitorsChart(DateTime.Now.ToString("yyyy-MM-dd"));
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

        private void weeklyVisitorsChart(String date)
        {
            FileStream fileStream = new FileStream(location.dataFile, FileMode.Open, FileAccess.Read);

            try
            {
                DataTable data;

                data = chartRowAdder(fileStream);

                chartVisitor.Series["Series1"].LegendText = "Visitors";
                chartVisitor.Series["Series1"].ChartType = SeriesChartType.Column;
                chartVisitor.Series["Series1"].IsValueShownAsLabel = true;
                chartVisitor.Series["Series1"].XValueMember = "Day";
                chartVisitor.Series["Series1"].YValueMembers = "Total Visitor";
                chartVisitor.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chartVisitor.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                chartVisitor.DataSource = data;


                fileStream.Close();
            }
            catch (Exception e)
            {
                fileStream.Close();
            }
        }

        private void weeklyEarningsChart(String date)
        {
            FileStream fileStream = new FileStream(location.dataFile, FileMode.Open, FileAccess.Read);

            try
            {
                DataTable data;

                data = chartRowAdder(fileStream);


                chartEarning.Series["Series1"].LegendText = "Earnings";
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

        private DataTable chartRowAdder(FileStream fileStream) {

            var vistor2 = xmlSerializer.Deserialize(fileStream);

            visitorsDetails = (List<VisitorDetails>)vistor2;

            DataTable data = new DataTable();

            data.Columns.Add("Day");
            data.Columns.Add("Total Visitor");
            data.Columns.Add("Total Earning");

            int D = ((int)DateTime.Parse(currentDate).DayOfWeek);
            String Date1 = (DateTime.Parse(currentDate).AddDays(-D)).ToString("yyyy-MM-dd");
            String Date2 = (DateTime.Parse(currentDate).AddDays((7 - D))).ToString("yyyy-MM-dd");

            data.Rows.Add("Sunday", visitorCalculator(Date1), totalPrice(Date1));
            data.Rows.Add("Monday", visitorCalculator(DateTime.Parse(Date1).AddDays(1).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(1).ToString("yyyy-MM-dd")));
            data.Rows.Add("Tuesday", visitorCalculator(DateTime.Parse(Date1).AddDays(2).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(2).ToString("yyyy-MM-dd")));
            data.Rows.Add("Wednesday", visitorCalculator(DateTime.Parse(Date1).AddDays(3).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(3).ToString("yyyy-MM-dd")));
            data.Rows.Add("Thursday", visitorCalculator(DateTime.Parse(Date1).AddDays(4).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(4).ToString("yyyy-MM-dd")));
            data.Rows.Add("Friday", visitorCalculator(DateTime.Parse(Date1).AddDays(5).ToString("yyyy-MM-dd")), totalPrice(DateTime.Parse(Date1).AddDays(5).ToString("yyyy-MM-dd")));
            data.Rows.Add("Saturday", visitorCalculator(Date2), totalPrice(Date2));

            return data;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            String currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            
            weeklyEarningsChart(currentDate);
            weeklyVisitorsChart(currentDate);
        }

        private void comboBoxDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOutTime.Text = DateTime.Now.ToLongTimeString();

            DateTime currentTimeDate = DateTime.Now;

            if (comboBoxDuration.Text == "1")
            {
                txtEntryTime.Text = DateTime.Now.ToString("t");
                txtOutTime.Text = currentTimeDate.AddHours(1).ToString("t");
            }

            if (comboBoxDuration.Text == "2")
            {
                txtEntryTime.Text = DateTime.Now.ToString("t");
                txtOutTime.Text = currentTimeDate.AddHours(2).ToString("t");
            }

            if (comboBoxDuration.Text == "3")
            {
                txtEntryTime.Text = DateTime.Now.ToString("t");
                txtOutTime.Text = currentTimeDate.AddHours(3).ToString("t");
            }

            if (comboBoxDuration.Text == "4")
            {
                txtEntryTime.Text = DateTime.Now.ToString("t");
                txtOutTime.Text = currentTimeDate.AddHours(4).ToString("t");
            }

            if (comboBoxDuration.Text == "Unlimited")
            {
                txtEntryTime.Text = DateTime.Now.ToString("t");
                DateTime timeNow = DateTime.Now;
                DateTime sixPmTime = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, 18, 0, 0, 0);
                txtOutTime.Text = sixPmTime.ToString("t");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            FileStream fileStream2 = new FileStream(location.dataFile, FileMode.OpenOrCreate, FileAccess.Write);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = visitorsDetails;
            fileStream2.Close();
        }
    }
}
