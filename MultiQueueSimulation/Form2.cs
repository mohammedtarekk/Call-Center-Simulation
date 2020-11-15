using MultiQueueModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiQueueSimulation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // system performance
            avg_waiting_time_lbl.Text = Form1.sys.PerformanceMeasures.AverageWaitingTime.ToString();
            max_queue_length_lbl.Text = Form1.sys.PerformanceMeasures.MaxQueueLength.ToString();
            waiting_prob_lbl.Text = Form1.sys.PerformanceMeasures.WaitingProbability.ToString();

            // servers performance
            foreach(var server in Form1.sys.Servers)
                perf_dgv.Rows.Add(server.ID, server.IdleProbability, server.AverageServiceTime, server.Utilization);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 chartForm;
            SimulationSystem.currentGeneratedChart = -1;
            foreach (var server in Form1.sys.Servers)
            {
                if(server.noOfCustomers != 0)
                {
                    chartForm = new Form3();
                    SimulationSystem.currentGeneratedChart++;
                    chartForm.Show();
                }             
            }
        }
    }
}
