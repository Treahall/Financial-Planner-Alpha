using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial_Planner2.Models
{
    public class DateWithRecords
    {
        public List<Transaction> Records { get; set; }
        public DateTime Mydate { get; set; }
        public int Day { get; }
        public int Month { get; }
        public int Year { get; }
        public DateWithRecords(DateTime D)
        {
            Mydate = D;
            Month = D.Month;
            Day = D.Day;
            Year = D.Year;
        }
        
    }
}
