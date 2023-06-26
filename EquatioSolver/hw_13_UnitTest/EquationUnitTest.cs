using FluentAssertions;
using hw13_1_web_asp;

namespace hw_13_UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldCheckRoots()
        {
            // arrange
            var testEquation = new Equation(1, -3, 2);
            // act
            var result = testEquation.SolveEquation();
            double[] rightAnswer = new double[] { 1, 2 };
            // assert
            result.Should().BeEquivalentTo(rightAnswer);
        }
    }
}