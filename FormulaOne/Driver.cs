using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne
{
    public class Driver
    {
        public string Name { get; set; }
        public string Team { get; set; }

        public int Points { get; set; }
        public int WinCount { get; set; }
        public int PodiumCount { get; set; }

        public override string ToString()
        {
            return String.Format("{0,20}|{1,20}|{2,10}|{3,10}|{4,10}|",Name, Team, Points, WinCount, PodiumCount);
        }
    }
}
