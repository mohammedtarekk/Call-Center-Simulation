using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            this.Servers = new List<Server>();
            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();

            assignServer();
        }

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }

        ///////////// IMPLEMENTATION /////////////
        public string selectionMethod = null;
        public string stoppingCase = null;

        public void assignServer()
        {
            ///// TODO
            //NumberOfServers = 2;
            //StoppingNumber = 100;
            //Server s1 = new Server();
            //s1.ID = 1;

            //Server s2 = new Server();
            //s2.ID = 2;
            //Servers = [s1, s2];
            //s2.TimeDistribution = 
            ////InterarrivalDistribution
            //StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
            //SelectionMethod = Enums.SelectionMethod.Random;

        }



        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

    }
}
