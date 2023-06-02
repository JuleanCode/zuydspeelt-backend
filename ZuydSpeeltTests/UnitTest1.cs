using ZuydSpeelt;
namespace ZuydSpeeltTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddition()
        {
            var calculator = new Calculator();
            var testout = calculator.addition(20, 20);
            Assert.AreEqual(40,testout);
        }
    }
}