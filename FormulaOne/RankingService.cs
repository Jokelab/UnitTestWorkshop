namespace FormulaOne
{
    public class RankingService : IRankingService
    {
        private readonly IDriverDatabase _driverDatabase;
        private readonly IPointCalculatorService _pointCalculatorService;
        public RankingService(IDriverDatabase driverDatabase, IPointCalculatorService pointCalculatorService)
        {
            _driverDatabase = driverDatabase;
            _pointCalculatorService = pointCalculatorService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="results"></param>
        public void UpdateRankings(IEnumerable<RaceResult> results)
        {
            foreach (var raceResult in results)
            {
                var points = _pointCalculatorService.CalculatePoints(raceResult.Position, raceResult.FastestLap);
                var driver = _driverDatabase.GetDriverByName(raceResult.DriverName);
                driver.Points += points;

                if (raceResult.Position == 1)
                {
                    driver.WinCount++;
                }
                if (raceResult.Position >= 1 && raceResult.Position <= 3)
                {
                    driver.PodiumCount++;
                }
                _driverDatabase.UpdateDriverRanking(driver.Name, driver.Points, driver.PodiumCount, driver.WinCount);
            }
        }

        public void DisplayRanking()
        {
            var rank = 1;
            Console.WriteLine(String.Format("\t\t  {0,20}|{1,20}|{2,10}|{3,10}|{4,10}|", "Naam", "Team", "Punten", "#Wins", "#Podiums"));
            foreach (var driver in _driverDatabase.GetDrivers().OrderByDescending(x => x.Points))
            {
                Console.WriteLine($"Rank #{rank:d2}\t: {driver}");
                rank++;
            }
        }
    }
}