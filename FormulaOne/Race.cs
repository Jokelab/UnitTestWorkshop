using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Game
{
    public class Race
    {
        private readonly IDriverDatabase _driverDatabase;
        private readonly Random _random = new Random();

        private int _positionCounter;
        private int _fastestlapIndex;

        public Race(IDriverDatabase driverDatabase)
        {
            _driverDatabase = driverDatabase;
        }
        public async Task<IEnumerable<RaceResult>> StartRace()
        {
            Console.WriteLine($"== Race gestart! Vroem! ==");
            List<RaceResult> results = new();
            var drivers = _driverDatabase.GetDrivers().ToList();
            var totalCount = drivers.Count;
            _positionCounter = 1;
            _fastestlapIndex = _random.Next(0, totalCount);
            while (drivers.Any())
            {
                var index = _random.Next(0, drivers.Count);
                var driver = drivers[index];

                var result = new RaceResult(driver.Name, _positionCounter, _positionCounter - 1 == _fastestlapIndex, DateTime.Now);
                Console.WriteLine(result);
                results.Add(result);

                drivers.RemoveAt(index);
                await Task.Delay(_random.Next(0, 3000));
                _positionCounter++;
            }
            return results;
        }
    }
}
