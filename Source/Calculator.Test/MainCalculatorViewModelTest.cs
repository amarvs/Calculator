using NUnit.Framework;
using XamarinPrismMyCalculator.ViewModels;

namespace MainCalculator
{
    public class Calculator
    {
        MainCalculatorViewModel mycalculator;
        [SetUp]
        public void Setup()
        {
            mycalculator = new MainCalculatorViewModel(null)
            {
                Expression = string.Empty,
                ErrorMessage = string.Empty
            };
        }

        [TestCase("AC")]
        [TestCase("+/-")]
        [TestCase("=")]
        public void ExecuteKeyPressedTest(string value)
        {
            switch (value)
            {
                case "AC":
                    mycalculator.Expression = value;
                    mycalculator.KeyPressed.Execute(value);
                    Assert.IsEmpty(mycalculator.Expression);
                    break;

                case "+/-":
                    mycalculator.KeyPressed.Execute(value);
                    Assert.AreEqual(mycalculator.ErrorMessage, "Not Supported yet!");
                    break;
            }
            mycalculator.KeyPressed.Execute(value);
            Assert.IsEmpty(mycalculator.Expression);
        }

        [TestCase("1+1")]
        [TestCase("1-1")]
        [TestCase("2*2")]
        [TestCase("4/2")]
        [TestCase("5%2")]
        public void EvaluateExpressionForValid(string value)
        {
            mycalculator.Expression = value;
            mycalculator.KeyPressed.Execute("=");
            Assert.IsEmpty(mycalculator.ErrorMessage);
        }

        [TestCase("")]
        [TestCase("1/0")]
        [TestCase("Infinity")]
        public void EvaluateExpressionForInvalid(string value)
        {
            mycalculator.Expression = value;
            mycalculator.KeyPressed.Execute("=");
            Assert.AreEqual(mycalculator.ErrorMessage, "Error");
        }

    }
}