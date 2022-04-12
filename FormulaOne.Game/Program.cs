using FormulaOne;
using FormulaOne.Game;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
        .AddSingleton<IDriverDatabase, DriverDatabase>()
        .AddSingleton<IRankingService, RankingService>()
        .AddSingleton<IPointCalculatorService, PointCalculatorService>()
        .AddSingleton<Race>()
        .BuildServiceProvider();

//toon rankings voor de race
Console.WriteLine("Klassement voor de race:");
var rankingService = serviceProvider.GetService<IRankingService>();
rankingService.DisplayRanking();

while (true)
{
    Console.WriteLine("Druk op een toets om een nieuwe race te starten\n\n");
    Console.ReadKey();

    //start de race simulatie
    var race = serviceProvider.GetService<Race>();
    var raceResult = await race.StartRace();

    //werk rankings bij
    rankingService.UpdateRankings(raceResult);

    //rankings na de race
    Console.WriteLine("\n\nKlassement na de race:");
    rankingService.DisplayRanking();
}