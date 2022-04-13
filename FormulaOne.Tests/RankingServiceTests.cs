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
            _pointCalculatorServiceMock.Setup(x => x.CalculatePoints(raceResultPosition, It.IsAny<bool>())).Returns(raceResultPoints);
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

        [Test]
        public void UpdateRankings_should_increment_wincount_when_race_won()
        {
            //arrange
            const string driverName = "Doutzen Kroes";
            const int currentwins = 1;
            const int raceResultPoints = 25;
            const int raceResultPosition = 1;
            _pointCalculatorServiceMock.Setup(x => x.CalculatePoints(raceResultPosition, It.IsAny<bool>())).Returns(raceResultPoints);
            _driverDatabaseMock.Setup(x => x.GetDriverByName(driverName)).Returns(
                new Driver() { Name = driverName, Points = 0, WinCount = currentwins, PodiumCount = 1 });
            var sut = CreateSut();
            var result = new List<RaceResult>() {
                new RaceResult(driverName, raceResultPosition, true, new System.DateTime(2022,4,14))
            };

            //act
            sut.UpdateRankings(result);

            //assert: aantal wins is opgehoogd
            _driverDatabaseMock.Verify(x => x.UpdateDriverRanking(driverName, It.IsAny<int>(), currentwins + 1, It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void UpdateRankings_should_increment_podiumcount_when_position_between_1_and_3()
        {
            //arrange
            const string driverName = "Doutzen Kroes";
            const int currentPodiumCount = 1;
            const int raceResultPoints = 25;
            const int raceResultPosition = 1;
            _pointCalculatorServiceMock.Setup(x => x.CalculatePoints(raceResultPosition, It.IsAny<bool>())).Returns(raceResultPoints);
            _driverDatabaseMock.Setup(x => x.GetDriverByName(driverName)).Returns(
                new Driver() { Name = driverName, Points = 0, WinCount = 1, PodiumCount = currentPodiumCount });
            var sut = CreateSut();
            var result = new List<RaceResult>() {
                new RaceResult(driverName, raceResultPosition, true, new System.DateTime(2022,4,14))
            };

            //act
            sut.UpdateRankings(result);

            //assert: aantal wins is opgehoogd
            _driverDatabaseMock.Verify(x => x.UpdateDriverRanking(driverName, It.IsAny<int>(), It.IsAny<int>(), currentPodiumCount + 1), Times.Once);
        }

        [Test]
        public void UpdateRankings_should_not_increment_points_when_no_results_provided()
        {
            //arrange
            var sut = CreateSut();
            var result = new List<RaceResult>();

            //act
            sut.UpdateRankings(result);

            //assert: aantal wins is opgehoogd
            _driverDatabaseMock.Verify(x => x.UpdateDriverRanking(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

    }
}