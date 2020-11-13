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
        }

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }

        public string selectionMethod = null;
        public string stoppingCase = null;
        public int HP = 0;
 
        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

        /// <summary>
        /// Calculates the Cummulative probability for interarrival distribution and for servers in the system.
        /// </summary>
        public void CalculateCummProbabilty()
        {
            CalculateCummProbabilty_helper(InterarrivalDistribution);
            foreach (Server server in Servers)
            {
                CalculateCummProbabilty_helper(server.TimeDistribution);
            }
        }

        private void CalculateCummProbabilty_helper(List<TimeDistribution> timeDist)
        {
            timeDist[0].CummProbability = timeDist[0].Probability;
            timeDist[0].MinRange = 1;
            timeDist[0].MaxRange =Convert.ToInt32(timeDist[0].CummProbability * 100);
            for (int i = 1; i < timeDist.Count; i++)
            {
                timeDist[i].CummProbability = timeDist[i].Probability+ timeDist[i-1].CummProbability;
                timeDist[i].MinRange = Convert.ToInt32(timeDist[i-1].MaxRange)+1;
                timeDist[i].MaxRange = Convert.ToInt32(timeDist[i].CummProbability * 100);
            }
        }
    }
}
