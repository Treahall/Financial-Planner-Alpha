using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial_Planner2.Models
{
    public class Transaction
    {
        public Transaction(double A, string D, string C)
        {
            Amount = A;
            Description = D;
            Category = C;
        }
        public double Amount;
        public string Description;
        public string Category;
    }
}
