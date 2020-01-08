using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlip
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public int AnnualSalary { get; set; }
        public int SuperRate { get; set; }

        public string PaymentStartDate { get; set; }
        public decimal IncomeTaxAmount { get; set; }
        public decimal GrossIncomeAmount { get; set; }

        public decimal NetIncomeAmount { get; set; }

        public decimal SuperAmount { get; set; }

        public Employee()
        {

        }
        public Employee(string firstName, string lastName, int annualSalary,int superRate )
        {
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = annualSalary;
            SuperRate = superRate;
        }

        public Employee(string firstName, string lastName, int annualSalary, int superRate, decimal incomeTaxAmount
            ,decimal grossIncomeAmount, decimal netIncomeAmount, decimal superAmount)
        {
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = annualSalary;
            SuperRate = superRate;
            IncomeTaxAmount = incomeTaxAmount;
            GrossIncomeAmount = grossIncomeAmount;
            NetIncomeAmount = netIncomeAmount;
            SuperAmount = superAmount;
        }


        public void CalculateTaxAndSuperAmounts(List<TaxRate> taxRates)
        {
            GetIncomeTaxAmount(taxRates);
            IncomeTaxAmount = Convert.ToInt32(IncomeTaxAmount / 12);
            GrossIncomeAmount = Convert.ToInt32(AnnualSalary / 12);
            NetIncomeAmount = GrossIncomeAmount - IncomeTaxAmount ;
            SuperAmount = Convert.ToInt32(GrossIncomeAmount * SuperRate/100);
        }
        private void GetIncomeTaxAmount(List<TaxRate> taxRates)
        {
            foreach (var taxrate in from TaxRate taxrate in taxRates
                                    where AnnualSalary >= taxrate.MinValue && AnnualSalary <= taxrate.MaxValue
                                    select taxrate)
            {
                IncomeTaxAmount = taxrate.TaxAmount;
                IncomeTaxAmount +=  Convert.ToInt32((AnnualSalary - taxrate.MinValue) * taxrate.TaxPerOnExcess/100);
            }

            
        }

    }

    [Serializable]
    class InvalidNameException : Exception
    {
        public InvalidNameException()
        {

        }

        public InvalidNameException(string name)
            : base(String.Format("Please enter correct data. {0} cannot be left blank. The length of {0} cannot be greater than 60 characters. Please close the application and run again.", name))
        {

        }

    }

    class InvalidAnnualSalaryException : Exception
    {
        public InvalidAnnualSalaryException()
        {

        }

        public InvalidAnnualSalaryException(string name)
            : base(String.Format("Please enter correct amount for {0}. The amount can be between 0 and 999999. Please close the application and run again.", name))
        {

        }

    }

    class InvalidSuperRateException : Exception
    {
        public InvalidSuperRateException()
        {

        }

        public InvalidSuperRateException(string name)
            : base(String.Format("Please enter correct amount for {0}. The amount can be between 0 and 12. Please close the application and run again.", name))
        {

        }

    }


}
