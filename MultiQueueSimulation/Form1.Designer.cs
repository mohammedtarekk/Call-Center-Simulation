namespace MultiQueueSimulation
{
    partial class Form1
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
            this.customerGrid = new System.Windows.Forms.DataGridView();
            this.customerNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomArrivalDigits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interarrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomServicesDigits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicesBeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicesTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeInQueue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noOfServers_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stoppingNo_txt = new System.Windows.Forms.TextBox();
            this.stoppingCriteria_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectionMethod_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.serviceDist_grid = new System.Windows.Forms.DataGridView();
            this.serviceDistServerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDistTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDistProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labl7 = new System.Windows.Forms.Label();
            this.interarrivalDist_grid = new System.Windows.Forms.DataGridView();
            this.ok_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.InterarivalDistTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interarrivalDistProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDist_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interarrivalDist_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // customerGrid
            // 
            this.customerGrid.AllowUserToAddRows = false;
            this.customerGrid.AllowUserToDeleteRows = false;
            this.customerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerNo,
            this.randomArrivalDigits,
            this.interarrivalTime,
            this.arrivalTime,
            this.randomServicesDigits,
            this.servicesBeginTime,
            this.servicesTime,
            this.serviceEndTime,
            this.timeInQueue,
            this.serverIndex});
            this.customerGrid.Location = new System.Drawing.Point(12, 189);
            this.customerGrid.Name = "customerGrid";
            this.customerGrid.ReadOnly = true;
            this.customerGrid.RowHeadersVisible = false;
            this.customerGrid.Size = new System.Drawing.Size(902, 257);
            this.customerGrid.TabIndex = 0;
            // 
            // customerNo
            // 
            this.customerNo.HeaderText = "Customer No.";
            this.customerNo.Name = "customerNo";
            this.customerNo.ReadOnly = true;
            this.customerNo.Width = 70;
            // 
            // randomArrivalDigits
            // 
            this.randomArrivalDigits.HeaderText = "Random Arrival";
            this.randomArrivalDigits.Name = "randomArrivalDigits";
            this.randomArrivalDigits.ReadOnly = true;
            // 
            // interarrivalTime
            // 
            this.interarrivalTime.HeaderText = "Interarrival time";
            this.interarrivalTime.Name = "interarrivalTime";
            this.interarrivalTime.ReadOnly = true;
            // 
            // arrivalTime
            // 
            this.arrivalTime.HeaderText = "Arrival Time";
            this.arrivalTime.Name = "arrivalTime";
            this.arrivalTime.ReadOnly = true;
            // 
            // randomServicesDigits
            // 
            this.randomServicesDigits.HeaderText = "Random Service";
            this.randomServicesDigits.Name = "randomServicesDigits";
            this.randomServicesDigits.ReadOnly = true;
            // 
            // servicesBeginTime
            // 
            this.servicesBeginTime.HeaderText = "Service Begining";
            this.servicesBeginTime.Name = "servicesBeginTime";
            this.servicesBeginTime.ReadOnly = true;
            // 
            // servicesTime
            // 
            this.servicesTime.HeaderText = "Service Time";
            this.servicesTime.Name = "servicesTime";
            this.servicesTime.ReadOnly = true;
            // 
            // serviceEndTime
            // 
            this.serviceEndTime.HeaderText = "Service End Time";
            this.serviceEndTime.Name = "serviceEndTime";
            this.serviceEndTime.ReadOnly = true;
            // 
            // timeInQueue
            // 
            this.timeInQueue.HeaderText = "Time in Queue";
            this.timeInQueue.Name = "timeInQueue";
            this.timeInQueue.ReadOnly = true;
            this.timeInQueue.Width = 70;
            // 
            // serverIndex
            // 
            this.serverIndex.HeaderText = "Server";
            this.serverIndex.Name = "serverIndex";
            this.serverIndex.ReadOnly = true;
            // 
            // noOfServers_txt
            // 
            this.noOfServers_txt.Location = new System.Drawing.Point(156, 46);
            this.noOfServers_txt.Name = "noOfServers_txt";
            this.noOfServers_txt.Size = new System.Drawing.Size(100, 20);
            this.noOfServers_txt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of servers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stopping Number";
            // 
            // stoppingNo_txt
            // 
            this.stoppingNo_txt.Location = new System.Drawing.Point(156, 74);
            this.stoppingNo_txt.Name = "stoppingNo_txt";
            this.stoppingNo_txt.Size = new System.Drawing.Size(100, 20);
            this.stoppingNo_txt.TabIndex = 3;
            // 
            // stoppingCriteria_txt
            // 
            this.stoppingCriteria_txt.Location = new System.Drawing.Point(156, 100);
            this.stoppingCriteria_txt.Name = "stoppingCriteria_txt";
            this.stoppingCriteria_txt.Size = new System.Drawing.Size(100, 20);
            this.stoppingCriteria_txt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stopping Criteria";
            // 
            // selectionMethod_txt
            // 
            this.selectionMethod_txt.Location = new System.Drawing.Point(156, 126);
            this.selectionMethod_txt.Name = "selectionMethod_txt";
            this.selectionMethod_txt.Size = new System.Drawing.Size(100, 20);
            this.selectionMethod_txt.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Selection Method";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(297, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "ServiceDistribution";
            // 
            // serviceDist_grid
            // 
            this.serviceDist_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceDist_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serviceDistServerID,
            this.serviceDistTime,
            this.serviceDistProbability});
            this.serviceDist_grid.Location = new System.Drawing.Point(298, 22);
            this.serviceDist_grid.Name = "serviceDist_grid";
            this.serviceDist_grid.Size = new System.Drawing.Size(313, 150);
            this.serviceDist_grid.TabIndex = 7;
            // 
            // serviceDistServerID
            // 
            this.serviceDistServerID.HeaderText = "Server ID";
            this.serviceDistServerID.Name = "serviceDistServerID";
            this.serviceDistServerID.Width = 70;
            // 
            // serviceDistTime
            // 
            this.serviceDistTime.HeaderText = "Time";
            this.serviceDistTime.Name = "serviceDistTime";
            // 
            // serviceDistProbability
            // 
            this.serviceDistProbability.HeaderText = "Probablity";
            this.serviceDistProbability.Name = "serviceDistProbability";
            // 
            // labl7
            // 
            this.labl7.AutoSize = true;
            this.labl7.Location = new System.Drawing.Point(629, 6);
            this.labl7.Name = "labl7";
            this.labl7.Size = new System.Drawing.Size(108, 13);
            this.labl7.TabIndex = 12;
            this.labl7.Text = "InterarrivalDistribution";
            // 
            // interarrivalDist_grid
            // 
            this.interarrivalDist_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.interarrivalDist_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InterarivalDistTime,
            this.interarrivalDistProbability});
            this.interarrivalDist_grid.Location = new System.Drawing.Point(631, 22);
            this.interarrivalDist_grid.Name = "interarrivalDist_grid";
            this.interarrivalDist_grid.Size = new System.Drawing.Size(283, 150);
            this.interarrivalDist_grid.TabIndex = 11;
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(267, 463);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(151, 43);
            this.ok_btn.TabIndex = 13;
            this.ok_btn.Text = "Start System";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(581, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 43);
            this.button1.TabIndex = 14;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(424, 463);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 43);
            this.button2.TabIndex = 15;
            this.button2.Text = "Measure Performance";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // InterarivalDistTime
            // 
            this.InterarivalDistTime.HeaderText = "Time";
            this.InterarivalDistTime.Name = "InterarivalDistTime";
            // 
            // interarrivalDistProbability
            // 
            this.interarrivalDistProbability.HeaderText = "Probability";
            this.interarrivalDistProbability.Name = "interarrivalDistProbability";
            this.interarrivalDistProbability.Width = 140;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 518);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.labl7);
            this.Controls.Add(this.interarrivalDist_grid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.serviceDist_grid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stoppingCriteria_txt);
            this.Controls.Add(this.selectionMethod_txt);
            this.Controls.Add(this.stoppingNo_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noOfServers_txt);
            this.Controls.Add(this.customerGrid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDist_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interarrivalDist_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomArrivalDigits;
        private System.Windows.Forms.DataGridViewTextBoxColumn interarrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomServicesDigits;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicesBeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicesTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeInQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverIndex;
        private System.Windows.Forms.TextBox noOfServers_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stoppingNo_txt;
        private System.Windows.Forms.TextBox stoppingCriteria_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox selectionMethod_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView serviceDist_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDistServerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDistTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDistProbability;
        private System.Windows.Forms.Label labl7;
        private System.Windows.Forms.DataGridView interarrivalDist_grid;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterarivalDistTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn interarrivalDistProbability;
    }
}

