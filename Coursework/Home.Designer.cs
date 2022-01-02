
namespace Coursework
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabHomePage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxDuration = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtOutTime = new System.Windows.Forms.TextBox();
            this.lblOutTime = new System.Windows.Forms.Label();
            this.btnTicket = new System.Windows.Forms.Button();
            this.txtEntryTime = new System.Windows.Forms.TextBox();
            this.lblEntryTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboGroupBy = new System.Windows.Forms.ComboBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioAdult = new System.Windows.Forms.RadioButton();
            this.radioChild = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVisitorID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblTicket = new System.Windows.Forms.Label();
            this.btnTicketExport = new System.Windows.Forms.Button();
            this.btnTicketEdit = new System.Windows.Forms.Button();
            this.btnTicketImport = new System.Windows.Forms.Button();
            this.dataGridTicketRates = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnImportDailyReport = new System.Windows.Forms.Button();
            this.DailyReportButton = new System.Windows.Forms.Button();
            this.DailyReportDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.SortByEarningButton = new System.Windows.Forms.Button();
            this.SortByVisitorsButton = new System.Windows.Forms.Button();
            this.WeeklyReportButton = new System.Windows.Forms.Button();
            this.WeeklyReportDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chartEarning = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnGenerateVisitorChart = new System.Windows.Forms.Button();
            this.chartVisitor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tabHomePage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTicketRates)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DailyReportDataGridView)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeeklyReportDataGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVisitor)).BeginInit();
            this.SuspendLayout();
            // 
            // tabHomePage
            // 
            this.tabHomePage.Controls.Add(this.tabPage1);
            this.tabHomePage.Controls.Add(this.tabPage2);
            this.tabHomePage.Controls.Add(this.tabPage3);
            this.tabHomePage.Controls.Add(this.tabPage5);
            this.tabHomePage.Controls.Add(this.tabPage4);
            this.tabHomePage.Location = new System.Drawing.Point(0, 0);
            this.tabHomePage.Name = "tabHomePage";
            this.tabHomePage.SelectedIndex = 0;
            this.tabHomePage.Size = new System.Drawing.Size(1165, 677);
            this.tabHomePage.TabIndex = 0;
            this.tabHomePage.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1157, 648);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Entry Form";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.comboBoxDuration);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.txtOutTime);
            this.panel1.Controls.Add(this.lblOutTime);
            this.panel1.Controls.Add(this.btnTicket);
            this.panel1.Controls.Add(this.txtEntryTime);
            this.panel1.Controls.Add(this.lblEntryTime);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboGroupBy);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.txtFullName);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtVisitorID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DatePicker);
            this.panel1.Location = new System.Drawing.Point(9, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 270);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBoxDuration
            // 
            this.comboBoxDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDuration.FormattingEnabled = true;
            this.comboBoxDuration.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "Unlimited"});
            this.comboBoxDuration.Location = new System.Drawing.Point(969, 116);
            this.comboBoxDuration.Name = "comboBoxDuration";
            this.comboBoxDuration.Size = new System.Drawing.Size(146, 24);
            this.comboBoxDuration.TabIndex = 42;
            this.comboBoxDuration.SelectedIndexChanged += new System.EventHandler(this.comboBoxDuration_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(798, 123);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 17);
            this.label9.TabIndex = 41;
            this.label9.Text = "Duration :";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(969, 166);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(146, 22);
            this.txtPrice.TabIndex = 39;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(817, 171);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(78, 17);
            this.lblPrice.TabIndex = 38;
            this.lblPrice.Text = "Price :";
            // 
            // txtOutTime
            // 
            this.txtOutTime.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutTime.Location = new System.Drawing.Point(969, 63);
            this.txtOutTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutTime.Name = "txtOutTime";
            this.txtOutTime.ReadOnly = true;
            this.txtOutTime.Size = new System.Drawing.Size(146, 22);
            this.txtOutTime.TabIndex = 37;
            this.txtOutTime.TextChanged += new System.EventHandler(this.txtOutTime_TextChanged);
            // 
            // lblOutTime
            // 
            this.lblOutTime.AutoSize = true;
            this.lblOutTime.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutTime.Location = new System.Drawing.Point(798, 68);
            this.lblOutTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutTime.Name = "lblOutTime";
            this.lblOutTime.Size = new System.Drawing.Size(108, 17);
            this.lblOutTime.TabIndex = 36;
            this.lblOutTime.Text = "Out Time :";
            // 
            // btnTicket
            // 
            this.btnTicket.Location = new System.Drawing.Point(957, 219);
            this.btnTicket.Margin = new System.Windows.Forms.Padding(4);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(158, 37);
            this.btnTicket.TabIndex = 4;
            this.btnTicket.Text = "Entry";
            this.btnTicket.UseVisualStyleBackColor = true;
            this.btnTicket.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtEntryTime
            // 
            this.txtEntryTime.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntryTime.Location = new System.Drawing.Point(969, 10);
            this.txtEntryTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtEntryTime.Name = "txtEntryTime";
            this.txtEntryTime.ReadOnly = true;
            this.txtEntryTime.Size = new System.Drawing.Size(146, 22);
            this.txtEntryTime.TabIndex = 35;
            this.txtEntryTime.Click += new System.EventHandler(this.txtEntryTime_Click);
            // 
            // lblEntryTime
            // 
            this.lblEntryTime.AutoSize = true;
            this.lblEntryTime.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntryTime.Location = new System.Drawing.Point(798, 17);
            this.lblEntryTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntryTime.Name = "lblEntryTime";
            this.lblEntryTime.Size = new System.Drawing.Size(128, 17);
            this.lblEntryTime.TabIndex = 34;
            this.lblEntryTime.Text = "Entry Time :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(409, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "Date : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(398, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "Group :";
            // 
            // comboGroupBy
            // 
            this.comboGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGroupBy.Items.AddRange(new object[] {
            "Single",
            "Group of 5",
            "Group of 10",
            "Group of 15"});
            this.comboGroupBy.Location = new System.Drawing.Point(496, 116);
            this.comboGroupBy.Margin = new System.Windows.Forms.Padding(4);
            this.comboGroupBy.Name = "comboGroupBy";
            this.comboGroupBy.Size = new System.Drawing.Size(243, 24);
            this.comboGroupBy.TabIndex = 29;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(173, 118);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(195, 22);
            this.txtPhone.TabIndex = 28;
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(173, 63);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(195, 22);
            this.txtFullName.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioAdult);
            this.panel3.Controls.Add(this.radioChild);
            this.panel3.Location = new System.Drawing.Point(495, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(243, 81);
            this.panel3.TabIndex = 26;
            // 
            // radioAdult
            // 
            this.radioAdult.AutoSize = true;
            this.radioAdult.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAdult.Location = new System.Drawing.Point(11, 43);
            this.radioAdult.Margin = new System.Windows.Forms.Padding(4);
            this.radioAdult.Name = "radioAdult";
            this.radioAdult.Size = new System.Drawing.Size(217, 19);
            this.radioAdult.TabIndex = 9;
            this.radioAdult.TabStop = true;
            this.radioAdult.Text = "Adult (older than 12)";
            this.radioAdult.UseVisualStyleBackColor = true;
            this.radioAdult.CheckedChanged += new System.EventHandler(this.AdultButton_CheckedChanged);
            // 
            // radioChild
            // 
            this.radioChild.AutoSize = true;
            this.radioChild.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioChild.Location = new System.Drawing.Point(11, 14);
            this.radioChild.Margin = new System.Windows.Forms.Padding(4);
            this.radioChild.Name = "radioChild";
            this.radioChild.Size = new System.Drawing.Size(190, 19);
            this.radioChild.TabIndex = 8;
            this.radioChild.TabStop = true;
            this.radioChild.Text = "Children (till 12)";
            this.radioChild.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(418, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Age :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Visitor ID :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 123);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Phone Number:";
            // 
            // txtVisitorID
            // 
            this.txtVisitorID.Enabled = false;
            this.txtVisitorID.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVisitorID.Location = new System.Drawing.Point(171, 12);
            this.txtVisitorID.Margin = new System.Windows.Forms.Padding(4);
            this.txtVisitorID.Name = "txtVisitorID";
            this.txtVisitorID.Size = new System.Drawing.Size(195, 22);
            this.txtVisitorID.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Full Name :";
            // 
            // DatePicker
            // 
            this.DatePicker.Location = new System.Drawing.Point(495, 166);
            this.DatePicker.Margin = new System.Windows.Forms.Padding(4);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(240, 22);
            this.DatePicker.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 303);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 44;
            this.dataGridView1.Size = new System.Drawing.Size(1131, 334);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblTicket);
            this.tabPage2.Controls.Add(this.btnTicketExport);
            this.tabPage2.Controls.Add(this.btnTicketEdit);
            this.tabPage2.Controls.Add(this.btnTicketImport);
            this.tabPage2.Controls.Add(this.dataGridTicketRates);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1157, 648);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tickets";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicket.Location = new System.Drawing.Point(462, 34);
            this.lblTicket.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(212, 38);
            this.lblTicket.TabIndex = 7;
            this.lblTicket.Text = "Ticket Rates";
            // 
            // btnTicketExport
            // 
            this.btnTicketExport.Location = new System.Drawing.Point(714, 431);
            this.btnTicketExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnTicketExport.Name = "btnTicketExport";
            this.btnTicketExport.Size = new System.Drawing.Size(237, 52);
            this.btnTicketExport.TabIndex = 6;
            this.btnTicketExport.Text = "Export";
            this.btnTicketExport.UseVisualStyleBackColor = true;
            // 
            // btnTicketEdit
            // 
            this.btnTicketEdit.Location = new System.Drawing.Point(469, 431);
            this.btnTicketEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnTicketEdit.Name = "btnTicketEdit";
            this.btnTicketEdit.Size = new System.Drawing.Size(237, 52);
            this.btnTicketEdit.TabIndex = 5;
            this.btnTicketEdit.Text = "Edit";
            this.btnTicketEdit.UseVisualStyleBackColor = true;
            this.btnTicketEdit.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTicketImport
            // 
            this.btnTicketImport.Location = new System.Drawing.Point(224, 431);
            this.btnTicketImport.Margin = new System.Windows.Forms.Padding(4);
            this.btnTicketImport.Name = "btnTicketImport";
            this.btnTicketImport.Size = new System.Drawing.Size(237, 52);
            this.btnTicketImport.TabIndex = 4;
            this.btnTicketImport.Text = "Import";
            this.btnTicketImport.UseVisualStyleBackColor = true;
            // 
            // dataGridTicketRates
            // 
            this.dataGridTicketRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTicketRates.Location = new System.Drawing.Point(15, 103);
            this.dataGridTicketRates.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridTicketRates.Name = "dataGridTicketRates";
            this.dataGridTicketRates.RowHeadersWidth = 44;
            this.dataGridTicketRates.Size = new System.Drawing.Size(1125, 282);
            this.dataGridTicketRates.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnImportDailyReport);
            this.tabPage3.Controls.Add(this.DailyReportButton);
            this.tabPage3.Controls.Add(this.DailyReportDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1157, 648);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Daily Report";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnImportDailyReport
            // 
            this.btnImportDailyReport.Location = new System.Drawing.Point(77, 517);
            this.btnImportDailyReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportDailyReport.Name = "btnImportDailyReport";
            this.btnImportDailyReport.Size = new System.Drawing.Size(237, 52);
            this.btnImportDailyReport.TabIndex = 15;
            this.btnImportDailyReport.Text = "Import";
            this.btnImportDailyReport.UseVisualStyleBackColor = true;
            this.btnImportDailyReport.Click += new System.EventHandler(this.btnImportDailyReport_Click);
            // 
            // DailyReportButton
            // 
            this.DailyReportButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.DailyReportButton.Font = new System.Drawing.Font("Lucida Calligraphy", 13.8F, System.Drawing.FontStyle.Bold);
            this.DailyReportButton.ForeColor = System.Drawing.Color.White;
            this.DailyReportButton.Location = new System.Drawing.Point(361, 517);
            this.DailyReportButton.Name = "DailyReportButton";
            this.DailyReportButton.Size = new System.Drawing.Size(401, 72);
            this.DailyReportButton.TabIndex = 14;
            this.DailyReportButton.Text = "Generate Daily Report";
            this.DailyReportButton.UseVisualStyleBackColor = false;
            this.DailyReportButton.Click += new System.EventHandler(this.DailyReportButton_Click);
            // 
            // DailyReportDataGridView
            // 
            this.DailyReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DailyReportDataGridView.Location = new System.Drawing.Point(8, 38);
            this.DailyReportDataGridView.Name = "DailyReportDataGridView";
            this.DailyReportDataGridView.RowHeadersWidth = 51;
            this.DailyReportDataGridView.RowTemplate.Height = 24;
            this.DailyReportDataGridView.Size = new System.Drawing.Size(1133, 428);
            this.DailyReportDataGridView.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.SortByEarningButton);
            this.tabPage5.Controls.Add(this.SortByVisitorsButton);
            this.tabPage5.Controls.Add(this.WeeklyReportButton);
            this.tabPage5.Controls.Add(this.WeeklyReportDataGridView);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1157, 648);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Weekly Report";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Click += new System.EventHandler(this.tabPage5_Click);
            // 
            // SortByEarningButton
            // 
            this.SortByEarningButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.SortByEarningButton.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortByEarningButton.ForeColor = System.Drawing.Color.White;
            this.SortByEarningButton.Location = new System.Drawing.Point(791, 563);
            this.SortByEarningButton.Name = "SortByEarningButton";
            this.SortByEarningButton.Size = new System.Drawing.Size(283, 41);
            this.SortByEarningButton.TabIndex = 20;
            this.SortByEarningButton.Text = "Sort by Earning";
            this.SortByEarningButton.UseVisualStyleBackColor = false;
            // 
            // SortByVisitorsButton
            // 
            this.SortByVisitorsButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.SortByVisitorsButton.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortByVisitorsButton.ForeColor = System.Drawing.Color.White;
            this.SortByVisitorsButton.Location = new System.Drawing.Point(791, 516);
            this.SortByVisitorsButton.Name = "SortByVisitorsButton";
            this.SortByVisitorsButton.Size = new System.Drawing.Size(283, 41);
            this.SortByVisitorsButton.TabIndex = 19;
            this.SortByVisitorsButton.Text = "Sort by Visitors";
            this.SortByVisitorsButton.UseVisualStyleBackColor = false;
            // 
            // WeeklyReportButton
            // 
            this.WeeklyReportButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.WeeklyReportButton.Font = new System.Drawing.Font("Lucida Calligraphy", 13.8F, System.Drawing.FontStyle.Bold);
            this.WeeklyReportButton.ForeColor = System.Drawing.Color.White;
            this.WeeklyReportButton.Location = new System.Drawing.Point(166, 516);
            this.WeeklyReportButton.Name = "WeeklyReportButton";
            this.WeeklyReportButton.Size = new System.Drawing.Size(383, 88);
            this.WeeklyReportButton.TabIndex = 17;
            this.WeeklyReportButton.Text = "Generate Weekly Report";
            this.WeeklyReportButton.UseVisualStyleBackColor = false;
            this.WeeklyReportButton.Click += new System.EventHandler(this.WeeklyReportButton_Click);
            // 
            // WeeklyReportDataGridView
            // 
            this.WeeklyReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeeklyReportDataGridView.Location = new System.Drawing.Point(8, 42);
            this.WeeklyReportDataGridView.Name = "WeeklyReportDataGridView";
            this.WeeklyReportDataGridView.RowHeadersWidth = 51;
            this.WeeklyReportDataGridView.RowTemplate.Height = 24;
            this.WeeklyReportDataGridView.Size = new System.Drawing.Size(1133, 429);
            this.WeeklyReportDataGridView.TabIndex = 1;
            this.WeeklyReportDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WeeklyReportDataGridView_CellContentClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.chartEarning);
            this.tabPage4.Controls.Add(this.btnGenerateVisitorChart);
            this.tabPage4.Controls.Add(this.chartVisitor);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1157, 648);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Charts";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(809, 502);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Earning Chart";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 488);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Visitor Chart";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // chartEarning
            // 
            chartArea9.Name = "ChartArea1";
            this.chartEarning.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chartEarning.Legends.Add(legend9);
            this.chartEarning.Location = new System.Drawing.Point(617, 57);
            this.chartEarning.Name = "chartEarning";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.chartEarning.Series.Add(series9);
            this.chartEarning.Size = new System.Drawing.Size(503, 416);
            this.chartEarning.TabIndex = 2;
            this.chartEarning.Text = "chart2";
            // 
            // btnGenerateVisitorChart
            // 
            this.btnGenerateVisitorChart.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateVisitorChart.Location = new System.Drawing.Point(429, 561);
            this.btnGenerateVisitorChart.Name = "btnGenerateVisitorChart";
            this.btnGenerateVisitorChart.Size = new System.Drawing.Size(265, 48);
            this.btnGenerateVisitorChart.TabIndex = 1;
            this.btnGenerateVisitorChart.Text = "Generate Chart";
            this.btnGenerateVisitorChart.UseVisualStyleBackColor = true;
            this.btnGenerateVisitorChart.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chartVisitor
            // 
            chartArea10.Name = "ChartArea1";
            this.chartVisitor.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chartVisitor.Legends.Add(legend10);
            this.chartVisitor.Location = new System.Drawing.Point(37, 57);
            this.chartVisitor.Name = "chartVisitor";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.chartVisitor.Series.Add(series10);
            this.chartVisitor.Size = new System.Drawing.Size(504, 416);
            this.chartVisitor.TabIndex = 0;
            this.chartVisitor.Text = "chart1";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(21, 219);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(152, 37);
            this.btnLoad.TabIndex = 43;
            this.btnLoad.Text = "Import";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click_1);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 675);
            this.Controls.Add(this.tabHomePage);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.tabPage5_Load);
            this.tabHomePage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTicketRates)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DailyReportDataGridView)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WeeklyReportDataGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVisitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabHomePage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnGenerateVisitorChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVisitor;
        private System.Windows.Forms.Button btnTicketEdit;
        private System.Windows.Forms.Button btnTicketImport;
        private System.Windows.Forms.DataGridView dataGridTicketRates;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnTicketExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioAdult;
        private System.Windows.Forms.RadioButton radioChild;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVisitorID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.TextBox txtEntryTime;
        private System.Windows.Forms.Label lblEntryTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboGroupBy;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.TextBox txtOutTime;
        private System.Windows.Forms.Label lblOutTime;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button DailyReportButton;
        private System.Windows.Forms.DataGridView DailyReportDataGridView;
        private System.Windows.Forms.Button SortByEarningButton;
        private System.Windows.Forms.Button SortByVisitorsButton;
        private System.Windows.Forms.Button WeeklyReportButton;
        private System.Windows.Forms.DataGridView WeeklyReportDataGridView;
        private System.Windows.Forms.Button btnImportDailyReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEarning;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDuration;
        private System.Windows.Forms.Button btnLoad;
    }
}

