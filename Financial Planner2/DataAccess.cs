using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Financial_Planner2.Models;

namespace Financial_Planner2
{
    public class DataAccess
    {
        OleDbConnection cn;
        private DateTime Today;
        private DateTime SelectedDate;
        public DateTime Start;

        BindableCollection<DateWithRecords> CalendarDates;
        public DataAccess()
        {
            cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Planner.mdb");
            CalendarDates = new BindableCollection<DateWithRecords>();
            Today = DateTime.Today;
            SelectedDate = Today;
        }

        public BindableCollection<DateWithRecords> GetThisMonth()
        {
            string query = "select* from Transactions";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            SelectedDate = Today;
            Start = GetFirstDayOfCalendar(Today);
            CalendarDates.Clear();

            for (int i = 0; i < 42; i++)
            {

                CalendarDates.Add(new DateWithRecords(Start.AddDays(i)));
            }

            while (read.Read())
            {

                foreach (DateWithRecords D in CalendarDates)
                {
                    if (D.Mydate == (DateTime)read[0])
                    {
                        D.Records.Add(new Transaction( (double)read[1], (string)read[2], (string)read[3]));
                        D.CalculateTotals();
                    }
                }
            }

            return CalendarDates;
        }

        public BindableCollection<DateWithRecords> GetSpecificMonth(DateTime D)
        {
            SelectedDate = D;
            Start = GetFirstDayOfCalendar(D);
            CalendarDates.Clear();

            for (int i = 0; i < 42; i++)
            {
                CalendarDates.Add(new DateWithRecords(Start.AddDays(i)));
            }

            return CalendarDates;
        }

        public DateTime GetFirstDayOfCalendar(DateTime D)
        {
            //subtracts the number of days needed to get to first of month.
            D = D.AddDays((D.Day * -1) + 1);

            //subtracts the numeric version of the DayOfWeek (Etc. Sunday = 0 and Saturday = 6)
            return D.AddDays((double)D.DayOfWeek * -1);
        }

        public string GetCalenderHeader()
        {
            return SelectedDate.ToString("Y");
        }
    }
}
