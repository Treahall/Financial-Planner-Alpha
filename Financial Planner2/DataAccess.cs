using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Financial_Planner2.Models;

namespace Financial_Planner2
{
    public class DataAccess
    {
        public DateTime Today;
        DateTime FirstOfMonth;
        DateTime FirstOfCalender;
        BindableCollection<DateWithRecords> DaysOfMonth;
        public DataAccess()
        {
            DaysOfMonth = new BindableCollection<DateWithRecords>();
            Today = DateTime.Today;
        }

        public BindableCollection<DateWithRecords> GetCurrentMonth()
        {
            FirstOfMonth = new DateTime(Today.Year, Today.Month, 1);
            FirstOfCalender = FirstOfMonth.AddDays((double)FirstOfMonth.DayOfWeek * -1);

            for (int i = 0; i < 42; i++)
            {
                DaysOfMonth.Add(new DateWithRecords(FirstOfCalender.AddDays(i)));
            }

            return DaysOfMonth;
        }
    }
}
