using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        SimulationSystem sys = new SimulationSystem();
        SimulationCase row;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            try
            {                

                sys.NumberOfServers = Convert.ToInt32(noOfServers_txt.Text);
                sys.StoppingNumber = Convert.ToInt32(stoppingNo_txt.Text);

                // map stopping criteria
                List<KeyValuePair<string, int>> StoppingCriteriaList = GetEnumList<Enums.StoppingCriteria>();
                int x = Convert.ToInt32(stoppingCriteria_txt.Text);
                foreach (var val in StoppingCriteriaList)
                {
                    if (val.Value == x)
                    {
                        sys.stoppingCase = val.Key;
                        break;
                    }
                }

                // map selection method
                List<KeyValuePair<string, int>> SelectionMethodList = GetEnumList<Enums.SelectionMethod>();
                int y = Convert.ToInt32(selectionMethod_txt.Text);
                foreach (var val in SelectionMethodList)
                {
                    if (val.Value == y)
                    {
                        sys.selectionMethod = val.Key;
                        break;
                    }
                }

                // servers data
                Server server;
                for (int i = 0; i < sys.NumberOfServers; i++)
                {
                    server = new Server();
                    server.ID = i + 1;
                    sys.Servers.Add(server);
                }

                // service distribution
                TimeDistribution serverTimeDist;
                int count = serviceDist_grid.Rows.Count - 1;
                for (int i = 0; i < count; i++)
                {
                    serverTimeDist = new TimeDistribution();
                    serverTimeDist.Time = Convert.ToInt32(serviceDist_grid.Rows[i].Cells[1].Value);
                    serverTimeDist.Probability = Convert.ToDecimal(serviceDist_grid.Rows[i].Cells[2].Value);

                    int current = Convert.ToInt32(serviceDist_grid.Rows[i].Cells[0].Value.ToString());
                    sys.Servers[current - 1].TimeDistribution.Add(serverTimeDist);
                }

                // interarrival distribution
                int numOfInterarrivals = interarrivalDist_grid.Rows.Count - 1;
                TimeDistribution interarrivalDist;
                for (int i = 0; i < numOfInterarrivals; i++)
                {
                    interarrivalDist = new TimeDistribution();
                    interarrivalDist.Time = Convert.ToInt32(interarrivalDist_grid.Rows[i].Cells[0].Value.ToString());
                    interarrivalDist.Probability = Convert.ToDecimal(interarrivalDist_grid.Rows[i].Cells[1].Value.ToString());

                    sys.InterarrivalDistribution.Add(interarrivalDist);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public List<KeyValuePair<string, int>> GetEnumList<T>()
        {
            var list = new List<KeyValuePair<string, int>>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                list.Add(new KeyValuePair<string, int>(e.ToString(), (int)e));
            }
            return list;
        }
    }
}
