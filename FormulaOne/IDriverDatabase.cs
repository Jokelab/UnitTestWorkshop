namespace FormulaOne
{
    public interface IDriverDatabase
    {
        IEnumerable<Driver> GetDrivers();
        Driver GetDriverByName(string name);
        void UpdateDriverRanking(string name, int points, int winCount, int podiumCount);
    }
}
