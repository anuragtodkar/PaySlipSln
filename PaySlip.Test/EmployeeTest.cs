using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PaySlip.Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void Test_CalculateTaxAndSuperAmounts()
        {
            //Arrange
            Employee employeeExpected = new Employee("Andrew", "Smith", 60050, 9,922,5004,4082,450,"01 March - 31 March");

            List<TaxRate> taxRates = new List<TaxRate>() {
                                new TaxRate(0, 18200, 0, 0),
                                new TaxRate(18201, 37000, 0, 19),
                                new TaxRate(37001, 87000, 3572, 32.5m),
                                new TaxRate(87001, 180000, 19822, 37),
                                new TaxRate(180001, 999999, 54232, 45)

                    };

            //Act

            Employee employeeActual = new Employee("Andrew","Smith",60050,9, "01 March - 31 March");

            employeeActual.CalculateTaxAndSuperAmounts(taxRates);

            //Assert

            Assert.AreEqual(employeeExpected.FirstName, employeeActual.FirstName);
            Assert.AreEqual(employeeExpected.LastName, employeeActual.LastName);
            Assert.AreEqual(employeeExpected.AnnualSalary, employeeActual.AnnualSalary);
            Assert.AreEqual(employeeExpected.SuperRate, employeeActual.SuperRate);

            Assert.AreEqual(employeeExpected.GrossIncomeAmount, employeeActual.GrossIncomeAmount);
            Assert.AreEqual(employeeExpected.IncomeTaxAmount, employeeActual.IncomeTaxAmount);
            Assert.AreEqual(employeeExpected.NetIncomeAmount, employeeActual.NetIncomeAmount);
            Assert.AreEqual(employeeExpected.SuperAmount, employeeActual.SuperAmount);
            Assert.AreEqual(employeeExpected.PaymentStartDate, employeeActual.PaymentStartDate);






        }
    }
}
