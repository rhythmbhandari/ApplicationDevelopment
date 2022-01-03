using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace Coursework
{
    public partial class Home : Form
    {

        XmlSerializer xmlSerializer;
        //List<TicketPriceDataList> ticketPricesDataList;

        XmlSerializer xmlSerializerDailyReport;
        List<VisitorDetails> visitorsDetails;

        List<VisitorDetails> visitorsDetailsDailyReport;

        String currentDate = DateTime.Now.ToString("yyyy-MM-dd");

        public Home()
        {
            InitializeComponent();

            xmlSerializer = new XmlSerializer(typeof(List<VisitorDetails>));

            visitorsDetails = new List<VisitorDetails>();


            xmlSerializerDailyReport = new XmlSerializer(typeof(List<VisitorDetails>));
            visitorsDetailsDailyReport = new List<VisitorDetails>();
            comboBoxDuration.Text = "1";
            comboBoxGroupBy.Text = "Single";
            txtBoxEntryTime.Text = DateTime.Now.ToString("t");
            txtBoxOutTime.Text = DateTime.Now.AddHours(1).ToString("t");
            txtBoxPrice.Text = "200";
            radioBtnAdult.Checked = true;

            setup();
            txtBoxVisitorId.Text = generateId();

            //tabHomePage.SelectedIndexChanged += new EventHandler(tabHomePage_SelectedIndexChanged);

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



        private void btnSave_Click(object sender, EventArgs e)
        {
            FileStream fileStream2 = new FileStream(location.dataFile, FileMode.OpenOrCreate, FileAccess.Write);

            VisitorDetails info = new VisitorDetails();

            info.ID = txtBoxVisitorId.Text;
            info.Name = txtBoxFullName.Text;
            info.Contact = txtBoxPhone.Text;
            info.Date = DateTime.Parse(datePickerDate.Text, System.Globalization.CultureInfo.CurrentCulture);

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

            info.CheckInTime = DateTime.Parse(txtBoxEntryTime.Text);


            if (radioBtnChild.Checked)
            {
                info.Age = 12;
            }
            else
            {
                info.Age = 13;
            }

            info.CheckOutTime = DateTime.Parse(txtBoxOutTime.Text);
            info.GroupNum = comboBoxGroupBy.Text;
            info.TotalPrice = Int32.Parse(txtBoxPrice.Text);

            visitorsDetails.Add(info);
            xmlSerializer.Serialize(fileStream2, visitorsDetails);

            dataGridEntryForm.DataSource = null;


            dataGridEntryForm.DataSource = visitorsDetails;
            fileStream2.Close();

        }

        private void txtEntryTime_Click(object sender, EventArgs e)
        {
            txtBoxEntryTime.Text = DateTime.Now.ToString("t");
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
            btnGenerateDailyReport_Click(sender, e);
            btnGenerateWeeklyReport_Click_1(sender, e);
            weeklyEarningsChart(DateTime.Now.ToString("yyyy-MM-dd"));
            weeklyVisitorsChart(DateTime.Now.ToString("yyyy-MM-dd"));
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

        private DataTable chartRowAdder(FileStream fileStream)
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
            txtBoxOutTime.Text = DateTime.Now.ToLongTimeString();

            DateTime currentTimeDate = DateTime.Now;

            if (comboBoxDuration.Text == "1")
            {
                txtBoxEntryTime.Text = DateTime.Now.ToString("t");
                txtBoxOutTime.Text = currentTimeDate.AddHours(1).ToString("t");
            }

            if (comboBoxDuration.Text == "2")
            {
                txtBoxEntryTime.Text = DateTime.Now.ToString("t");
                txtBoxOutTime.Text = currentTimeDate.AddHours(2).ToString("t");
            }

            if (comboBoxDuration.Text == "3")
            {
                txtBoxEntryTime.Text = DateTime.Now.ToString("t");
                txtBoxOutTime.Text = currentTimeDate.AddHours(3).ToString("t");
            }

            if (comboBoxDuration.Text == "4")
            {
                txtBoxEntryTime.Text = DateTime.Now.ToString("t");
                txtBoxOutTime.Text = currentTimeDate.AddHours(4).ToString("t");
            }

            if (comboBoxDuration.Text == "Unlimited")
            {
                txtBoxEntryTime.Text = DateTime.Now.ToString("t");
                DateTime timeNow = DateTime.Now;
                DateTime sixPmTime = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, 18, 0, 0, 0);
                txtBoxOutTime.Text = sixPmTime.ToString("t");
            }
        }


        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            FileStream fileStream2 = new FileStream(location.dataFile, FileMode.OpenOrCreate, FileAccess.Write);
            dataGridEntryForm.DataSource = null;
            dataGridEntryForm.DataSource = visitorsDetails;
            fileStream2.Close();
        }

        private void btnGenerateDailyReport_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(location.dataFile, FileMode.Open, FileAccess.Read);

            try
            {
                var vistor = xmlSerializerDailyReport.Deserialize(fileStream);

                visitorsDetailsDailyReport = (List<VisitorDetails>)vistor;

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

                dataGridDailyReport.DataSource = data;

                //VisitorCountTextBox.Text = (Child + Adult + (GroupOf5 * 5) + (GroupOf10 * 10) + (GroupOf15 * 15) + (GroupOf20 * 20)).ToString();

                fileStream.Close();
            }
            catch (Exception e2)
            {
                fileStream.Close();
            }
        }

        private void btnGenerateWeeklyReport_Click_1(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(location.dataFile, FileMode.Open, FileAccess.Read);

            try

            {
                DataTable data;

                data = chartRowAdder(fileStream);

                dataGridWeeklyReport.DataSource = data;

                fileStream.Close();
            }
            catch (Exception e1)
            {
                fileStream.Close();

            }
        }

        private void btnSortVisitors_Click(object sender, EventArgs e)
        {
            visitorsDetails = new List<VisitorDetails>();

            FileStream fileStream = new FileStream(location.dataFile, FileMode.Open, FileAccess.Read);

            try
            {

                DataTable data;

                data = chartRowAdder(fileStream);

                data = BubbleSortingAlgorithm(data, "Total Visitor");

                dataGridWeeklyReport.DataSource = data;

                fileStream.Close();
            }
            catch (Exception e4)
            {
                fileStream.Close();
            }
        }

        private void btnSortEarnings_Click(object sender, EventArgs e)
        {
            visitorsDetails = new List<VisitorDetails>();

            FileStream fileStream = new FileStream(location.dataFile, FileMode.Open, FileAccess.Read);

            try
            {
                DataTable data;

                data = chartRowAdder(fileStream);

                data = BubbleSortingAlgorithm(data, "Total Earning");

                dataGridWeeklyReport.DataSource = data;

                fileStream.Close();
            }
            catch (Exception e3)
            {
                fileStream.Close();
            }
        }

        private DataTable BubbleSortingAlgorithm(DataTable data, String sortBy)
        {
            for (int i = data.Rows.Count - 1; i > 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (Convert.ToInt32(data.Rows[j][sortBy]) > Convert.ToInt32(data.Rows[j + 1][sortBy]))
                    {
                        var totalEarning = data.Rows[j]["Total Earning"];
                        var totalVisitor = data.Rows[j]["Total Visitor"];
                        var days = data.Rows[j]["Day"];

                        data.Rows[j]["Total Earning"] = data.Rows[j + 1]["Total Earning"];
                        data.Rows[j]["Day"] = data.Rows[j + 1]["Day"];
                        data.Rows[j]["Total Visitor"] = data.Rows[j + 1]["Total Visitor"];

                        data.Rows[j + 1]["Total Earning"] = totalEarning;
                        data.Rows[j + 1]["Day"] = days;
                        data.Rows[j + 1]["Total Visitor"] = totalVisitor;

                    }
                }
            }
            return data;
        }


        List<ticketPrices> ticketPrice;
        static ticketPrices ticketprices;
        private void btnTicketImport_Click(object sender, EventArgs e)
        {

            ticketPrice = new List<ticketPrices>();

            DataTable data;
            //data = NewDataTable(@"D:/hehehehehe.csv");
            data = NewDataTable(location.csvFile);
            //Console.WriteLine(data);

            dataGridTicketRates.DataSource = data;


        }


        public static DataTable NewDataTable(string fileName,  bool firstRowContainsFieldNames = true)
        {
            DataTable result = new DataTable();

            using (TextFieldParser tfp = new TextFieldParser(fileName))
            {
                tfp.SetDelimiters(",");

                // Get Some Column Names
                if (!tfp.EndOfData)
                {
                    string[] fields = tfp.ReadFields();

                    for (int i = 0; i < fields.Count(); i++)
                    {
                        if (firstRowContainsFieldNames)
                            result.Columns.Add(fields[i]);
                        else
                            result.Columns.Add("Col" + i);


                    }

                    // If first line is data then add it
                    if (!firstRowContainsFieldNames)
                        result.Rows.Add(fields);
                }

                // Get Remaining Rows
                while (!tfp.EndOfData)
                    result.Rows.Add(tfp.ReadFields());
            }

            return result;
        }

        private void btnTicketExport_Click(object sender, EventArgs e)
        {
            try
            {
                //Build the CSV file data as a Comma separated string.
                string csv = string.Empty;

                //Add the Header row for CSV file.
                foreach (DataGridViewColumn column in dataGridTicketRates.Columns)
                {
                    csv += column.HeaderText + ',';
                }
                //Add new line.
                csv += "\r\n";

                //Adding the Rows

                foreach (DataGridViewRow row in dataGridTicketRates.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            //Add the Data rows.
                            csv += cell.Value.ToString().TrimEnd(',').Replace(",", ";") + ',';
                        }
                        // break;
                    }
                    //Add new line.
                    csv += "\r\n";
                }

                //Exporting to CSV.
                //string folderPath = location.csvFile;
                //if (!Directory.Exists(folderPath))
               // {
                    //Directory.CreateDirectory(folderPath);
                //}
                File.WriteAllText(location.csvFile, csv);
                MessageBox.Show("Success");
            }
            catch
            {
                MessageBox.Show("HEHEHE");
            }
        }
    }

}