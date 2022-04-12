namespace FormulaOne
{
    public interface IPointCalculatorService
    {
        int CalculatePoints(int position, bool fastestLap);
    }
}