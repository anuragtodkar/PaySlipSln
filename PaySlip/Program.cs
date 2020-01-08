using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlip
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //intialize tax rates
                List<TaxRate> taxRates = new List<TaxRate>() {
                                new TaxRate(0, 18200, 0, 0),
                                new TaxRate(18201, 37000, 0, 19),
                                new TaxRate(37001, 87000, 3572, 32.5m),
                                new TaxRate(87001, 180000, 19822, 37),
                                new TaxRate(180001, 999999, 54232, 45)

                    };

                Employee employee = new Employee();

                string temp = "";
                Console.WriteLine("Please enter First Name.");
                employee.FirstName = Console.ReadLine();
                ValidateName(employee.FirstName,"First Name");

                Console.WriteLine("Please enter Last Name.");
                employee.LastName = Console.ReadLine();
                ValidateName(employee.LastName, "Last Name");

                Console.WriteLine("Please enter Annual Salary.");
                temp = Console.ReadLine();

                ValidateAnnualSalary(temp, "Annual Salary");
                employee.AnnualSalary = Convert.ToInt32(temp);

                Console.WriteLine("Please enter Super Rate(%).");
                temp = Console.ReadLine();
                ValidateSuperRate(temp, "Super Rate(%)");
                employee.SuperRate= Convert.ToInt32(temp);

                Console.WriteLine("Please enter Payment Start Date.");
                employee.PaymentStartDate = Console.ReadLine();

                Console.WriteLine("------------------------------");

                // calulate tax and super amounts
                employee.CalculateTaxAndSuperAmounts(taxRates);

                Console.WriteLine("first-name, last-name,annual-salary,super-rate(%),payment-start-date");
                Console.WriteLine($"{employee.FirstName} {employee.LastName}, {employee.GrossIncomeAmount}, {employee.IncomeTaxAmount}, " +
                     $" {employee.NetIncomeAmount}, {employee.SuperAmount}, {employee.PaymentStartDate} ");

                Console.ReadLine();
            }
            catch (InvalidNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidAnnualSalaryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidSuperRateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception)
            {

            }

            Console.ReadLine();
        }

        private static void ValidateName(string name,string fieldName)
        {


            if (name.Trim() =="")
                throw new InvalidNameException(fieldName);

        }

        private static void ValidateAnnualSalary(string amount, string fieldName)
        {
            int myInt;
            bool isNumerical = int.TryParse(amount, out myInt);
            if  ((isNumerical && (myInt>=0 && myInt <=999999)) == false)
            {
                throw new InvalidAnnualSalaryException(fieldName);
            }

        }

        private static void ValidateSuperRate(string amount, string fieldName)
        {
            int myInt;
            bool isNumerical = int.TryParse(amount, out myInt);
            if (!(isNumerical && (myInt >= 0 && myInt <= 12)))
            {
                throw new InvalidSuperRateException(fieldName);
            }

        }

    }
}
