using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.TimeDistribution = new List<TimeDistribution>();
            this.currentEnd = 0;
            this.noOfCustomers = 0;
            this.totalServiceTime = 0;
            this.idleTime = 0;
            this.serverCustomers = new List<SimulationCase>();
            this.workingHours = new List<int>();
        }

        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; } 
        public decimal Utilization { get; set; }

        public List<TimeDistribution> TimeDistribution;

        public int currentEnd;
        public int noOfCustomers;
        public int totalServiceTime;
        public int idleTime;
        public List<SimulationCase> serverCustomers;
        public List<int> workingHours;

        //optional if needed use them
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }
    }
}
