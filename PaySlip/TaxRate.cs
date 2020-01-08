using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlip
{
    class TaxRate
    {
        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public int TaxAmount { get; set; }

        public decimal TaxPerOnExcess { get; set; }

        public TaxRate(int minValue,int maxValue,int taxAmount, decimal taxPerOnExccess )
        {
            MinValue = minValue;
            MaxValue = maxValue;
            TaxAmount = taxAmount;
            TaxPerOnExcess = taxPerOnExccess;
        }





    }
}
