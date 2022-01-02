
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabHomePage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtOutTime = new System.Windows.Forms.TextBox();
            this.lblOutTime = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.GeneratePriceBtn = new System.Windows.Forms.Button();
            this.ExitTimeText = new System.Windows.Forms.TextBox();
            this.UserCodeText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GroupOfBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblTicket = new System.Windows.Forms.Label();
            this.btnTicketExport = new System.Windows.Forms.Button();
            this.btnTicketEdit = new System.Windows.Forms.Button();
            this.btnTicketImport = new System.Windows.Forms.Button();
            this.dataGridTicketRates = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnLoad = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabHomePage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTicketRates)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.GroupOfBox);
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
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.txtOutTime);
            this.panel1.Controls.Add(this.lblOutTime);
            this.panel1.Controls.Add(this.btnSave);
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
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(495, 161);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(195, 22);
            this.txtPrice.TabIndex = 39;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(398, 166);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(78, 17);
            this.lblPrice.TabIndex = 38;
            this.lblPrice.Text = "Price :";
            // 
            // txtOutTime
            // 
            this.txtOutTime.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutTime.Location = new System.Drawing.Point(875, 161);
            this.txtOutTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutTime.Name = "txtOutTime";
            this.txtOutTime.Size = new System.Drawing.Size(195, 22);
            this.txtOutTime.TabIndex = 37;
            this.txtOutTime.TextChanged += new System.EventHandler(this.txtOutTime_TextChanged);
            // 
            // lblOutTime
            // 
            this.lblOutTime.AutoSize = true;
            this.lblOutTime.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutTime.Location = new System.Drawing.Point(759, 166);
            this.lblOutTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutTime.Name = "lblOutTime";
            this.lblOutTime.Size = new System.Drawing.Size(108, 17);
            this.lblOutTime.TabIndex = 36;
            this.lblOutTime.Text = "Out Time :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(944, 206);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 37);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtEntryTime
            // 
            this.txtEntryTime.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntryTime.Location = new System.Drawing.Point(875, 116);
            this.txtEntryTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtEntryTime.Name = "txtEntryTime";
            this.txtEntryTime.ReadOnly = true;
            this.txtEntryTime.Size = new System.Drawing.Size(195, 22);
            this.txtEntryTime.TabIndex = 35;
            this.txtEntryTime.Click += new System.EventHandler(this.txtEntryTime_Click);
            // 
            // lblEntryTime
            // 
            this.lblEntryTime.AutoSize = true;
            this.lblEntryTime.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntryTime.Location = new System.Drawing.Point(759, 120);
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
            this.label5.Location = new System.Drawing.Point(789, 14);
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
            this.label4.Location = new System.Drawing.Point(399, 118);
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
            "Single ",
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
            this.DatePicker.Location = new System.Drawing.Point(875, 9);
            this.DatePicker.Margin = new System.Windows.Forms.Padding(4);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(240, 22);
            this.DatePicker.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.GeneratePriceBtn);
            this.panel2.Controls.Add(this.ExitTimeText);
            this.panel2.Controls.Add(this.UserCodeText);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(52, 386);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 366);
            this.panel2.TabIndex = 19;
            // 
            // GeneratePriceBtn
            // 
            this.GeneratePriceBtn.Location = new System.Drawing.Point(36, 196);
            this.GeneratePriceBtn.Margin = new System.Windows.Forms.Padding(4);
            this.GeneratePriceBtn.Name = "GeneratePriceBtn";
            this.GeneratePriceBtn.Size = new System.Drawing.Size(133, 57);
            this.GeneratePriceBtn.TabIndex = 3;
            this.GeneratePriceBtn.Text = "Generate Price";
            this.GeneratePriceBtn.UseVisualStyleBackColor = true;
            // 
            // ExitTimeText
            // 
            this.ExitTimeText.Location = new System.Drawing.Point(36, 130);
            this.ExitTimeText.Margin = new System.Windows.Forms.Padding(4);
            this.ExitTimeText.Name = "ExitTimeText";
            this.ExitTimeText.Size = new System.Drawing.Size(132, 22);
            this.ExitTimeText.TabIndex = 2;
            // 
            // UserCodeText
            // 
            this.UserCodeText.Location = new System.Drawing.Point(36, 46);
            this.UserCodeText.Margin = new System.Windows.Forms.Padding(4);
            this.UserCodeText.Name = "UserCodeText";
            this.UserCodeText.Size = new System.Drawing.Size(132, 22);
            this.UserCodeText.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 111);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Exit Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "User Code";
            // 
            // GroupOfBox
            // 
            this.GroupOfBox.Items.AddRange(new object[] {
            "Single ",
            "Group of Five",
            "Group of Ten",
            "Group of Fifteen"});
            this.GroupOfBox.Location = new System.Drawing.Point(215, 354);
            this.GroupOfBox.Margin = new System.Windows.Forms.Padding(4);
            this.GroupOfBox.Name = "GroupOfBox";
            this.GroupOfBox.Size = new System.Drawing.Size(160, 24);
            this.GroupOfBox.TabIndex = 18;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(437, 347);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 44;
            this.dataGridView1.Size = new System.Drawing.Size(688, 294);
            this.dataGridView1.TabIndex = 3;
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
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1157, 648);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Daily Report";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1157, 648);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Weekly Report";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnLoad);
            this.tabPage4.Controls.Add(this.chart1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1157, 648);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Charts";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(393, 429);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(236, 33);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(231, 26);
            this.chart1.Name = "chart1";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(670, 352);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
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
            this.tabHomePage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTicketRates)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabHomePage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button GeneratePriceBtn;
        private System.Windows.Forms.TextBox ExitTimeText;
        private System.Windows.Forms.TextBox UserCodeText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox GroupOfBox;
        private System.Windows.Forms.TextBox txtOutTime;
        private System.Windows.Forms.Label lblOutTime;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;

    }
}

