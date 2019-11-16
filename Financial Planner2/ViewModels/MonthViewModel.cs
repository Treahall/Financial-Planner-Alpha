using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Financial_Planner2.Models;
using System.Windows;

namespace Financial_Planner2.ViewModels
{
    public class MonthViewModel
    {
        public BindableCollection<DateWithRecords> Month { get; set; }
        public BindableCollection<string> DayOfWeek { get; set; }
        public string MonthAndYear { get; set; }

        public MonthViewModel()
        {
            DataAccess da = new DataAccess();
            MonthAndYear = da.Today.ToString("Y");
            Month = new BindableCollection<DateWithRecords>(da.GetCurrentMonth());
            DayOfWeek = new BindableCollection<string>() { "Sun", "Mon", "Tue", "Wed", "Thu","Fri","Sat" };
        }

    }


}
