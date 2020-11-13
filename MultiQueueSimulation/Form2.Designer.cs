namespace MultiQueueSimulation
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.avg_waiting_time_lbl = new System.Windows.Forms.Label();
            this.max_queue_length_lbl = new System.Windows.Forms.Label();
            this.waiting_prob_lbl = new System.Windows.Forms.Label();
            this.perf_dgv = new System.Windows.Forms.DataGridView();
            this.serverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idleProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averageServiceTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.perf_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "System Performance:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "1. Average waiting time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "2. Maximum queue length:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "3. Waiting probability:";
            // 
            // avg_waiting_time_lbl
            // 
            this.avg_waiting_time_lbl.AutoSize = true;
            this.avg_waiting_time_lbl.Location = new System.Drawing.Point(150, 37);
            this.avg_waiting_time_lbl.Name = "avg_waiting_time_lbl";
            this.avg_waiting_time_lbl.Size = new System.Drawing.Size(0, 13);
            this.avg_waiting_time_lbl.TabIndex = 4;
            // 
            // max_queue_length_lbl
            // 
            this.max_queue_length_lbl.AutoSize = true;
            this.max_queue_length_lbl.Location = new System.Drawing.Point(161, 59);
            this.max_queue_length_lbl.Name = "max_queue_length_lbl";
            this.max_queue_length_lbl.Size = new System.Drawing.Size(0, 13);
            this.max_queue_length_lbl.TabIndex = 5;
            // 
            // waiting_prob_lbl
            // 
            this.waiting_prob_lbl.AutoSize = true;
            this.waiting_prob_lbl.Location = new System.Drawing.Point(139, 82);
            this.waiting_prob_lbl.Name = "waiting_prob_lbl";
            this.waiting_prob_lbl.Size = new System.Drawing.Size(0, 13);
            this.waiting_prob_lbl.TabIndex = 6;
            // 
            // perf_dgv
            // 
            this.perf_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.perf_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serverID,
            this.idleProbability,
            this.averageServiceTime,
            this.utilization});
            this.perf_dgv.Location = new System.Drawing.Point(16, 132);
            this.perf_dgv.Name = "perf_dgv";
            this.perf_dgv.RowHeadersVisible = false;
            this.perf_dgv.Size = new System.Drawing.Size(353, 329);
            this.perf_dgv.TabIndex = 7;
            // 
            // serverID
            // 
            this.serverID.HeaderText = "Server ID";
            this.serverID.Name = "serverID";
            this.serverID.ReadOnly = true;
            this.serverID.Width = 50;
            // 
            // idleProbability
            // 
            this.idleProbability.HeaderText = "Idle Probability";
            this.idleProbability.Name = "idleProbability";
            this.idleProbability.ReadOnly = true;
            // 
            // averageServiceTime
            // 
            this.averageServiceTime.HeaderText = "Average Service Time";
            this.averageServiceTime.Name = "averageServiceTime";
            this.averageServiceTime.ReadOnly = true;
            // 
            // utilization
            // 
            this.utilization.HeaderText = "Utilization";
            this.utilization.Name = "utilization";
            this.utilization.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 47);
            this.button1.TabIndex = 8;
            this.button1.Text = "Generate Charts";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Servers Performance:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 522);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.perf_dgv);
            this.Controls.Add(this.waiting_prob_lbl);
            this.Controls.Add(this.max_queue_length_lbl);
            this.Controls.Add(this.avg_waiting_time_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Performance Measures";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.perf_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label avg_waiting_time_lbl;
        private System.Windows.Forms.Label max_queue_length_lbl;
        private System.Windows.Forms.Label waiting_prob_lbl;
        private System.Windows.Forms.DataGridView perf_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn idleProbability;
        private System.Windows.Forms.DataGridViewTextBoxColumn averageServiceTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn utilization;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}