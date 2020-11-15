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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.sys.Servers[SimulationSystem.currentGeneratedChart].ID.ToString();
            for (int i = 0; i < Form1.sys.Servers[SimulationSystem.currentGeneratedChart].workingHours.Count; i++)
                chart1.Series["Time"].Points.AddXY(Form1.sys.Servers[SimulationSystem.currentGeneratedChart].workingHours[i].ToString(), "1");
        }
    }
}
