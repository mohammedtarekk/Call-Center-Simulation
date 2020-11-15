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
        public static SimulationSystem sys;
        SimulationCase row;
        int customersCount = 0;
        Random rand;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
                sys = new SimulationSystem();
                customersCount = 0;
                rand = new Random();
                customerGrid.Rows.Clear();

                initialize_inputs();
                start_process();
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

        /// <summary>
        /// gets the interarrival time of a given number buy checking its comulative prob range.
        /// </summary>
        /// <param name="t">Time Distribution List</param>
        /// <param name="n">The Random Digit</param>
        /// <returns>Interarrival time</returns>
        public int get_Range(List<TimeDistribution> t, int n)
        {
            // TODO
            foreach (TimeDistribution timeDistribution in t)
            {
                if (n <= timeDistribution.MaxRange && n >= timeDistribution.MinRange)
                    return timeDistribution.Time;
            }
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

            sys.CalculateCummProbabilty();
        }

        public void start_process()
        {
            int lastEndTime = 0;
            int maxQueueLength = 0;
            int totalWaitingTime = 0;
            int totalSimulationTime = 0;
            int NoOfCustomerWhoWaited = 0;
            List<SimulationCase> queue = new List<SimulationCase>();

            while ((sys.stoppingCase == "NumberOfCustomers" && customersCount < sys.StoppingNumber) || (sys.stoppingCase == "SimulationEndTime" && lastEndTime < sys.StoppingNumber))
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
                        int random = rand.Next(0, sys.Servers.Count);
                        row.AssignedServer = sys.Servers[random];
                    }
                    row.RandomInterArrival = 1;
                }
                else // the rest of the customers
                {
                    row.RandomInterArrival = rand.Next(1, 101);
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
                            if (row.AssignedServer.ID == 0)
                            {
                                // select server with minimum end time
                                int min = sys.Servers[0].currentEnd;
                                int server_id = 1;
                                foreach (var server in sys.Servers)
                                {
                                    if (server.currentEnd < min)
                                    {
                                        min = server.currentEnd;
                                        server_id = server.ID;
                                    }
                                }

                                // pass to the waiting queue
                                row.AssignedServer = sys.Servers[server_id - 1];
                                row.TimeInQueue = row.AssignedServer.currentEnd - row.ArrivalTime;

                                // performance calculations
                                NoOfCustomerWhoWaited++;
                                totalWaitingTime += row.TimeInQueue;
                            }
                        }
                    }
                    else // random server
                    {
                        // search for a random idle server
                        for(int i = sys.Servers.Count - 1; i >= 0; i--)
                        {
                            if (row.ArrivalTime >= sys.Servers[i].currentEnd)
                            {
                                row.AssignedServer = sys.Servers[i];
                                break;
                            }
                        }

                        // in case there is no idle servers
                        if (row.AssignedServer.ID == 0)
                        {
                            // select server with minimum end time
                            int min = sys.Servers[0].currentEnd;
                            int server_id = 1;
                            foreach (var server in sys.Servers)
                            {
                                if (server.currentEnd < min)
                                {
                                    min = server.currentEnd;
                                    server_id = server.ID;
                                }
                            }

                            // pass to the waiting queue
                            row.AssignedServer = sys.Servers[server_id - 1];
                            row.TimeInQueue = row.AssignedServer.currentEnd - row.ArrivalTime;

                            // performance calculations
                            NoOfCustomerWhoWaited++;
                            totalWaitingTime += row.TimeInQueue;                            
                        }
                    }

                }

                row.RandomService = rand.Next(1, 101);
                row.ServiceTime = get_Range(row.AssignedServer.TimeDistribution, row.RandomService);
                row.StartTime = row.ArrivalTime + row.TimeInQueue;
                row.EndTime = row.ServiceTime + row.StartTime;
                sys.Servers[row.AssignedServer.ID - 1].currentEnd = row.EndTime;
                lastEndTime = row.EndTime;              

                // chart calculations
                // add the current working houers to this server
                for(int i = row.StartTime; i <row.EndTime; i++)
                        sys.Servers[row.AssignedServer.ID - 1].workingHours.Add(i);                    


                if (sys.stoppingCase == "NumberOfCustomers" || (sys.stoppingCase == "SimulationEndTime" && lastEndTime <= sys.StoppingNumber))
                {
                    // performance calculations
                    sys.Servers[row.AssignedServer.ID - 1].totalServiceTime += row.ServiceTime;
                    sys.Servers[row.AssignedServer.ID - 1].noOfCustomers++;
                    sys.Servers[row.AssignedServer.ID - 1].serverCustomers.Add(row);
                    if(lastEndTime > totalSimulationTime)
                        totalSimulationTime = lastEndTime;

                    // this code is to calculate maximum queue length
                    if (row.TimeInQueue > 0)
                    {
                        queue.Add(row);

                        for (int i = 0; i < queue.Count; i++)
                        {
                            if (queue[queue.Count - 1].ArrivalTime >= queue[i].StartTime)
                                queue.Remove(queue[i]);
                        }

                        if (queue.Count > maxQueueLength)
                            maxQueueLength = queue.Count;
                    }

                    // update data grid view
                    customerGrid.Rows.Add(customersCount + 1, row.RandomInterArrival, row.InterArrival, row.ArrivalTime, row.RandomService, row.StartTime, row.ServiceTime, row.EndTime, row.TimeInQueue, row.AssignedServer.ID);

                    // add this customer to simulation table
                    sys.SimulationTable.Add(row);

                    customersCount++;
                }
                else 
                    break;                  
            }

            // set final system performance measuers
            sys.PerformanceMeasures.MaxQueueLength = maxQueueLength;
            sys.PerformanceMeasures.AverageWaitingTime = (decimal)totalWaitingTime / customersCount;
            sys.PerformanceMeasures.WaitingProbability = (decimal)NoOfCustomerWhoWaited / customersCount;

            // set final servers perfomance
            foreach (var server in sys.Servers)
            {
                if(server.noOfCustomers != 0)
                    server.AverageServiceTime = (decimal)server.totalServiceTime / server.noOfCustomers;

                server.Utilization = (decimal)server.totalServiceTime / totalSimulationTime;

                // set idle time for each server
                if (server.serverCustomers.Count == 0)
                    server.idleTime = totalSimulationTime;

                for(int i = 0; i < server.serverCustomers.Count; i++)
                {
                    if (i == 0)
                        server.idleTime += sys.SimulationTable[0].ArrivalTime + server.serverCustomers[i].StartTime;

                    if ((i == server.serverCustomers.Count - 1) && (server.serverCustomers[i].EndTime != totalSimulationTime))
                        server.idleTime += Math.Abs(totalSimulationTime - server.serverCustomers[i].EndTime);                        
                    
                    if(i == server.serverCustomers.Count - 1)
                        break;

                    server.idleTime += Math.Abs(server.serverCustomers[i].EndTime - server.serverCustomers[i+1].StartTime);
                }
                server.IdleProbability = (decimal)server.idleTime / totalSimulationTime;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = TestingManager.Test(sys, Constants.FileNames.TestCase2);
            MessageBox.Show(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();            
        }
    }
}
