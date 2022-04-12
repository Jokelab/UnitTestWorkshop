using NUnit.Framework;

namespace FormulaOne.Tests
{
    public class PointCalculatorServiceTests
    {
        /// <summary>
        /// Create system under test
        /// </summary>
        /// <returns></returns>
        private PointCalculatorService CreateSut()
        {
            return new PointCalculatorService();
        }

        [Test]
        public void CalculatePoints_should_return_25_when_position_1()
        {
            //arrange
            const int position = 1;
            const bool hasFastestLap = false;
            var sut = CreateSut();

            //act
            var result = sut.CalculatePoints(position, hasFastestLap);

            //assert
            Assert.AreEqual(25, result);
        }

     
    }
}