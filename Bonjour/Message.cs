using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonjour
{
    public class Message
    {
        private int middle;
        private int end;
        private int begin;

        public Message(int begin, int middle, int end)
        {
            this.begin = begin;
            this.middle = middle;
            this.end = end;
        }
             
        public string DisplayDayMessage()
        {
            DateTime dateValue = DateTime.Now;
            string hour = dateValue.ToShortTimeString();
            string userName = Environment.UserName;

            string dayMessage = "";
            DayOfWeek dayName = dateValue.DayOfWeek;
            CultureInfo french = new CultureInfo("fr-FR");
            string day = dateValue.ToString("dddd", french);

            if ((dayName == DayOfWeek.Monday && dateValue.Hour > begin) 
                || dayName == DayOfWeek.Tuesday 
                || dayName == DayOfWeek.Wednesday 
                || dayName == DayOfWeek.Thursday 
                || (dayName == DayOfWeek.Friday && dateValue.Hour < end))
            {
                if (dateValue.Hour >= begin && dateValue.Hour < middle)
                {

                    dayMessage = String.Format("Bonjour : {0}, nous sommes {1}, il est {2}",
                        userName, day, hour);
                }
                if (dateValue.Hour >= middle && dateValue.Hour < end)
                {
                    dayMessage = String.Format("Bon après-midi : {0}, nous sommes {1}, il est {2}",
                      userName, day, hour);
                }
                
                if (dateValue.Hour < begin && dayName == DayOfWeek.Monday)
                {

                }
            }
            else if ((dateValue.Hour >= end && dayName == DayOfWeek.Friday)
                    || dayName == DayOfWeek.Sunday || dayName == DayOfWeek.Saturday)
            {
                dayMessage = String.Format("Bon Week-end : {0}, nous sommes {1}, il est {2}, il faut arrêter de travailler",
                   userName, day, hour);
            }
            else
            {
                dayMessage = "Date invalide!!";

            }
            return dayMessage;
        }
    }
}
