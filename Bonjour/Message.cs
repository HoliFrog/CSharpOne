using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bonjour
{
    public class Message
    {
        private int middle;
        private int end;
        private int begin;
        private IDateTime _dateTime;

        public Message(int begin, int middle, int end)
            : this(new RealDateTime(), begin, middle, end)
        {
        }

        internal Message(IDateTime dateTime, int begin, int middle, int end)
        {
            this._dateTime = dateTime;
            this.begin = begin;
            this.middle = middle;
            this.end = end;
        }
             
        public string DisplayDayMessage()
        {            
            string hour = _dateTime.date.ToShortTimeString();
            string userName = Environment.UserName;

            string dayMessage = "";
            DayOfWeek dayName = _dateTime.date.DayOfWeek;
            CultureInfo french = new CultureInfo("fr-FR");
            string day = _dateTime.date.ToString("dddd", french);

            if ((dayName == DayOfWeek.Monday && _dateTime.date.Hour > begin) 
                || dayName == DayOfWeek.Tuesday 
                || dayName == DayOfWeek.Wednesday 
                || dayName == DayOfWeek.Thursday 
                || (dayName == DayOfWeek.Friday && _dateTime.date.Hour < end))
            {
                if (_dateTime.date.Hour >= begin && _dateTime.date.Hour < middle)
                {

                    dayMessage = String.Format("Bonjour : {0}, nous sommes {1}, il est {2}",
                        userName, day, hour);
                }
                if (_dateTime.date.Hour >= middle && _dateTime.date.Hour < end)
                {
                    dayMessage = String.Format("Bon après-midi : {0}, nous sommes {1}, il est {2}",
                      userName, day, hour);
                }
                
                if (_dateTime.date.Hour < begin && dayName == DayOfWeek.Monday)
                {

                }
            }
            else if ((_dateTime.date.Hour >= end && dayName == DayOfWeek.Friday)
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
