using NUnit.Framework;
using System;

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

        [TestCase(1, ExpectedResult = 25)]
        [TestCase(2, ExpectedResult = 18)]
        [TestCase(3, ExpectedResult = 15)]
        [TestCase(4, ExpectedResult = 12)]
        [TestCase(5, ExpectedResult = 10)]
        [TestCase(6, ExpectedResult = 8)]
        [TestCase(7, ExpectedResult = 6)]
        [TestCase(8, ExpectedResult = 4)]
        [TestCase(9, ExpectedResult = 2)]
        [TestCase(10, ExpectedResult = 1)]
        [TestCase(11, ExpectedResult = 0)]
        public int CalculatePoints_should_assign_corrent_points(int position)
        {
            //arrange
            const bool hasFastestLap = false;
            var sut = CreateSut();

            //act
            var result = sut.CalculatePoints(position, hasFastestLap);

            return result;
        }

        [Test]
        public void CalculatePoints_should_return_one_extra_point_when_fastestlap()
        {
            //arrange
            const bool hasFastestLap = true;
            const int position = 1;
            var sut = CreateSut();

            //act
            var result = sut.CalculatePoints(position, hasFastestLap);

            //assert
            Assert.AreEqual(26, result);
        }

        [Test]
        public void CalculatePoints_should_throw_exception_when_position_less_than_1()
        {
            //arrange
            const bool hasFastestLap = false;
            const int position = 0;
            var sut = CreateSut();

            //act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.CalculatePoints(position, hasFastestLap));
        }

    }
}