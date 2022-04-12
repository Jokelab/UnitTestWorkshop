using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace FormulaOne.Tests
{
    public class RankingServiceTests
    {
        private Mock<IDriverDatabase> _driverDatabaseMock;
        private Mock<IPointCalculatorService> _pointCalculatorServiceMock;

        [SetUp]
        public void Setup()
        {
            _driverDatabaseMock = new Mock<IDriverDatabase>();
            _pointCalculatorServiceMock = new Mock<IPointCalculatorService>();
        }

        private RankingService CreateSut()
        {
            return new RankingService(_driverDatabaseMock.Object, _pointCalculatorServiceMock.Object);
        }

        [Test]
        public void UpdateRankings_should_increment_points_when_points_scored()
        {
            //arrange
            const string driverName = "Doutzen Kroes";
            const int currentPoints = 10;
            const int raceResultPoints = 6;
            const int raceResultPosition = 7;
            _pointCalculatorServiceMock.Setup(x => x.CalculatePoints(1, It.IsAny<bool>())).Returns(raceResultPoints);
            _driverDatabaseMock.Setup(x => x.GetDriverByName(driverName)).Returns(
                new Driver() { Name = driverName, Points = currentPoints, WinCount = 3, PodiumCount = 1 });
            var sut = CreateSut();
            var result = new List<RaceResult>() {
                new RaceResult(driverName, raceResultPosition, true, new System.DateTime(2022,4,14))
            };

            //act
            sut.UpdateRankings(result);

            //assert: aantal punten is opgehoogd (10 + 6 = 16)
            _driverDatabaseMock.Verify(x => x.UpdateDriverRanking(driverName, 16, It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        //todo: maak een test die controleert dat het aantal gewonnen races wordt bijgewerkt wanneer de race is gewonnen
        [Test]
        public void UpdateRankings_should_increment_wincount_when_race_won()
        {
            Assert.Fail();
        }

        //todo: maak een test die controleert dat het aantal podiums wordt bijgewerkt wanneer op plek 1, 2 of 3 gefinished
        [Test]
        public void UpdateRankings_should_increment_podiumcount_when_position_between_1_and_3()
        {
            Assert.Fail();
        }

        //todo: maak een test die controleert dat niets is bijgewerkt wanneer de lijst van resulaten leeg is
        [Test]
        public void UpdateRankings_should_not_increment_points_when_no_results_provided()
        {
            Assert.Fail();
        }

    }
}