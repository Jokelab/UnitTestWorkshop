
namespace FormulaOne
{
    public interface IRace
    {
        string Name { get; set; }
        RaceResult FinishDriver(string driverName);
        Task Start();
    }
}