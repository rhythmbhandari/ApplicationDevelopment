﻿using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        //Declaring Serializers for handling objects.
        XmlSerializer xmlSerializer;
        XmlSerializer xmlSerializerDailyReport;

        //Variables declaration.
        //List<TicketPriceDataList> ticketPricesDataList;
        List<VisitorDetails> visitorsDetails;
        TickePricesByGroup prices;
        List<VisitorDetails> visitorsDetailsDailyReport;

        //Current date assigned to user later for daily and weekly reports.
        String currentDate = DateTime.Now.ToString("yyyy-MM-dd");

        //default value assigned for logged in user type.
        String loginUser = "admin";

        public Home(String loginType)
        {
            InitializeComponent();

            //assigning logged in user type.
            loginUser = loginType;

            //checking logged in user type for enabling or disabling editing of ticket rates.
            if (loginType == "staff") {
                dataGridTicketRates.Enabled = false;
            }

            //Initializing declared variables.
            xmlSerializer = new XmlSerializer(typeof(List<VisitorDetails>));
            visitorsDetails = new List<VisitorDetails>();
            xmlSerializerDailyReport = new XmlSerializer(typeof(List<VisitorDetails>));
            visitorsDetailsDailyReport = new List<VisitorDetails>();
            comboBoxDuration.Text = "1";
            comboBoxGroupBy.Text = "Single";
            txtBoxEntryTime.Text = DateTime.Now.ToString("t");
            txtBoxOutTime.Text = DateTime.Now.AddHours(1).ToString("t");
            radioBtnAdult.Checked = true;

            //Code for preparing visitor details file to import data.
            visitorDetailsFilePreparer();

            //Generating random id for ticket.
            txtBoxVisitorId.Text = generateId();

            //tabHomePage.SelectedIndexChanged += new EventHandler(tabHomePage_SelectedIndexChanged);

        }

        //String method to generate random ID for tickets, returns string id.
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

        //Method to prepare visitor details file.
        private void visitorDetailsFilePreparer()
        {
            FileStream fileStream = new FileStream(FileLocation.visitorDetailsFile, FileMode.OpenOrCreate, FileAccess.Write);
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


        //Issue ticket button on click action.
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Exception Handling for any uncertainity while issuing ticket.
            try
            {

            FileStream fileStreamEntry = new FileStream(FileLocation.visitorDetailsFile, FileMode.OpenOrCreate, FileAccess.Write);

            VisitorDetails visitorDetail = new VisitorDetails();

            Regex regexPhone = new Regex("^[0-9]+$");
            Regex regexName = new Regex(@"^[a-zA-Z]{2}$");

            visitorDetail.ID = txtBoxVisitorId.Text;

            //Checking if full name is empty or not.
            if (txtBoxFullName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxFullName.Text = "";
                fileStreamEntry.Close();
                return;
            }

            //Checking if full name contains only alphabets.
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

            //Checking if phone number is empty or not.
            if (txtBoxPhone.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your phone number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fileStreamEntry.Close();
                return;
            }
            //Checking if phone number is numeric or not.
            else if (!regexPhone.IsMatch(txtBoxPhone.Text.Trim()))
            {
                MessageBox.Show("Only numbers are allowed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxPhone.Text = "";
                fileStreamEntry.Close();
                return;
            }
            //Checking if phone number is of 10 digit or not.
            else if (txtBoxPhone.Text.Trim().Length != 10) {
                MessageBox.Show("Phone number must be of 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fileStreamEntry.Close();
                return;
            }
            {
                visitorDetail.Contact = txtBoxPhone.Text;
            }

            //Switch cases to decide the day being a weekday or weekend.
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

            Console.WriteLine("Unlimited: " + comboBoxDuration.Text);


            //Time duration of issue ticket.
            if (comboBoxDuration.Text == "Unlimited")
            {
                visitorDetail.Duration = 8;
            }
            else {
                visitorDetail.Duration = int.Parse(comboBoxDuration.Text);
            }
           

            //Age group radio button.
            if (radioBtnChild.Checked)
            {
                visitorDetail.AgeGroup = 12;
            }
            else
            {
                visitorDetail.AgeGroup = 13;
            }

            visitorDetail.ExitTime = DateTime.Parse(txtBoxOutTime.Text);
            visitorDetail.GroupNumber =comboBoxGroupBy.Text;


            //Exception handling for price calculation.
            try
            {
               
                //Price calculation for Group of 5
                if (visitorDetail.GroupNumber == "Group of 5" && visitorDetail.Duration == 1)
                {
                    txtBoxPrice.Text = prices.groupOfFiveOneHour.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 5" && visitorDetail.Duration == 2)
                {
                    txtBoxPrice.Text = prices.groupOfFiveTwoHours.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 5" && visitorDetail.Duration == 3)
                {
                    txtBoxPrice.Text = prices.groupOfFiveThreeHours.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 5" && visitorDetail.Duration == 4)
                {
                    txtBoxPrice.Text = prices.groupOfFiveFourHours.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 5" && visitorDetail.Duration == 8)
                {
                    txtBoxPrice.Text = prices.groupOfFiveUnlimitedHours.ToString();
                }

                //Price calculation for Group of 10
                else if (visitorDetail.GroupNumber == "Group of 10" && visitorDetail.Duration == 1)
                {
                    txtBoxPrice.Text = prices.groupOfTenOneHour.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 10" && visitorDetail.Duration == 2)
                {
                    txtBoxPrice.Text = prices.groupOfTenTwoHours.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 10" && visitorDetail.Duration == 3)
                {
                    txtBoxPrice.Text = prices.groupOfTenThreeHours.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 10" && visitorDetail.Duration == 4)
                {
                    txtBoxPrice.Text = prices.groupOfTenFourHours.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 10" && visitorDetail.Duration == 8)
                {
                    txtBoxPrice.Text = prices.groupOfTenUnlimitedHours.ToString();
                }

                //Price calculation for Group of 15
                else if (visitorDetail.GroupNumber == "Group of 15" && visitorDetail.Duration == 1)
                {
                    txtBoxPrice.Text = prices.groupOfFifteenOneHour.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 15" && visitorDetail.Duration == 2)
                {
                    txtBoxPrice.Text = prices.groupOfFifteenTwoHours.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 15" && visitorDetail.Duration == 3)
                {
                    txtBoxPrice.Text = prices.groupOfFifteenThreeHours.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 15" && visitorDetail.Duration == 4)
                {
                    txtBoxPrice.Text = prices.groupOfFifteenFourHours.ToString();
                }
                else if (visitorDetail.GroupNumber == "Group of 15" && visitorDetail.Duration == 8)
                {
                    txtBoxPrice.Text = prices.groupOfFifteenUnlimitedsHours.ToString();
                }

                //Price calculation for Single and Children.
                else if (visitorDetail.AgeGroup <= 12 && visitorDetail.GroupNumber == "Single" && visitorDetail.Duration == 1)
                {
                    txtBoxPrice.Text = prices.childOneHour.ToString();
                }
                else if (visitorDetail.AgeGroup <= 12 && visitorDetail.GroupNumber == "Single" && visitorDetail.AgeGroup != 0 && visitorDetail.Duration == 2)
                {
                    txtBoxPrice.Text = prices.childTwoHours.ToString();
                }
                else if (visitorDetail.AgeGroup <= 12 && visitorDetail.GroupNumber == "Single" && visitorDetail.AgeGroup != 0 && visitorDetail.Duration == 3)
                {
                    txtBoxPrice.Text = prices.childThreeHours.ToString();
                }
                else if (visitorDetail.AgeGroup <= 12 && visitorDetail.GroupNumber == "Single" && visitorDetail.AgeGroup != 0 && visitorDetail.Duration == 4)
                {
                    txtBoxPrice.Text = prices.childFourHours.ToString();
                }
                else if (visitorDetail.AgeGroup <= 12 && visitorDetail.GroupNumber == "Single" && visitorDetail.AgeGroup != 0 && visitorDetail.Duration == 8)
                {
                    txtBoxPrice.Text = prices.childUnlimitedHours.ToString();
                }

                //Price calculation for Single and Adult.
                else if (visitorDetail.AgeGroup > 12 && visitorDetail.AgeGroup != 0 && visitorDetail.GroupNumber == "Single" && visitorDetail.Duration == 1)
                {
                    txtBoxPrice.Text = prices.adultOneHour.ToString();
                }
                else if (visitorDetail.AgeGroup > 12 && visitorDetail.AgeGroup != 0 && visitorDetail.GroupNumber == "Single" && visitorDetail.Duration == 2)
                {
                    txtBoxPrice.Text = prices.adultTwoHours.ToString();
                }
                else if (visitorDetail.AgeGroup > 12 && visitorDetail.AgeGroup != 0 && visitorDetail.GroupNumber == "Single" && visitorDetail.Duration == 3)
                {
                    txtBoxPrice.Text = prices.adultThreeHours.ToString();
                }
                else if (visitorDetail.AgeGroup > 12 && visitorDetail.AgeGroup != 0 && visitorDetail.GroupNumber == "Single" && visitorDetail.Duration == 4)
                {
                    txtBoxPrice.Text = prices.adultFourHours.ToString();
                }
                else if (visitorDetail.AgeGroup > 12 && visitorDetail.AgeGroup != 0 && visitorDetail.GroupNumber == "Single" && visitorDetail.Duration == 8)
                {
                    txtBoxPrice.Text = prices.adultUnlimitedHours.ToString();
                }
            

            
            dataGridEntryForm.DataSource = null;
            visitorDetail.Price = int.Parse(txtBoxPrice.Text);

            //Inserting data into xml file.
            visitorsDetails.Add(visitorDetail);
            xmlSerializer.Serialize(fileStreamEntry, visitorsDetails);

            //Inserting data into the data source table
            dataGridEntryForm.DataSource = null;
            dataGridEntryForm.DataSource = visitorsDetails;
            fileStreamEntry.Close();

            txtBoxVisitorId.Text = generateId();
            txtBoxFullName.Text = "";
            txtBoxPhone.Text = "";
                }
                catch (Exception e10)
                {
                    fileStreamEntry.Close();
                    MessageBox.Show("Price could not be updated.");
                }

            }
            catch
            {
                
                MessageBox.Show("Ticket services are unavailable. Please try again!");
            }
       }

        //Entry Time textbox action
        private void txtEntryTime_Click(object sender, EventArgs e)
        {
            txtBoxEntryTime.Text = DateTime.Now.ToString("t");
        }


        //Method to return the total number of visitor for input date.
        public int visitorCalculator(String date)
        {

            int singleVisitor = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNumber == "Single").Count() * 1;
            int groupOf5Visitors = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNumber == "Group of 5").Count() * 5;
            int groupOf10Visitors = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNumber == "Group of 10").Count() * 10;
            int groupOf15Visitors = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == date && visitorDetail.GroupNumber == "Group of 15").Count() * 15;

            int totalVisitors = singleVisitor + groupOf5Visitors + groupOf10Visitors + groupOf15Visitors;
            return totalVisitors;

        }

        //Method to return the total price.
        public int grandTotal(String price)
        {

            int grandTotal = visitorsDetails.Where(visitorDetail => visitorDetail.Date.ToString("yyyy-MM-dd") == price).Select(visitorDetail => visitorDetail.Price).Sum();

            return grandTotal;
        }

        private void WeeklyReportDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //This method invokes various methods on login for importing data and generating reports, charts.
        private void tabPage5_Load(object sender, EventArgs e)
        {
            btnGenerateDailyReport_Click(sender, e);
            btnGenerateWeeklyReport_Click_1(sender, e);
            weeklyEarningsChart(DateTime.Now.ToString("yyyy-MM-dd"));
            weeklyVisitorsChart(DateTime.Now.ToString("yyyy-MM-dd"));
            importTicketRates();
            importVisitorData();
        }



        //This method generates the weekly visitor chart.
        private void weeklyVisitorsChart(String date)
        {
            FileStream fileStream = new FileStream(FileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

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

        //This method generates the weekly earnings chart.
        private void weeklyEarningsChart(String date)
        {
            FileStream fileStream = new FileStream(FileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

            try
            {
                DataTable dataTable;

                dataTable = chartRowAdder(fileStream);

                //Converting table into chart.
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

        //This method takes filestream as arguments and returns table.
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

        //This method loads charts.
        private void btnLoad_Click(object sender, EventArgs e)
        {

            String currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            weeklyEarningsChart(currentDate);
            weeklyVisitorsChart(currentDate);
        }
        
        //Method to update out time when duration is changed.
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


        //Button action to import visitor data from xml file.
        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            importVisitorData();
        }

        //Method to import visitor data from xml file into DataGridView.
        private void importVisitorData() {

            FileStream fileStream2 = new FileStream(FileLocation.visitorDetailsFile, FileMode.OpenOrCreate, FileAccess.Write);

            try
            {
                
                dataGridEntryForm.DataSource = null;
                dataGridEntryForm.DataSource = visitorsDetails;
                fileStream2.Close();
            }
            catch (Exception e2)
            {
                MessageBox.Show("Visitor data could not be imported.. Please try again!");
                fileStream2.Close();
            }
        }


        //Button action to generate Daily report.
        private void btnGenerateDailyReport_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(FileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

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
                MessageBox.Show("Daily report could no be generated. Please try again!");
                fileStream.Close();
            }
        }

        //Button action to generate Weekly report.
        private void btnGenerateWeeklyReport_Click_1(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(FileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

            try

            {
                DataTable data;

                data = chartRowAdder(fileStream);

                dataGridWeeklyReport.DataSource = data;

                fileStream.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Weekly report could no be generated. Please try again!");
                fileStream.Close();

            }
        }

        //Button action to sort weekly report by total visitor.
        private void btnSortVisitors_Click(object sender, EventArgs e)
        {
            visitorsDetails = new List<VisitorDetails>();

            FileStream fileStream = new FileStream(FileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

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

        //Button action to sort weekly report by total earnings.
        private void btnSortEarnings_Click(object sender, EventArgs e)
        {
            visitorsDetails = new List<VisitorDetails>();

            FileStream fileStream = new FileStream(FileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);

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

        //Method that takes table to be sorted and sort by type as input and uses bubble sorting algorithm for sorting to return sorted data table.
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



        //Button action to import ticket rates button.
        private void btnTicketImport_Click(object sender, EventArgs e)
        {

            importTicketRates();
        }

        //Method to calculate price change.
        private void priceCalculator() {



        }


        //Method to import ticket rates from csv file.
        private void importTicketRates() {
            try
            {
                DataTable data;
                data = NewDataTable(FileLocation.ticketRatesFile);

                dataGridTicketRates.DataSource = data;

                //TicketPrices price = new TicketPrices();
                prices = new TickePricesByGroup();
                //TicketPrice price = new TicketPrice();
                TicketPrices price = new TicketPrices();

                var streamReader = new StreamReader(FileLocation.ticketRatesFile);
                var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
                var ticketPrices = csvReader.GetRecords<TicketPrices>().ToList();
                foreach (var ticketPrice in ticketPrices)
                {
                    switch (ticketPrice.TicketGroup)
                    {
                        case "Child(5-12)":
                            prices.childOneHour = int.Parse(ticketPrice.OneHour);
                            prices.childTwoHours = int.Parse(ticketPrice.TwoHours);
                            prices.childThreeHours = int.Parse(ticketPrice.ThreeHours);
                            prices.childFourHours = int.Parse(ticketPrice.FourHours);
                            prices.childUnlimitedHours = int.Parse(ticketPrice.Unlimited);
                            break;
                        case "Adult > 12":
                            prices.adultOneHour = int.Parse(ticketPrice.OneHour);
                            prices.adultTwoHours = int.Parse(ticketPrice.TwoHours);
                            prices.adultThreeHours = int.Parse(ticketPrice.ThreeHours);
                            prices.adultFourHours = int.Parse(ticketPrice.FourHours);
                            prices.adultUnlimitedHours = int.Parse(ticketPrice.Unlimited);
                            break;
                        case "Group of 5":
                            prices.groupOfFiveOneHour = int.Parse(ticketPrice.OneHour);
                            prices.groupOfFiveTwoHours = int.Parse(ticketPrice.TwoHours);
                            prices.groupOfFiveThreeHours = int.Parse(ticketPrice.ThreeHours);
                            prices.groupOfFiveFourHours = int.Parse(ticketPrice.FourHours);
                            prices.groupOfFiveUnlimitedHours = int.Parse(ticketPrice.Unlimited);
                            break;
                        case "Group of 10":
                            prices.groupOfTenOneHour = int.Parse(ticketPrice.OneHour);
                            prices.groupOfTenTwoHours = int.Parse(ticketPrice.TwoHours);
                            prices.groupOfTenThreeHours = int.Parse(ticketPrice.ThreeHours);
                            prices.groupOfTenFourHours = int.Parse(ticketPrice.FourHours);
                            prices.groupOfTenUnlimitedHours = int.Parse(ticketPrice.Unlimited);
                            break;
                        case "Group of 15":
                            prices.groupOfFifteenOneHour = int.Parse(ticketPrice.OneHour);
                            prices.groupOfFifteenTwoHours = int.Parse(ticketPrice.TwoHours);
                            prices.groupOfFifteenThreeHours = int.Parse(ticketPrice.ThreeHours);
                            prices.groupOfFifteenFourHours = int.Parse(ticketPrice.FourHours);
                            prices.groupOfFifteenUnlimitedsHours = int.Parse(ticketPrice.Unlimited);
                            break;
                        default:
                            prices.groupOfFifteenOneHour = int.Parse(ticketPrice.OneHour);
                            prices.groupOfFifteenTwoHours = int.Parse(ticketPrice.TwoHours);
                            prices.groupOfFifteenThreeHours = int.Parse(ticketPrice.ThreeHours);
                            prices.groupOfFifteenFourHours = int.Parse(ticketPrice.FourHours);
                            prices.groupOfFifteenUnlimitedsHours = int.Parse(ticketPrice.Unlimited);
                            break;
                    }
                }
                MessageBox.Show("Ticket rates import successfull.");
                csvReader.Dispose();
            }
            catch
            {
                MessageBox.Show("Ticket rates import failed. PLease try again.");
            }
        }

        //Method to parse csv file into data table.
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

        //Button action for export button.
        private void btnTicketExport_Click(object sender, EventArgs e)
        {
            //Allowing only admin to use the export feature.
            if (loginUser == "admin")
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
                                Console.WriteLine(dataCell.Value);
                                csvFile += dataCell.Value.ToString().TrimEnd(',').Replace(",", ";") + ',';
                            }
                        }
                        csvFile += "\r\n";
                    }
                    File.WriteAllText(FileLocation.ticketRatesFile, csvFile);
                    MessageBox.Show("Successfully exported.");
                }
                catch
                {
                    MessageBox.Show("Ticket rates export failed. PLease try again.");
                }
            }
            else {
                MessageBox.Show("Ticket rates export is only available for Admin.");
            }
            
        }

        //Button action to search ticket detail using ticket id.
        private void btnSearchEntry_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(FileLocation.visitorDetailsFile, FileMode.Open, FileAccess.Read);
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

                fileStream.Close();
            }
            catch
            {
                fileStream.Close();
            }
        }

        private void dataGridTicketRates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (loginUser == "staff")
            //{

            //    dataGridTicketRates.AllowUserToAddRows = false;
            //    dataGridTicketRates.AllowDrop = false;
            //    this.dataGridTicketRates.AllowUserToDeleteRows = false;
            //    this.
            //    this.dataGridTicketRates.AllowUserToAddRows = false;
            //    this.dataGridTicketRates.AllowUserToAddRows = false;
            //    this.dataGridTicketRates.AllowUserToAddRows = false;
            //}
        }

        //logout button action 
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        //Invokes priceCalculator when full name is changed.
        private void txtBoxFullName_TextChanged(object sender, EventArgs e)
        {
            priceCalculator();
        }

        //Invokes priceCalculator when duration is changed.
        private void comboBoxGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            priceCalculator();
        }
    }

}