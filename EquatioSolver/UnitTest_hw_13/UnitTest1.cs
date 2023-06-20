using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_hw_13
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            var testEquation = new Equation(1, -3, 2);
            // act
            var result = testEquation.SolveEquation();
            double[] rightAnswer = new double[] { 1, 2};
            // assert
            Assert.AreEqual(rightAnswer, result);
        }
    }
}
