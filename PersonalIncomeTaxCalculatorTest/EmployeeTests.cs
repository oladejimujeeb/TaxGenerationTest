using Moq;
using NUnit.Framework;
using PersonalIncomeTaxCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalIncomeTaxCalculatorTest
{
    [TestFixture]
    public class EmployeeTests
    {
        private Mock<ITaxGenerator> _taxGenerator;
        private Employee _tax;

        [SetUp]
        public void Setup()
        {
            _taxGenerator = new Mock<ITaxGenerator>();

        }

        [Test]
        public void GetEmployeeTax_WhenTaxableIncomeIsLessthan300000_ReturnZero()
        {
            var taxableIcome = 160000;
            _tax = new Employee(_taxGenerator.Object);
            _taxGenerator.Setup(t => t.GetPersonalIncomeTax(taxableIcome)).Returns(0);
            
            var result =  _tax.EmployeeTax(168000);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GetEmployeeTax_WhenTaxableIncomeIsWithinFirst300000_ComputeTaxWith7Percent()
        {
            var taxableIcome = 315200;
            var tax = 91608;
            _tax = new Employee(_taxGenerator.Object);
            _taxGenerator.Setup(t => t.GetPersonalIncomeTax(taxableIcome)).Returns(tax);
            
            var result = _tax.EmployeeTax(taxableIcome);
            Assert.That(result, Is.EqualTo(tax));
            _taxGenerator.Verify(x => x.GetPersonalIncomeTax(taxableIcome));
        }

        [Test]
        public void GetEmployeeTax_WhenTaxableIncomeIsWithintheNext300000_ComputeTaxWith11Percent()
        {
            var taxableIcome = 352000;
            var tax = 120480.00000000001;
            _tax = new Employee(_taxGenerator.Object);
            _taxGenerator.Setup(t => t.GetPersonalIncomeTax(taxableIcome)).Returns(tax);
            
            var result = _tax.EmployeeTax(taxableIcome);
            Assert.That(result, Is.EqualTo(tax));
        }

        [Test]
        public void GetEmployeeTax_WhenTaxableIncomeIsWithintheFisrt500000_ComputeTaxWith15Percent()
        {
            var taxableIcome = 609600;
            var tax = 226344.00000000003;
            _tax = new Employee(_taxGenerator.Object);
            _taxGenerator.Setup(t => t.GetPersonalIncomeTax(taxableIcome)).Returns(tax);
           
            var result = _tax.EmployeeTax(taxableIcome);
            Assert.That(result, Is.EqualTo(tax));
        }
        [Test]
        public void GetEmployeeTax_WhenTaxableIncomeIsWithintheNext500000_ComputeTaxWith19Percent()
        {
            var taxableIcome = 683200;
            var tax = 244008.00000000003;
            _tax = new Employee(_taxGenerator.Object);
            _taxGenerator.Setup(t => t.GetPersonalIncomeTax(taxableIcome)).Returns(tax);

            var result = _tax.EmployeeTax(taxableIcome);
            Assert.That(result, Is.EqualTo(tax));
        }
        [Test]
        public void GetEmployeeTax_WhenTaxableIncomeIsWithintheFisrt1600000_ComputeTaxWith21Percent()
        {
            var taxableIcome = 2008000;
            var tax = 603200;
            _tax = new Employee(_taxGenerator.Object);
            _taxGenerator.Setup(t => t.GetPersonalIncomeTax(taxableIcome)).Returns(tax);

            var result = _tax.EmployeeTax(taxableIcome);
            Assert.That(result, Is.EqualTo(tax));
        }
        [Test]
        public void GetEmployeeTax_WhenTaxableIncomeIsWith3200000_ComputeTaxWith24Percent()
        {
            var taxableIcome = 2744000;
            var tax = 981440.0000000001;
            _tax = new Employee(_taxGenerator.Object);
            _taxGenerator.Setup(t => t.GetPersonalIncomeTax(taxableIcome)).Returns(tax);

            var result = _tax.EmployeeTax(taxableIcome);
            Assert.That(result, Is.EqualTo(tax));
        }
    }
}
