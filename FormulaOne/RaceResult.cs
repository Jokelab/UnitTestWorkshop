using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne
{
    public class RaceResult
    {
        public RaceResult(string driver, int position, bool fastestLap, DateTime finishTime)
        {
            DriverName = driver;
            Position = position;
            FastestLap = fastestLap;
            FinishTime = finishTime;
        }

        public bool FastestLap { get; }
        public int Position { get; }
        public string DriverName { get; }
        public DateTime FinishTime { get; }

        public override string ToString()
        {
            return $"#{Position}\t{ DriverName} gefinished om {DateTime.Now.ToString("HH:mm:ss.fff")}" + (FastestLap ? " \tFASTEST LAP" : "");
        }

    }
}
