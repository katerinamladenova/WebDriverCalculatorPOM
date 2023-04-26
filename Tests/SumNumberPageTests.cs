using WebDriverCalculatorPOM.Pages;

namespace WebDriverCalculatorPOM.Tests
{
    public class SumNumberPageTests : BaseTests
    {
        private SumNumbersPage page;

        [SetUp]
        public void Setup()
        {
            this.page = new SumNumbersPage(driver);
            page.Open();
        }
        
        [Test]
        public void Test_Calculator_checkTitle()
        {
            Assert.That(page.GetPageTitle(), Is.EqualTo("Number Calculator"));
        }

        [TestCase("5", "+", "20", "Result: 25")]
        [TestCase("-5", "+", "-20", "Result: -25")]
        [TestCase("5", "-", "20", "Result: -15")]
        [TestCase("-5", "-", "-20", "Result: 15")]
        [TestCase("5", "*", "20", "Result: 100")]
        [TestCase("-5", "*", "20", "Result: -100")]
        [TestCase("-5", "+", "20", "Result: 15")]
        [TestCase("20", "/", "5", "Result: 4")]
        [TestCase("-20", "/", "5", "Result: -4")]
        [TestCase("afs", "+", "asdfsad", "Result: invalid input")]
        public void Test_Calculator_TwoNumbers(string firstValue, string operation, 
            string secondValue, string result)
        {
            var actualResult = page.CalcNumbers(firstValue, operation, secondValue);

            Assert.That(actualResult, Is.EqualTo(result));
        }

        [Test]
        public void Test_Calculator_checkReset()
        {
            page.CalcNumbers("5", "+", "20");
            page.ResetForm();
            Assert.True(page.IsFormEmpty());
        }
    }
}