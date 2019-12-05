using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Financial_Planner2.Models;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;

namespace Financial_Planner2.ViewModels
{
    public class MonthViewModel : Screen
    {
        public RelayCommand<DatePicker> UpdateInformation { get; private set; }
        public BindableCollection<DateWithRecords> CalendarDates { get; set; }
        public BindableCollection<string> WeekDayTitles { get; set; }
        public string CalendarHeader { get; set; }

        DataAccess da;

        public MonthViewModel()
        {
            UpdateInformationCommand();
            da = new DataAccess();
            //Gets calendar for the current month.
            CalendarDates = new BindableCollection<DateWithRecords>(da.GetThisMonth());
            //Sets the current month and year as the calendar header.
            CalendarHeader = da.GetCalenderHeader();
            //Sets Titles for the weeks.
            WeekDayTitles = new BindableCollection<string>() { "Sun", "Mon", "Tue", "Wed", "Thu","Fri","Sat" };
        }

        public void UpdateInformationExecute(DatePicker D)
        {
            if(D.SelectedDate != null)
            {
                CalendarDates = da.GetSpecificMonth((DateTime)D.SelectedDate);
                CalendarHeader = da.GetCalenderHeader();
                NotifyOfPropertyChange(() => CalendarDates);
                NotifyOfPropertyChange(() => CalendarHeader);
            }
        }
        public void UpdateInformationCommand()
        {
            UpdateInformation = new RelayCommand<DatePicker>((D) => UpdateInformationExecute(D));
        }

    }


}
