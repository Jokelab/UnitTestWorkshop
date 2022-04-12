namespace FormulaOne
{
    public class DriverDatabase : IDriverDatabase
    {
        private Driver[] _drivers =
            {
                new Driver{ Name = "C. Leclerc", Team = "Scuderia Ferrari", Points = 71, WinCount = 2, PodiumCount = 3},
                new Driver{ Name = "G. Russel", Team="Mercedes", Points = 37, WinCount = 0, PodiumCount = 1},
                new Driver{ Name = "C. Sainz Jr.", Team = "Scuderia Ferrari", Points = 33, WinCount = 0, PodiumCount = 2},
                new Driver{ Name = "S. Perez", Team = "Red Bull", Points = 30, WinCount = 0, PodiumCount = 1},
                new Driver{ Name = "L. Hamilton", Team = "Mercedes", Points = 28, WinCount = 0, PodiumCount = 1},
                new Driver{ Name = "M. Verstappen", Team = "Red Bull", Points = 25, WinCount = 1, PodiumCount = 1},
            };

        public IEnumerable<Driver> GetDrivers()
        {
            return _drivers;
        }

        public Driver GetDriverByName(string name)
        {
            return _drivers.FirstOrDefault(x => x.Name.Equals(name));
        }

        public void UpdateDriverRanking(string driverName, int points, int winCount, int podiumCount)
        {
            var existing = GetDriverByName(driverName);
            if (existing != null)
            {
                existing.Points = points;
                existing.WinCount = winCount;
                existing.PodiumCount = podiumCount;
            }
        }
    }
}