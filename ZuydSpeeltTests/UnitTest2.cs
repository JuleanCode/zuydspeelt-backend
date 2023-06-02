using ZuydSpeelt;
namespace ZuydSpeeltTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestSubtraction()
        {
            var calculator = new Calculator();
            var testout = calculator.subtraction(40, 20);
            Assert.AreEqual(20, testout);
        }
    }
}