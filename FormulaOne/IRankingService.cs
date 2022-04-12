
namespace FormulaOne
{
    public interface IRankingService
    {
        void DisplayRanking();
        void UpdateRankings(IEnumerable<RaceResult> results);
    }
}