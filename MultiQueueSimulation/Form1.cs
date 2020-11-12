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
        int customersCount = 0;
        Random rand = new Random();

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
                initialize_inputs();
                start_process();
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

        public int get_Range(List<TimeDistribution> t, int n)
        {
            // TODO
            return 0;
        }

        public void initialize_inputs()
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

        public void start_process()
        {
            while(customersCount < sys.StoppingNumber)
            {
                // generate a new customer
                row = new SimulationCase();

                // server assignment
                if (customersCount == 0) // 1st customer arrival
                {
                    row.ArrivalTime = 0;
                    if (sys.selectionMethod == "HighestPriority")
                        row.AssignedServer = sys.Servers[sys.HP];
                    else
                    {
                        int random = rand.Next(0, sys.Servers.Count - 1);
                        row.AssignedServer = sys.Servers[random];
                    }
                    row.RandomInterArrival = 1;
                }
                else // the rest of the customers
                {
                    row.RandomInterArrival = rand.Next(1, 100);
                    row.InterArrival = get_Range(sys.InterarrivalDistribution, row.RandomInterArrival);
                    row.ArrivalTime = sys.SimulationTable[customersCount - 1].ArrivalTime + row.InterArrival;

                    // assign server
                    if (sys.selectionMethod == "HighestPriority")
                    {
                        if (row.ArrivalTime >= sys.Servers[sys.HP].currentEnd)
                            row.AssignedServer = sys.Servers[sys.HP];
                        else
                        {
                            // search for another idle server
                            foreach (var server in sys.Servers)
                            {
                                if (row.ArrivalTime >= server.currentEnd)
                                {
                                    row.AssignedServer = server;
                                    break;
                                }
                            }

                            // in case there is no idle servers
                            if (row.AssignedServer == null)
                            {
                                // select server with minimum end time
                                int min = sys.Servers[0].currentEnd;
                                int server_id = 0;
                                foreach (var server in sys.Servers)
                                {
                                    if (server.currentEnd < min)
                                    {
                                        min = server.currentEnd;
                                        server_id = server.ID;
                                    }
                                }

                                // pass to the waiting queue
                                row.AssignedServer = sys.Servers[server_id];
                                row.TimeInQueue = row.AssignedServer.currentEnd - row.ArrivalTime;
                            }
                        }
                    }
                    else // random server
                    {
                        // search for a random idle server
                        int random;
                        bool found_idle = false;
                        while (!found_idle)
                        {
                            random = rand.Next(0, sys.Servers.Count - 1);
                            if (row.ArrivalTime >= sys.Servers[random].currentEnd)
                            {
                                row.AssignedServer = sys.Servers[random];
                                found_idle = true;
                            }
                        }

                        // in case there is no idle servers
                        if (row.AssignedServer == null)
                        {
                            // select server with minimum end time
                            int min = sys.Servers[0].currentEnd;
                            int server_id = 0;
                            foreach (var server in sys.Servers)
                            {
                                if (server.currentEnd < min)
                                {
                                    min = server.currentEnd;
                                    server_id = server.ID;
                                }
                            }

                            // pass to the waiting queue
                            row.AssignedServer = sys.Servers[server_id];
                            row.TimeInQueue = row.AssignedServer.currentEnd - row.ArrivalTime;
                        }
                    }

                }

                row.RandomService = rand.Next(1, 100);
                row.ServiceTime = get_Range(row.AssignedServer.TimeDistribution, row.RandomService);
                row.StartTime = row.ArrivalTime + row.TimeInQueue;
                row.EndTime = row.ServiceTime + row.StartTime;
                sys.Servers[row.AssignedServer.ID].currentEnd = row.EndTime;

                // add this customer to simulation table
                sys.SimulationTable.Add(row);

                // update data grid view
                customerGrid.Rows.Add(customersCount + 1, row.RandomInterArrival, row.InterArrival, row.ArrivalTime, row.RandomService, row.StartTime, row.ServiceTime, row.EndTime, row.TimeInQueue, row.AssignedServer.ID);

                customersCount++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = TestingManager.Test(sys, Constants.FileNames.TestCase1);
            MessageBox.Show(result);
        }
    }
}
