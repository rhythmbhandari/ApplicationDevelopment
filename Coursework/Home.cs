using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

            visitorDetailsFilePreparer();
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

        private void visitorDetailsFilePreparer()
        {
            FileStream fileStream = new FileStream(fileLocation.visitorDetailsFile, FileMode.OpenOrCreate, FileAccess.Write);
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
            FileStream fileStreamEntry = new FileStream(fileLocation.visitorDetailsFile, FileMode.OpenOrCreate, FileAccess.Write);

            VisitorDetails visitorDetail = new VisitorDetails();

            Regex regexPhone = new Regex("^[0-9]+$");
            Regex regexName = new Regex(@"^[a-zA-Z]{2}$");

            visitorDetail.ID = txtBoxVisitorId.Text;

            if (txtBoxFullName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxFullName.Text = "";
                fileStreamEntry.Close();
                return;
            }
            //else if (!regexName.IsMatch(txtBoxFullName.Text)) {
            //    MessageBox.Show("Only alphabets are allowed in full name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtBoxFullName.Text = "";
            //    fileStreamEntry.Close();
            //    return;
            //}
            else
            {
                visitorDetail.Name = txtBoxFullName.Text;
            }
            if (txtBoxPhone.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your phone number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fileStreamEntry.Close();
                return;
            }
            else if (!regexPhone.IsMatch(txtBoxPhone.Text.Trim()))
            {
                MessageBox.Show("Only numbers are allowed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxPhone.Text = "";
                fileStreamEntry.Close();
                return;
            }
            else if (txtBoxPhone.Text.Trim().Length != 10) {
                MessageBox.Show("Phone number must be of 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fileStreamEntry.Close();
                return;
            }
            {
                visitorDetail.Contact = txtBoxPhone.Text;
            }

            visitorDetail.Date = DateTime.Parse(datePickerDate.Text, System.Globalization.CultureInfo.CurrentCulture);
            DayOfWeek day = visitorDetail.Date.DayOfWeek;
            switch (day)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    visitorDetail.DayType = "Weekday";
                    break;
                case DayOfWeek.Saturday:
                default:
                    visitorDetail.DayType = "Weekend";
                    break;
            }
            Console.WriteLine("Start Of Week: " + visitorDetail.DayType);

            visitorDetail.EntryTime = DateTime.Parse(txtBoxEntryTime.Text);


            if (radioBtnChild.Checked)
            {
                visitorDetail.AgeGroup = 12;
            }
            else
            {
                visitorDetail.AgeGroup = 13;
            }

            visitorDetail.ExitTime = DateTime.Parse(txtBoxOutTime.Text);
            visitorDetail.GroupNumber = comboBoxGroupBy.Text;
            visitorDetail.Price = Int32.Parse(txtBoxPrice.Text);

            visitorsDetails.Add(visitorDetail);
            xmlSerializer.Serialize(fileStreamEntry, visitorsDetails);

            dataGridEntryForm.DataSource = null;


            dataGridEntryForm.DataSource = visitorsDetails;
            fileStreamEntry.Close();

            txtBoxVisitorId.Text = generateId();
            txtBoxFullName.Text = "";
            txtBoxPhone.Text = "";
        }

        private void txtEntryTime_Click(object sender, EventArgs e)
        {
            txtBoxEntryTime.Text = DateTime.Now.ToString("t");
        }


        public int visitorCalculator(String date)
        {

            int singleVisitor = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNumber == "Single").Count() * 1;
            int groupOf5Visitors = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNumber == "Group of 5").Count() * 5;
            int groupOf10Visitors = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNumber == "Group of 10").Count() * 10;
            int groupOf15Visitors = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNumber == "Group of 15").Count() * 15;

            int totalVisitors = singleVisitor + groupOf5Visitors + groupOf10Visitors + groupOf15Visitors;
            return totalVisitors;

        }

        public int grandTotal(String price)
        {

            int grandTotal = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == price).Select(visitorDetail => visitorDetail.Price).Sum();

            return grandTotal;
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
            FileStream fileStream = new FileStream(fileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

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
            FileStream fileStream = new FileStream(fileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

            try
            {
                DataTable dataTable;

                dataTable = chartRowAdder(fileStream);


                chartEarning.Series["Series1"].LegendText = "Earnings";
                chartEarning.Series["Series1"].ChartType = SeriesChartType.Column;
                chartEarning.Series["Series1"].IsValueShownAsLabel = true;
                chartEarning.Series["Series1"].XValueMember = "Day";
                chartEarning.Series["Series1"].YValueMembers = "Total Earning";
                chartEarning.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chartEarning.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                chartEarning.DataSource = dataTable;

                fileStream.Close();
            }
            catch (Exception e)
            {
                fileStream.Close();
            }
        }

        private DataTable chartRowAdder(FileStream fileStream)
        {

            var chartRow = xmlSerializer.Deserialize(fileStream);

            visitorsDetails = (List<VisitorDetails>)chartRow;

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Day");
            dataTable.Columns.Add("Total Visitor");
            dataTable.Columns.Add("Total Earning");

            int remainingDays = ((int)DateTime.Parse(currentDate).DayOfWeek);
            String InitialDayofWeek = (DateTime.Parse(currentDate).AddDays(-remainingDays)).ToString("yyyy-MM-dd");
            String finalDayofWeek = (DateTime.Parse(currentDate).AddDays((7 - remainingDays))).ToString("yyyy-MM-dd");

            dataTable.Rows.Add("Sunday", visitorCalculator(InitialDayofWeek), grandTotal(InitialDayofWeek));
            dataTable.Rows.Add("Monday", visitorCalculator(DateTime.Parse(InitialDayofWeek).AddDays(1).ToString("yyyy-MM-dd")), grandTotal(DateTime.Parse(InitialDayofWeek).AddDays(1).ToString("yyyy-MM-dd")));
            dataTable.Rows.Add("Tuesday", visitorCalculator(DateTime.Parse(InitialDayofWeek).AddDays(2).ToString("yyyy-MM-dd")), grandTotal(DateTime.Parse(InitialDayofWeek).AddDays(2).ToString("yyyy-MM-dd")));
            dataTable.Rows.Add("Wednesday", visitorCalculator(DateTime.Parse(InitialDayofWeek).AddDays(3).ToString("yyyy-MM-dd")), grandTotal(DateTime.Parse(InitialDayofWeek).AddDays(3).ToString("yyyy-MM-dd")));
            dataTable.Rows.Add("Thursday", visitorCalculator(DateTime.Parse(InitialDayofWeek).AddDays(4).ToString("yyyy-MM-dd")), grandTotal(DateTime.Parse(InitialDayofWeek).AddDays(4).ToString("yyyy-MM-dd")));
            dataTable.Rows.Add("Friday", visitorCalculator(DateTime.Parse(InitialDayofWeek).AddDays(5).ToString("yyyy-MM-dd")), grandTotal(DateTime.Parse(InitialDayofWeek).AddDays(5).ToString("yyyy-MM-dd")));
            dataTable.Rows.Add("Saturday", visitorCalculator(finalDayofWeek), grandTotal(finalDayofWeek));

            return dataTable;
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
            FileStream fileStream2 = new FileStream(fileLocation.visitorDetailsFile, FileMode.OpenOrCreate, FileAccess.Write);
            dataGridEntryForm.DataSource = null;
            dataGridEntryForm.DataSource = visitorsDetails;
            fileStream2.Close();
        }

        private void btnGenerateDailyReport_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(fileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

            try
            {
                var vistor = xmlSerializerDailyReport.Deserialize(fileStream);

                visitorsDetailsDailyReport = (List<VisitorDetails>)vistor;

                DataTable data = new DataTable();

                int Single = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == currentDate && visitorDetail.GroupNumber == "Single").Count();
                int GroupOf5 = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == currentDate && visitorDetail.GroupNumber == "Group of 5").Count();
                int GroupOf10 = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == currentDate && visitorDetail.GroupNumber == "Group of 10").Count();
                int GroupOf15 = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == currentDate && visitorDetail.GroupNumber == "Group of 15").Count();

                data.Columns.Add("Name");
                data.Columns.Add("Count");

                data.Rows.Add("Single", Single);
                data.Rows.Add("Group of 5", GroupOf5);
                data.Rows.Add("Group of 10", GroupOf10);
                data.Rows.Add("Group of 15", GroupOf15);

                dataGridDailyReport.DataSource = data;


                fileStream.Close();
            }
            catch (Exception e2)
            {
                fileStream.Close();
            }
        }

        private void btnGenerateWeeklyReport_Click_1(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(fileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

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

            FileStream fileStream = new FileStream(fileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

            try
            {

                DataTable dataTable;

                dataTable = chartRowAdder(fileStream);

                dataTable = BubbleSortingAlgorithm(dataTable, "Total Visitor");

                dataGridWeeklyReport.DataSource = dataTable;

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

            FileStream fileStream = new FileStream(fileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

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

        private DataTable BubbleSortingAlgorithm(DataTable dataTable, String sortBy)
        {
            for (int i = dataTable.Rows.Count - 1; i > 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (Convert.ToInt32(dataTable.Rows[j][sortBy]) > Convert.ToInt32(dataTable.Rows[j + 1][sortBy]))
                    {
                        var totalEarning = dataTable.Rows[j]["Total Earning"];
                        var totalVisitor = dataTable.Rows[j]["Total Visitor"];
                        var days = dataTable.Rows[j]["Day"];

                        dataTable.Rows[j]["Total Earning"] = dataTable.Rows[j + 1]["Total Earning"];
                        dataTable.Rows[j]["Day"] = dataTable.Rows[j + 1]["Day"];
                        dataTable.Rows[j]["Total Visitor"] = dataTable.Rows[j + 1]["Total Visitor"];

                        dataTable.Rows[j + 1]["Total Earning"] = totalEarning;
                        dataTable.Rows[j + 1]["Day"] = days;
                        dataTable.Rows[j + 1]["Total Visitor"] = totalVisitor;

                    }
                }
            }
           return dataTable;
        }



        private void btnTicketImport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data;
                data = NewDataTable(fileLocation.ticketRatesFile);

                dataGridTicketRates.DataSource = data;
            }
            catch {
                MessageBox.Show("Ticket rates import failed. PLease try again.");
            }

        }


        public static DataTable NewDataTable(string fileName)
        {
            DataTable returnTable = new DataTable();


            using (TextFieldParser textfieldparser = new TextFieldParser(fileName))
            {
                textfieldparser.SetDelimiters(",");

                if (!textfieldparser.EndOfData)
                {
                    string[] fields = textfieldparser.ReadFields();

                    for (int i = 0; i < fields.Count(); i++)
                    {
                        returnTable.Columns.Add(fields[i]);
                    }

                }

                while (!textfieldparser.EndOfData)
                    returnTable.Rows.Add(textfieldparser.ReadFields());
            }

            return returnTable;
        }

        private void btnTicketExport_Click(object sender, EventArgs e)
        {
            try
            {
                string csvFile = string.Empty;

                foreach (DataGridViewColumn column in dataGridTicketRates.Columns)
                {
                    csvFile += column.HeaderText + ',';
                }
                csvFile += "\r\n";

             foreach (DataGridViewRow dataRow in dataGridTicketRates.Rows)
                {
                    foreach (DataGridViewCell dataCell in dataRow.Cells)
                    {
                        if (dataCell.Value != null)
                        {
                            csvFile += dataCell.Value.ToString().TrimEnd(',').Replace(",", ";") + ',';
                        }
                    }
                    csvFile += "\r\n";
                }
                File.WriteAllText(fileLocation.ticketRatesFile, csvFile);
                MessageBox.Show("Successfully exported.");
            }
            catch
            {
                MessageBox.Show("Ticket rates export failed. PLease try again.");
            }
        }

        private void btnSearchEntry_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(fileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);
            String search = txtBoxSearchVisitorID.Text;
            String displayText = "";
            try
            {
                visitorsDetails = (List<VisitorDetails>)xmlSerializer.Deserialize(fileStream);
                foreach (VisitorDetails visitorDetail in visitorsDetails)
                {
                    if (visitorDetail.ID == search)
                    {
                        displayText = "Full Name: " + visitorDetail.Name + " " + "Contact Number: " + visitorDetail.Contact + "\n" 
                            +"Entry Time: " + visitorDetail.EntryTime + " " + "Exit Time: " + visitorDetail.ExitTime;
                    }
                }
                if (String.IsNullOrEmpty(displayText))
                {
                    MessageBox.Show("The entered visitor ID: " + search + " is invalid.");
                }
                else
                {
                    MessageBox.Show(displayText);
                }
            }
            catch
            {

            }
        }
    }

}