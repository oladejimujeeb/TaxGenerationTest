using Moq;
using NUnit.Framework;
using PersonalIncomeTaxCalculator;

namespace PersonalIncomeTaxCalculatorTest
{
    [TestFixture]
    public class EmployeeTaxableIncomeTests
    {
        private Mock<ITaxGenerator> _taxGenerator;
        private Employee _tax;

        [SetUp]
        public void Setup()
        {
            _taxGenerator = new Mock<ITaxGenerator>();
           
        }

        [Test]
       public void EmployeeTaxableIncome_WhenCalled_ReturnTaxableIncomeWhen_CRA2_ISGreater()
        {
            _tax = new Employee(_taxGenerator.Object) { Name = "Mujib Oladeji", AnnualIncome = 30200000 };
            _taxGenerator.Setup(t => t.GetTaxableIncome(30200000)).Returns(21925200);

            var result = _tax.EmployeeTaxableIncome();

            Assert.That(result, Is.EqualTo(21925200));   

        }

        [Test]
        public void EmployeeTaxableIncome_WhenCalled_ReturnTaxableIncomeWhen_ConsolidatedRefliefAllowance_ISGreater()
        {
            _tax = new Employee(_taxGenerator.Object) { Name = "Mujib Oladeji", AnnualIncome = 4000000 };
            _taxGenerator.Setup(t => t.GetTaxableIncome(4000000)).Returns(2744000);

            var result = _tax.EmployeeTaxableIncome();

            Assert.That(result, Is.EqualTo(2744000));

        }
    }
}